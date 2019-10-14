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
            //var minerState = getMinerState();
            var clientInfo = new Dictionary<string, string>
            {
                {"GUID",getCPUID()},
                {"UID",getUserID()},
                {"coin", "ETP"},
                {"minername","worker1"},
                {"hashrate","140.1"},
                {"gpucount","6"},
                {"gputemp","60|70|70|60|60|60"},
            };
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverAddress + "/heartbeat/?"+getPostData(clientInfo));

            request.Method = "GET";
            

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            var result = reader.ReadToEnd();
            return result;
        }
        
        private void Test_Jobdone()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverAddress + "/done/?guid=" + getCPUID());
            request.Method = "GET";
            WebResponse response = request.GetResponse();
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
            var minerState = getMinerState();
            var clientInfo = new Dictionary<string, string>
            {
                {"GUID",getCPUID()},
                {"UID",getUserID()},
                {"coin", minerState["coin"]},
                {"minername",minerState["minername"] },
                {"hashrate",minerState["hashrate"] },
                {"gpucount",minerState["gpucount"] },
                {"gputemp",minerState["gputemp"]},
            };
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverAddress + "/heartbeat/?" + getPostData(clientInfo));
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            var result = reader.ReadToEnd();
            return result;
        }

        private void doJob(string code)
        {
            string[] codeArray = code.Contains('|') ? code.Split('|') : new string[1]{code};
            switch (int.Parse(codeArray[0]))
            {
                case 1:
                    Process.Start("shutdown -s -f -t 0");
                    break;
                case 2:
                    Process.Start("shutdown -r -f -t 0");
                    break;
                case 3:
                    runMiner(codeArray[3],codeArray[2],codeArray[4]);
                    break;
                case 4:
                    break;
                default:
                    return;
            }
        }

        private void mainFunc()
        {
            {
                string jobCode = string.Empty;
                try
                {
                    jobCode = Heartbeat();
                    doJob(jobCode);

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverAddress + "/done/?guid=" + getCPUID());
                    request.Method = "GET";
                    WebResponse response = request.GetResponse();
                }
                catch(Exception e)
                {
                    Console.WriteLine("An error occured while heartbeat. Retry in next 30 seconds");
                }
            }
            Thread.Sleep(30000); //Do it every 30 seconds (or more)
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

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverAddress + "/");

            string csrf = getCsrfToken();
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Cookie("csrftoken", csrf) { Domain = new Uri(serverAddress).Host });

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            
            string postData = "csrfmiddlewaretoken=" + csrf + "&username=" + txtId.Text + "&password=" + txtPW.Text;
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            var result = reader.ReadToEnd();
            if (result.Contains("Dashboard"))
            {
                success("Login Successful");
                txtId.Enabled = false;
                txtPW.Enabled = false;
                btnLogin.Enabled = false;/*
                mainThread = new Thread(new ThreadStart(mainFunc));
                mainThread.Start();*/
            }
            else
            {
                alert("Wrong ID or PW");
            }
        }
        private Dictionary<string,string> getMinerState()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:31333");
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            var result = reader.ReadToEnd();
            var tmp= result.Split("Available GPUs for mining:".ToCharArray());
            var recentState = tmp[tmp.Length - 1];

            var gpuCount = recentState.Split("<font color=\"#55FF55\">".ToCharArray()).Length;
            var gpuTempTMP = getStringBetween(recentState, "<font color=\"#FF55FF\">", "</font>");
            string gpuTemp = "";
            for(int i = 0; i < gpuCount; i++)
                gpuTemp += getStringBetween(gpuTempTMP, "GPU" + i.ToString() + ": ", "C")+"|";
            var hashrate = getStringBetween(recentState, "Average speed (5 min): ", " MH/s");
            var coin = getStringBetween(recentState, "Mining ", " on");

            Dictionary<string,string> returnString = new Dictionary<string, string>{
                {"coin",coin},
                {"hashrate",hashrate},
                {"minername","worker1"},
                {"gpucount",gpuCount.ToString()},
                {"gputemp",gpuTemp}
            };

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
            string cpuID = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (cpuID == "")
                {
                    //Get only the first CPU's ID
                    cpuID = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuID;
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

        private string runMiner(string pool, string wal, string worker)
        {
            ProcessStartInfo psi = new ProcessStartInfo(Application.StartupPath + "\\Miner.exe");
            //psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.Arguments = "-pool " + pool + " -wal " + wal + " -worker " + worker + " -mport 31333";
            Process p = Process.Start(psi);
            return p.MainModule.FileName;
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
