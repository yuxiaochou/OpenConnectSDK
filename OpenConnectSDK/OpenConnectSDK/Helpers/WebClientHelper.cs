using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenConnectSDK.Helpers
{
    /// <summary>
    /// WebClient帮助类，用于http交互
    /// </summary>
    public class WebClientHelper
    {
        /// <summary>
        /// Get方法
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Post方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string PostMethod(string url, Dictionary<string, string> postData)
        {
            StringBuilder strPostData = new StringBuilder();
            foreach (var item in postData)
            {
                if (strPostData.Length > 0)
                {
                    strPostData.Append("&");
                }
                strPostData.Append(item.Key + "=" + item.Value);
            }

            return PostMethod(url, strPostData.ToString());
        }
        /// <summary>
        /// Post方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="strPostData">格式为name=张三&amp;sex=男</param>
        /// <returns></returns>
        public static string PostMethod(string url, string strPostData)
        {
            try
            {
                string result = string.Empty;

                WebClient wc = new WebClient();

                // 采取POST方式必须加的Header
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                byte[] postBytes = Encoding.UTF8.GetBytes(strPostData.ToString());
                byte[] responseData = wc.UploadData(url, "POST", postBytes); // 得到返回字符流
                return Encoding.UTF8.GetString(responseData);// 解码     
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
