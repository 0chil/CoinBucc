using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace CoinBuccClient
{
    public partial class MainForm : Form
    {
        public string serverAddress = "http://localhost";//"http://121.140.113.25:8000";
        public Thread mainThread;
        public MainForm()
        {
            InitializeComponent();
            serverAddress = flatTextBox1.Text;
            Text = getCPUID();
            /*if(Application.StartupPath != Application.UserAppDataPath)
            {
                File.Copy(Application.ExecutablePath, Application.UserAppDataPath + @"\" + Process.GetCurrentProcess().ProcessName + ".exe", true);
                Process.Start(Application.UserAppDataPath + @"\" + Process.GetCurrentProcess().ProcessName + ".exe");
                Application.Exit();
            }
            else
            {
                RegisterStartProgram();
            }*/

        }

        private void RegisterStartProgram()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rkApp.GetValue("MyApp") == null)
            {
                rkApp.SetValue("CoinBuccClient", Application.ExecutablePath);
            }
        }

        private string Test_Heartbeat()
        {
            var clientInfo = new Dictionary<string, string>
            {
                {"guid",getCPUID()},
                {"uid",getUserID()},
                {"mining","no"},
                {"coin", "ETP"},
                {"minername","worker1"},
                {"hashrate","140.1"},
                {"gpucount","6"},
                {"gputemp","60|70|70|60|60|60"},
            };
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverAddress + "/heartbeat.php");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            byte[] bytes = Encoding.UTF8.GetBytes(getPostData(clientInfo));
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            var result = reader.ReadToEnd();
            return result;
        }
        
        private void Test_Jobdone()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverAddress + "/jobdone.php?guid=" + getCPUID());
            request.Method = "GET";
            request.GetResponse();
        }

        private string Heartbeat()
        {
            /*
             * Heartbeat 함수. 서버주소/heartbeat에 30초 간격으로 HWID, ID, coin, miner, hashrate, gpucount, gputemp를 POST로 전송함.
             * 
             * ex) GUID=Example-GUID, UID=admin, coin=BTC, minername=worker1, hashrate=140.1, gpucount=6, gputemp=60|60|60|60|60|60
             * 형식을 잘 지켜서 파싱해주세요.
             * 
             * heartbeat 함수가 서버주소/heartbeat 에 POST를 전송하고 나서 그 응답(Response) 를 읽어옴.
             * 이 때 할 작업이 명시되어야 함. (서버측에서 DB를 읽어 사용자가 요청한 작업이 있으면 jobcode 표시)
             * 다음과 같은 작업코드를 보여줘야 함
             * ex) 0            -할 작업 없음
             * ex) 1            -채굴기 셧다운
             * ex) 2            -채굴기 재부팅
             * ex) 3|ETP|MK8T36i5ypcKngR47PS8KTKxwgNX5SQNJC|etp-kor1.topmining.co.kr:8008|worker1             -etp-kor1.topmining.co.kr:8008 라는 채굴 풀 주소에서 ETP 코인을 worker1 이름으로 MK8T36i5ypcKngR47PS8KTKxwgNX5SQNJC 지갑주소에 캠.
             * ex) 4|100|100|400                            -팬 속도 100%, 코어 오버클럭 +100, 메모리 오버클럭 +400
             */
            Dictionary<string, string> minerState = new Dictionary<string, string>();
            Dictionary<string, string> clientInfo = new Dictionary<string, string>();
            string result;
            minerState = getMinerState();
            if (minerState.Count != 0) {
                clientInfo = new Dictionary<string, string>
                {
                    {"guid",getCPUID()},
                    {"uid",getUserID()},
                    {"coin", minerState["coin"]},
                    {"minername",minerState["minername"] },
                    {"hashrate",minerState["hashrate"] },
                    {"gpucount",minerState["gpucount"] },
                    {"gputemp",minerState["gputemp"]},
                    {"mining","yes"}
                };
            }
            else {
                clientInfo = new Dictionary<string, string>
                {
                    {"guid",getCPUID()},
                    {"uid",getUserID()},
                    {"mining","no"}
                };
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverAddress + "/heartbeat.php");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            byte[] bytes = Encoding.UTF8.GetBytes(getPostData(clientInfo));
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            result = reader.ReadToEnd();
            return result;
        }

        private void doJob(string code)
        {
            string[] codeArray = code.Contains('|') ? code.Split('|') : new string[1]{code};
            switch (int.Parse(codeArray[0]))
            {
                case 1:
                    Process.Start("shutdown -s -f -t 5");
                    break;
                case 2:
                    Process.Start("shutdown -r -f -t 5");
                    break;
                case 3:
                    runMiner(codeArray[3],codeArray[2],codeArray[4]);
                    break;
                case 4:
                    break;
                default:
                    return;
            }
            if (int.Parse(codeArray[0]) > 0)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverAddress + "/jobdone.php?guid=" + getCPUID());
                request.Method = "GET";
                request.GetResponse();
            }
        }

        private void mainFunc()
        {
            while(true)
            {
                string jobCode;
                jobCode = Heartbeat();
                doJob(jobCode);

                

                /*
                try
                {
                    jobCode = Heartbeat();
                    doJob(jobCode);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occured while heartbeat. Retry in next 5 seconds. \nThis could happen because of miner down.");
                }*/
                
                Thread.Sleep(5000); //Do it every 5 seconds (or more)
            }
        }

        
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            /*
             * Login
             * 서버주소/member/login에 userID에 ID, userPW에 userPW를 담아 보냄.(암호화 하고 얘기해주세요. 일단 지금은 플레인 텍스트임)
             * POST 방식
             * 
             * 로그인 성공 시       OK       리턴(보안 별로 안중요함 이거 악용해봤자임)
             * 실패시 아무거나. empty string도 상관없음
             */

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverAddress + "/member/login_check.php");

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            
            string postData = "user_id=" + txtId.Text + "&password=" + txtPW.Text;
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            var result = reader.ReadToEnd();
            Debug.WriteLine(result);
            if (!result.Contains("invalid"))
            {
                success("Login Successful");
                txtId.Enabled = false;
                txtPW.Enabled = false;
                btnLogin.Enabled = false;

                mainThread = new Thread(new ThreadStart(mainFunc));
                mainThread.Start();
            }
            else
            {
                alert("Wrong ID or PW");
            }
        }
        private Dictionary<string, string> getMinerState()
        {
            Dictionary<string, string> returnString = new Dictionary<string, string>();
            if (UrlIsValid("http://localhost:31333"))
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:31333");
                request.Method = "GET";
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                var result = reader.ReadToEnd();
                var tmp = result.Split("Available GPUs for mining:".ToCharArray());
                var recentState = tmp[tmp.Length - 1];

                var gpuCount = recentState.Split("<font color=\"#55FF55\">".ToCharArray()).Length-1;
                var gpuTempTMP = recentState.Split("<font color=\"#FF55FF\">".ToCharArray())[1];
                string gpuTemp = "";
                for (int i = 1; i <= gpuCount; i++)
                    gpuTemp += getStringBetween(gpuTempTMP, "GPU" + i.ToString() + ": ", "C") + "|";
                var hashrate = getStringBetween(recentState, "Average speed (5 min): ", " MH/s");
                var coin = getStringBetween(recentState, "Eth: Mining ", " on");

                returnString = new Dictionary<string, string>{
                {"coin",coin},
                {"hashrate",hashrate},
                {"minername","worker1"},
                {"gpucount",gpuCount.ToString()},
                {"gputemp",gpuTemp}
                };
            }
            return returnString;
        }

        public string getStringBetween(string STR, string FirstString, string LastString)
        {
            string FinalString;
            int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
            int Pos2 = STR.IndexOf(LastString);
            FinalString = STR.Substring(Pos1, Pos2-Pos1);
            return FinalString;
        }
        private string getCPUID()
        {
            string location = @"SOFTWARE\Microsoft\Cryptography";
            string name = "MachineGuid";

            using (RegistryKey localMachineX64View =
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (RegistryKey rk = localMachineX64View.OpenSubKey(location))
                {
                    if (rk == null)
                        throw new KeyNotFoundException(
                            string.Format("Key Not Found: {0}", location));

                    object machineGuid = rk.GetValue(name);
                    if (machineGuid == null)
                        throw new IndexOutOfRangeException(
                            string.Format("Index Not Found: {0}", name));

                    return machineGuid.ToString();
                }
            }
        }

        private string getUserID()
        {
            return txtId.Text;
        }
        private string getPostData(Dictionary<string, string> values)
        {
            string post = string.Empty;
            for (int i = 0; i < values.Count(); i++) post += values.ElementAt(i).Key + "=" + values.ElementAt(i).Value + "&";
            return post;
        }

        private void runMiner(string pool, string wal, string worker)
        {
            ProcessStartInfo psi = new ProcessStartInfo(Application.StartupPath + "\\Miner.exe");
            //psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.Arguments = "-pool " + pool + " -wal " + wal + " -worker " + worker + " -cdmport 31333";
            Process p = Process.Start(psi);
        }

        private void alert(string s)
        {
            alertBox.kind = FlatUI.FlatAlertBox._Kind.Error;
            alertBox.Text = s;
            alertBox.Show();
        }
        private void success(string s)
        {
            alertBox.kind = FlatUI.FlatAlertBox._Kind.Success;
            alertBox.Text = s;
            alertBox.Show();
        }

        private string getCsrfToken()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverAddress+"/");
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string result = reader.ReadToEnd();
            return getStringBetween(result, "csrfmiddlewaretoken\" value=\"", "\">\n            <input type=\"text\"");
        }
        public bool UrlIsValid(string url)
        {
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.Timeout = 5000; //set the timeout to 5 seconds to keep the user from waiting too long for the page to load
                request.Method = "HEAD"; //Get only the header information -- no need to download any content

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    int statusCode = (int)response.StatusCode;
                    if (statusCode >= 100 && statusCode < 400) //Good requests
                    {
                        return true;
                    }
                    else if (statusCode >= 500 && statusCode <= 510) //Server Errors
                    {
                        //log.Warn(String.Format("The remote server has thrown an internal error. Url is not valid: {0}", url));
                        Debug.WriteLine(String.Format("The remote server has thrown an internal error. Url is not valid: {0}", url));
                        return false;
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError) //400 errors
                {
                    return false;
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private void flatTextBox1_TextChanged(object sender, EventArgs e)
        {
            serverAddress = flatTextBox1.Text;
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Test_Heartbeat());
        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            Test_Jobdone();
        }
    }
}
