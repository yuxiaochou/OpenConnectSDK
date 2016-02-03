using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenConnectSDK.Helpers;
using OpenConnectSDK.QQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OpenConnectSDK.QQ.Api
{
    public class QQOAuthApi
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
        public static string GetAuthorizeUrl(string appId, string redirectUrl, string state, string scope = "get_user_info",
            string responseType = "code", QQAuthorizeDisplay display = QQAuthorizeDisplay.none)
        {
            var url =
                string.Format("https://graph.qq.com/oauth2.0/authorize?client_id={0}&redirect_uri={1}&response_type={2}&scope={3}&state={4}",
                                appId, HttpUtility.UrlEncode(redirectUrl), responseType, scope, state);

            if (display == QQAuthorizeDisplay.mobile)
            {
                url += "&display=" + display;
            }

            /* 1、如果用户成功登录并授权，则会跳转到指定的回调地址，并在redirect_uri地址后带上Authorization Code和原始的state值。
             * 2. 如果用户在登录授权过程中取消登录流程，对于PC网站，登录页面直接关闭
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
        public static QQOAuthToken GetAccessToken(string appId, string secret, string redirectUrl, string code, string grantType = "authorization_code")
        {
            var url =
                string.Format("https://graph.qq.com/oauth2.0/token?client_id={0}&client_secret={1}&code={2}&grant_type={3}}&redirect_uri={4}",
                                appId, secret, code, grantType, HttpUtility.UrlEncode(redirectUrl));

            /* 如果成功返回，即可在返回包中获取到Access Token。
             * 返回如下字符串：access_token=FE04************************CCE2&expires_in=7776000
             * expires_in是该access token的有效期，单位为秒。
             */

            string response = WebClientHelper.GetMethod(url);

            QQOAuthToken token = new QQOAuthToken();
            var parameters = response.Split('&');
            foreach (var parameter in parameters)
            {
                var accessTokens = parameter.Split('=');
                if (accessTokens[0] == "access_token")
                {
                    token.AccessToken = accessTokens[1];

                }
                if (accessTokens[0] == "expires_in")
                {
                    token.ExpiresIn = ConvertHelper.ToInt(accessTokens[1]);

                }
            }
            return token;
        }

        /// <summary>
        /// 获取OpenID
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static string GetOpenID(string accessToken)
        {
            var url =
                string.Format("https://graph.qq.com/oauth2.0/me?access_token={0}", accessToken);

            /* PC网站接入时，获取到用户OpenID，返回包如下：
             * callback( {"client_id":"YOUR_APPID","openid":"YOUR_OPENID"} ); 
             * openid是此网站上唯一对应用户身份的标识，网站可将此ID进行存储便于用户下次登录时辨识其身份，或将其与用户在网站上的原有账号进行绑定。
             */

            string response = WebClientHelper.GetMethod(url);

            string strJson = response.Replace("callback(", "").Replace(");", "");
            var callBack = JsonConvert.DeserializeObject<QQCallback>(strJson);
            return callBack.OpenId;
        }


    }

}
