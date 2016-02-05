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
    /// <summary>
    /// QQ互联OAuth2授权Api
    /// </summary>
    public class QQOAuthApi
    {
        /// <summary>
        /// 获取授权地址
        /// 文档：http://wiki.connect.qq.com/使用authorization_code获取access_token#Step1.EF.BC.9A.E8.8E.B7.E5.8F.96AuthorizationCode
        /// </summary>
        /// <param name="appId">申请QQ登录成功后，分配给应用的appid</param>
        /// <param name="redirectUrl">成功授权后的回调地址，必须是注册appid时填写的主域名下的地址。</param>
        /// <param name="state">client端的状态值。用于第三方应用防止CSRF攻击，成功授权后回调时会原样带回。请务必严格按照流程检查用户与state参数状态的绑定</param>
        /// <param name="scope">请求用户授权时向用户显示的可进行授权的列表。 可填写的值是API文档中列出的接口，以及一些动作型的授权（目前仅有：do_like），如果要填写多个接口名称，请用逗号隔开。Api列表见 http://wiki.connect.qq.com/api列表 </param>
        /// <param name="responseType">授权类型，此值固定为“code”</param>
        /// <param name="display">用于展示的样式。不传则默认展示为PC下的样式。</param>
        /// <returns>授权地址</returns>
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
        /// 文档：http://wiki.connect.qq.com/使用authorization_code获取access_token#Step2.EF.BC.9A.E9.80.9A.E8.BF.87AuthorizationCode.E8.8E.B7.E5.8F.96AccessToken
        /// </summary>
        /// <param name="appId">申请QQ登录成功后，分配给网站的appid。</param>
        /// <param name="secret">申请QQ登录成功后，分配给网站的appkey。</param>
        /// <param name="redirectUrl">成功授权后的回调地址，必须是注册appid时填写的主域名下的地址。</param>
        /// <param name="code">如果用户成功登录并授权，则会跳转到指定的回调地址，并在URL中带上Authorization Code。此code会在10分钟内过期。</param>
        /// <param name="grantType">授权类型，在本步骤中，此值为“authorization_code”。</param>
        /// <returns>QQ互联验证票据</returns>
        public static QQOAuthToken GetAccessToken(string appId, string secret, string redirectUrl, string code, string grantType = "authorization_code")
        {
            var url =
                string.Format("https://graph.qq.com/oauth2.0/token?client_id={0}&client_secret={1}&code={2}&grant_type={3}&redirect_uri={4}",
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
        /// 文档：http://wiki.connect.qq.com/获取用户openid_oauth2-0
        /// </summary>
        /// <param name="accessToken">用户授权时获取到的AccessToken</param>
        /// <returns>用户的OpenID</returns>
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