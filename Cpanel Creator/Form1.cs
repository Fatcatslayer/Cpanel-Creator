using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.IO;

namespace Cpanel_Creator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string GetSecurityToken(string url, string user, string pass)
        {
            try
            {
                using (var wb = new WebClient())
                {
                    if (url.EndsWith("/"))
                    {
                        string temp = string.Empty;
                        for (int i = 0; i < url.Length - 1; i++)
                            temp += url[i];
                        url = temp;
                    }
                    if (!url.Contains("2087") && !url.Contains("2086"))
                    {
                        string t1 = GetSecurityToken(url + ":2087", user, pass);
                        if (t1 != "Error")
                            return t1;
                        string t2 = GetSecurityToken(url + ":2086", user, pass);
                       if (t2 != "Error")
                            return t2;
                        return "Error";
                    }
                    if (url.Contains("2087") && !url.StartsWith("https://"))
                        url = "https://" + url;
                    url += "/login/?login_only=1";
                    var data = new NameValueCollection();
                    data["user"] = user;
                    data["pass"] = pass;
                    data["login"] = "";
                    data["login_only"] = "1";
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    var response = wb.UploadValues(url, "POST", data);
                    string responseInString = Encoding.UTF8.GetString(response);
                    //dsmdkm
                    if (responseInString.Contains("security_token"))
                    {
                        Dictionary<string, object> x = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseInString);
                        if(x["security_token"]!=null)
                        {
                            return x["security_token"].ToString();
                        }
                        return "Error";
                    }
                    else
                    {
                        return "Error";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
        
        static string Generate(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyz1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }
        static string CreateCpanel(string WhmUrl, string user,string pwd ,string SecurityToken, string Domain, string CpanelUser,string CpanelPass,string Package)
        {
            try
            {
                string url = WhmUrl + SecurityToken + "/json-api/createacct?api.version=1&username=" + CpanelUser + "&domain=" + Domain + "&plan=" + Package + "&password=" + CpanelPass + "&contactemail=ss@ss.com";
                HttpWebRequest req = HttpWebRequest.Create(url) as HttpWebRequest;
                string auth = "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(user + ":" + pwd));
                req.PreAuthenticate = true;
                req.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
                req.Headers.Add("Authorization", auth);
                //req.UserAgent = "cPanel .NET C# authenticator test script";
                WebResponse resp = req.GetResponse();
                Stream receiveStream = resp.GetResponseStream();
                StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
                string content = reader.ReadToEnd();
                if(content.Contains("Account Creation Ok"))
                    return "Created";
                    return "Error";
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
            private string RS(string url)
            {
             if(url.EndsWith("/"))
            {
                string x = string.Empty;
                for (int i = 0; i < url.Length-1; i++)
                {
                    x += url[i];
                }
                return x;
            }
            else
            {
                return url;
            }
            }
        private void AddToFile(string Cpanel)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Cpanels.txt";
            using (var file = File.Exists(path) ? File.Open(path, FileMode.Append) : File.Open(path, FileMode.CreateNew))
            using (var stream = new StreamWriter(file))
                stream.WriteLine(Cpanel);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string   host = RS(hostTxt.Text);
            string   user = userTxt.Text;
            string   pass = passTxt.Text;
            string   package = packageTxt.Text;
            string[] Domains = domainsTxt.Text.Split('\n');
            string securityToken = GetSecurityToken(host, user, pass);
            int Work = 0, Bad = 0;
            for(int i=0;i<Domains.Length;i++)
            {
                string cpaneluser = Generate(12);
                string cpanelpass = Generate(12);

              if(CreateCpanel(host,user,pass,securityToken,Domains[i],cpaneluser,cpanelpass,package)!="Error")
                {
                    Work++;
                    AddToFile(Domains[i] + "|" + cpaneluser + "|" + cpanelpass);
                }else
                {
                    Bad++;
                }
            }
            MessageBox.Show("Done "+Work+" Cpanels Created And "+Bad+" Failed");
        }
    }
}
