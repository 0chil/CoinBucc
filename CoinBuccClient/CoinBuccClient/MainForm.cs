using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoinBuccClient
{
    public partial class MainForm : Form
    {
        public string serverAddress = "http://address.to.server";
        public Thread mainThread;
        public MainForm()
        {
            InitializeComponent();
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

        private int Heartbeat()
        {
            var minerState = getMinerState();
            var clientInfo = new Dictionary<string, string>
            {
                {"GUID",getCPUID()},
                {"UID",txtId.Text},
                {"coin", minerState["coin"]},
                {"miner",minerState["miner"] },
                {"hashrate",minerState["hashrate"] },
                {"gpucount",minerState["gpucount"] },
                {"gputemp",minerState["gputemp"]},
            };
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverAddress + "/heartbeat");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            string postData = getPostData(clientInfo);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            var result = reader.ReadToEnd();
            return int.Parse(result);
        }
        
        private void doJob(int code)
        {
            switch (code)
            {
                case 1:
                    Process.Start("shutdown -s -f -t 0");
                    break;
                case 2:
                    Process.Start("shutdown -r -f -t 0");
                    break;
                case 3:
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
                int jobCode = Heartbeat();
                doJob(jobCode);
            }
            Thread.Sleep(30000); //Do it every 30 seconds (or more)
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
            return "";
        }
        private string getPostData(Dictionary<string,string> values)
        {
            string post = string.Empty;
            for (int i = 0; i < values.Count(); i++) post += values.ElementAt(i).Key + "=" + values.ElementAt(i).Value + "&";
            return post;
        }

        private void alert(string s)
        {
            alertBox.Text = s;
            alertBox.Show();
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverAddress + "/member/login");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            string postData = "userID=" + txtId.Text + "&userPW=" + txtPW.Text;
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            var result = reader.ReadToEnd();
            if (result == "OK")
            {
                mainThread = new Thread(new ThreadStart(mainFunc));
                mainThread.Start();
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
                {"miner","claymore"},
                {"gpucount",gpuCount.ToString()},
                {"gputemp",gpuTemp}
            };
            return returnString;
        }
        private string runMiner(string pool, string wal, string worker)
        {
            ProcessStartInfo psi = new ProcessStartInfo(Application.StartupPath + "\\Miner.exe");
            //psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.Arguments = "-pool " + pool + " -wal " + wal + " -worker " + worker + " -mport 31333";
            Process p = Process.Start(psi);
            return p.MainModule.FileName;
        }
        private string getStringBetween(string org,string str,string str2)
        {
            return org.Split(str.ToCharArray())[1].Split(str2.ToCharArray())[0];
        }
    }
}
