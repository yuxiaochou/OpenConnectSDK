using Newtonsoft.Json.Linq;
using OpenConnectSDK.Helpers;
using OpenConnectSDK.Weibo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OpenConnectSDK.Weibo.Api
{
    public class WeiboOAuthApi
    {
        /// <summary>
        /// 获取验证地址
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="redirectUrl"></param>
        /// <param name="state"></param>
        /// <param name="scope"></param>
        /// <param name="responseType"></param>
        /// <param name="display"></param>
        /// <returns></returns>
        public static string GetAuthorizeUrl(string appId, string redirectUrl, string state = "", string scope = "",
            WeiboAuthorizeDisplay display = WeiboAuthorizeDisplay.Default, bool forceLogin = false,
            Language language = Language.zh_CN)
        {
            var url =
                string.Format("https://api.weibo.com/oauth2/authorize?client_id={0}&redirect_uri={1}&scope={2}&state={3}",
                                appId, HttpUtility.UrlEncode(redirectUrl), scope, state);

            if (display != WeiboAuthorizeDisplay.Default)
            {
                url += "&display=" + display;
            }

            if (forceLogin)
            {
                url += "&forcelogin=" + forceLogin;
            }

            if (language != Language.zh_CN)
            {
                url += "&language=" + language;
            }

            /* 如果用户成功登录并授权，则会跳转到指定的回调地址，并在redirect_uri地址后带上Authorization Code和原始的state值。
             */
            return url;
        }

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="secret"></param>
        /// <param name="redirectUrl"></param>
        /// <param name="code"></param>
        /// <param name="grantType"></param>
        /// <returns></returns>
        public static WeiboOAuthToken GetAccessToken(string appId, string secret, string redirectUrl, string code, string grantType = "authorization_code")
        {
            var url =
                string.Format("https://api.weibo.com/oauth2/access_token?client_id={0}&client_secret={1}&code={2}&grant_type={3}}&redirect_uri={4}",
                                appId, secret, code, grantType, HttpUtility.UrlEncode(redirectUrl));

            /* 如果成功返回，即可在返回包中获取到Access Token。
             * 返回如下字符串：access_token=FE04************************CCE2&expires_in=7776000
             * expires_in是该access token的有效期，单位为秒。
             */

            string response = WebClientHelper.GetMethod(url);

            JObject jsonObj = JObject.Parse(response);

            WeiboOAuthToken token = new WeiboOAuthToken
            {
                AccessToken = jsonObj["access_token"].ToString(),
                ExpiresIn = ConvertHelper.ToInt(jsonObj["expires_in"].ToString()),
                UID = jsonObj["uid"].ToString(),
            };
            return token;
        }
    }
}
