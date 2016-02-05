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
    /// 微博用户Api
    /// </summary>
    public class WeiboUserApi
    {
        /// <summary>
        /// 获取用户信息(参数uid与screen_name二者必选其一，且只能选其一)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="uid"></param>
        /// <param name="screenName"></param>
        /// <returns></returns>
        public static WeiboUserInfo GetUserInfo(string accessToken, long uid, string screenName = "")
        {
            var url =
               string.Format("https://api.weibo.com/2/users/show.json?access_token={0}&uid={1}",
               accessToken, uid);


            if (uid != 0)
            {
                url += "&uid=" + uid;
            }
            else if (!string.IsNullOrEmpty(screenName))
            {
                url += "&screen_name=" + HttpUtility.UrlEncode(screenName);
            }

            /* 参数uid与screen_name二者必选其一，且只能选其一；
             * 接口升级后，对未授权本应用的uid，将无法获取其个人简介、认证原因、粉丝数、关注数、微博数及最近一条微博内容。
             */

            string response = WebClientHelper.GetMethod(url);
            JObject jsonObj = JObject.Parse(response);

            WeiboUserInfo userInfo = new WeiboUserInfo
            {
                ID = ConvertHelper.ToLong(jsonObj["id"].ToString()),
                Url = jsonObj["url"].ToString(),
                ProfileImageUrl = jsonObj["profile_image_url"].ToString(),
                Domain = jsonObj["domain"].ToString(),

            };


            if (jsonObj["screen_name"] != null)
            {
                userInfo.ScreenName = jsonObj["screen_name"].ToString();
            }
            if (jsonObj["name"] != null)
            {
                userInfo.Name = jsonObj["name"].ToString();
            }
            if (jsonObj["province"] != null)
            {
                userInfo.Province = ConvertHelper.ToInt(jsonObj["province"].ToString());
            }
            if (jsonObj["city"] != null)
            {
                userInfo.City = ConvertHelper.ToInt(jsonObj["city"].ToString());
            }
            if (jsonObj["location"] != null)
            {
                userInfo.Location = jsonObj["location"].ToString();
            }
            if (jsonObj["description"] != null)
            {
                userInfo.Description = jsonObj["description"].ToString();
            }
            if (jsonObj["url"] != null)
            {
                userInfo.Url = jsonObj["url"].ToString();
            }
            if (jsonObj["profile_image_url"] != null)
            {
                userInfo.ProfileImageUrl = jsonObj["profile_image_url"].ToString();
            }
            if (jsonObj["profile_url"] != null)
            {
                userInfo.ProfileUrl = jsonObj["profile_url"].ToString();
            }
            if (jsonObj["domain"] != null)
            {
                userInfo.Domain = jsonObj["domain"].ToString();
            }
            if (jsonObj["weihao"] != null)
            {
                userInfo.WeiHao = jsonObj["weihao"].ToString();
            }
            if (jsonObj["gender"] != null)
            {
                userInfo.Gender = jsonObj["gender"].ToString();
            }
            if (jsonObj["followers_count"] != null)
            {
                userInfo.FollowersCount = ConvertHelper.ToInt(jsonObj["followers_count"].ToString());
            }
            if (jsonObj["friends_count"] != null)
            {
                userInfo.FriendsCount = ConvertHelper.ToInt(jsonObj["friends_count"].ToString());
            }
            if (jsonObj["statuses_count"] != null)
            {
                userInfo.StatusesCount = ConvertHelper.ToInt(jsonObj["statuses_count"].ToString());
            }
            if (jsonObj["favourites_count"] != null)
            {
                userInfo.FavouritesCount = ConvertHelper.ToInt(jsonObj["favourites_count"].ToString());
            }
            if (jsonObj["created_at"] != null)
            {
                userInfo.CreatedAt = ConvertHelper.ToDateTime(jsonObj["created_at"].ToString());
            }
            if (jsonObj["following"] != null)
            {
                userInfo.Following = ConvertHelper.ToBool(jsonObj["following"].ToString());
            }
            if (jsonObj["allow_all_act_msg"] != null)
            {
                userInfo.AllowAllActMsg = ConvertHelper.ToBool(jsonObj["allow_all_act_msg"].ToString());
            }
            if (jsonObj["geo_enabled"] != null)
            {
                userInfo.GeoEnabled = ConvertHelper.ToBool(jsonObj["geo_enabled"].ToString());
            }
            if (jsonObj["verified"] != null)
            {
                userInfo.Verified = ConvertHelper.ToBool(jsonObj["verified"].ToString());
            }
            if (jsonObj["verified_type"] != null)
            {
                userInfo.VerifiedType = ConvertHelper.ToInt(jsonObj["verified_type"].ToString());
            }
            if (jsonObj["remark"] != null)
            {
                userInfo.Remark = jsonObj["remark"].ToString();
            }
            if (jsonObj["allow_all_comment"] != null)
            {
                userInfo.AllowAllComment = ConvertHelper.ToBool(jsonObj["allow_all_comment"].ToString());
            }
            if (jsonObj["avatar_large"] != null)
            {
                userInfo.AvatarLarge = jsonObj["avatar_large"].ToString();
            }
            if (jsonObj["avatar_hd"] != null)
            {
                userInfo.AvatarHd = jsonObj["avatar_hd"].ToString();
            }
            if (jsonObj["verified_reason"] != null)
            {
                userInfo.VerifiedReason = jsonObj["verified_reason"].ToString();
            }
            if (jsonObj["follow_me"] != null)
            {
                userInfo.FollowMe = ConvertHelper.ToBool(jsonObj["follow_me"].ToString());
            }
            if (jsonObj["online_status"] != null)
            {
                userInfo.OnlineStatus = ConvertHelper.ToInt(jsonObj["online_status"].ToString());
            }
            if (jsonObj["bi_followers_count"] != null)
            {
                userInfo.BiFollowersCount = ConvertHelper.ToInt(jsonObj["bi_followers_count"].ToString());
            }
            if (jsonObj["lang"] != null)
            {
                userInfo.Lang = jsonObj["lang"].ToString();
            }
            return userInfo;

        }

    }
}
