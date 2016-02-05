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
    /// <summary>
    /// 微博OAuth2授权Api
    /// </summary>
    public class WeiboOAuthApi
    {
        /// <summary>
        /// 获取授权地址
        /// 文档：http://open.weibo.com/wiki/Oauth2/authorize
        /// </summary>
        /// <param name="appId">申请应用时分配的AppKey</param>
        /// <param name="redirectUrl">授权回调地址</param>
        /// <param name="state">用于保持请求和回调的状态，在回调时，会在Query Parameter中回传该参数</param>
        /// <param name="scope">申请scope权限所需参数，可一次申请多个scope权限，用逗号分隔</param>
        /// <param name="display">授权页面的终端类型</param>
        /// <param name="forceLogin">是否强制用户重新登录，true：是，false：否。默认false。</param>
        /// <param name="language">授权页语言，缺省为中文简体版，en为英文版</param>
        /// <returns>授权地址</returns>
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
        /// 文档：http://open.weibo.com/wiki/OAuth2/access_token
        /// </summary>
        /// <param name="appId">申请应用时分配的AppKey。</param>
        /// <param name="secret">申请应用时分配的AppSecret。</param>
        /// <param name="redirectUrl">回调地址，需需与注册应用里的回调地址一致。</param>
        /// <param name="code">调用authorize获得的code值。</param>
        /// <param name="grantType">请求的类型，填写authorization_code</param>
        /// <returns>微博验证票据</returns>
        public static WeiboOAuthToken GetAccessToken(string appId, string secret, string redirectUrl, string code, string grantType = "authorization_code")
        {
            var url =
                "https://api.weibo.com/oauth2/access_token";

            string strPostData = string.Format("client_id={0}&client_secret={1}&code={2}&grant_type={3}&redirect_uri={4}",
                                appId, secret, code, grantType, HttpUtility.UrlEncode(redirectUrl));

            /* 如果成功返回，即可在返回包中获取到Access Token。
             * 返回如下字符串：access_token=FE04************************CCE2&expires_in=7776000
             * expires_in是该access token的有效期，单位为秒。
             */

            string response = WebClientHelper.PostMethod(url, strPostData);

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
