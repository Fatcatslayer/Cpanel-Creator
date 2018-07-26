using System;
using System.Text;
using System.Net;
using System.IO;

namespace Cpanel_Creator
{
    public enum httpverb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    class api
    {
        //link to be requested
        public string endpoint { get; set; }
        //http method to request with
        public httpverb httpmethod { get; set; }
        //common url for all shodan methods
        public static string baseUrl = "https://api.shodan.io/shodan/";
        //shodan api key
        public static string apiKey = "0tADFYUICWhyGXyURDZRw1Av5kCUq07l";
        //default constructor
        public api()
        {
            endpoint = string.Empty;
            //shodan use only get http method in all search methods
            httpmethod = httpverb.GET;
        }
        //function to request the api link and return the resonse string(json file)
        public string makeRequest()
        {
            string strResponseValue = string.Empty;
            string to = string.Empty;
            if (!endpoint.StartsWith("http"))
                to = "http://";
            to += endpoint;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(to);
            request.Method = httpmethod.ToString();
            /*request.UseDefaultCredentials = true;
            request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials; */
            request.UserAgent = "Foo";
            request.Accept = "*/*";
            
            //   request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code = " + response.StatusCode);
                }
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }



            return strResponseValue;

        }

    }
}
