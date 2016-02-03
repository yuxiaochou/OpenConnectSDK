using Newtonsoft.Json.Linq;
using OpenConnectSDK.Helpers;
using OpenConnectSDK.QQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConnectSDK.QQ.Api
{
    public class QQUserApi
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="accessToken"></param>
        /// <param name="openID"></param>
        /// <returns></returns>
        public static QQUserInfo GetUserInfo(string appId, string accessToken, string openID)
        {
            var url =
               string.Format("https://graph.qq.com/user/get_user_info?access_token={0}&oauth_consumer_key={1}&openid={2}&format=json",
               accessToken, appId, openID);

            /* PC网站接入时，获取到用户OpenID，返回包如下：
             * callback( {"client_id":"YOUR_APPID","openid":"YOUR_OPENID"} ); 
             * openid是此网站上唯一对应用户身份的标识，网站可将此ID进行存储便于用户下次登录时辨识其身份，或将其与用户在网站上的原有账号进行绑定。
             */

            string response = WebClientHelper.GetMethod(url);
            JObject jsonObj = JObject.Parse(response);

            QQUserInfo userInfo = new QQUserInfo
            {
                ReturnCode = ConvertHelper.ToInt(jsonObj["ret"].ToString()),
                Msg = jsonObj["msg"].ToString(),
            };


            if (userInfo.ReturnCode != 0)
            {
                return userInfo;
            }

            userInfo.NickName = jsonObj["nickname"].ToString();
            userInfo.FigureUrl = jsonObj["figureurl"].ToString();
            userInfo.FigureUrl1 = jsonObj["figureurl_1"].ToString();
            userInfo.FigureUrl2 = jsonObj["figureurl_2"].ToString();
            userInfo.FigureUrlQQ1 = jsonObj["figureurl_qq_1"].ToString();
            userInfo.FigureUrlQQ2 = jsonObj["figureurl_qq_2"].ToString();
            userInfo.Gender = jsonObj["gender"].ToString();
            userInfo.IsYellowVip = ConvertHelper.ToInt(jsonObj["is_yellow_vip"].ToString());
            userInfo.IsVip = ConvertHelper.ToInt(jsonObj["vip"].ToString());
            userInfo.YellowVipLevel = ConvertHelper.ToInt(jsonObj["yellow_vip_level"].ToString());
            userInfo.VipLevel = ConvertHelper.ToInt(jsonObj["level"].ToString());
            userInfo.IsYellowYearVip = ConvertHelper.ToInt(jsonObj["is_yellow_year_vip"].ToString());
            return userInfo;

        }

    }
}
