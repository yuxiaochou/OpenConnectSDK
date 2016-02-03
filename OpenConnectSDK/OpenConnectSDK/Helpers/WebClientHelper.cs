using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenConnectSDK.Helpers
{
    public class WebClientHelper
    {
        public static string GetMethod(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                Stream steam = webClient.OpenRead(url);
                StreamReader steamReader = new StreamReader(steam);
                string response = steamReader.ReadToEnd();
                steamReader.Close();
                steam.Close();
                return response ?? "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
