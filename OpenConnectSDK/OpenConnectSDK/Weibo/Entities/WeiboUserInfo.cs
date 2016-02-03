using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConnectSDK.Weibo.Entities
{
    /// <summary>
    /// 用户信息（不包含最近一条微博）
    /// </summary>
    public class WeiboUserInfo
    {
        /// <summary>
        /// 用户UID
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string ScreenName { get; set; }
        /// <summary>
        /// 友好显示名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户所在省级ID
        /// </summary>
        public int Province { get; set; }
        /// <summary>
        /// 用户所在城市ID
        /// </summary>
        public int City { get; set; }
        /// <summary>
        /// 用户所在地
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 用户个人描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 用户博客地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 用户头像地址（中图），50×50像素
        /// </summary>
        public string ProfileImageUrl { get; set; }
        /// <summary>
        /// 用户的微博统一URL地址
        /// </summary>
        public string ProfileUrl { get; set; }
        /// <summary>
        /// 用户的个性化域名
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// 用户的微号
        /// </summary>
        public string WeiHao { get; set; }
        /// <summary>
        /// 性别，m：男、f：女、n：未知
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 粉丝数
        /// </summary>
        public int FollowersCount { get; set; }
        /// <summary>
        /// 关注数
        /// </summary>
        public int FriendsCount { get; set; }
        /// <summary>
        /// 微博数
        /// </summary>
        public int StatusesCount { get; set; }
        /// <summary>
        /// 收藏数
        /// </summary>
        public int FavouritesCount { get; set; }
        /// <summary>
        /// 用户创建（注册）时间
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// 暂未支持
        /// </summary>
        public bool Following { get; set; }
        /// <summary>
        /// 是否允许所有人给我发私信，true：是，false：否
        /// </summary>
        public bool AllowAllActMsg { get; set; }
        /// <summary>
        /// 是否允许标识用户的地理位置，true：是，false：否
        /// </summary>
        public bool GeoEnabled { get; set; }
        /// <summary>
        /// 是否是微博认证用户，即加V用户，true：是，false：否
        /// </summary>
        public bool Verified { get; set; }
        /// <summary>
        /// 暂未支持
        /// </summary>
        public int VerifiedType { get; set; }
        /// <summary>
        /// 用户备注信息，只有在查询用户关系时才返回此字段
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 是否允许所有人对我的微博进行评论，true：是，false：否
        /// </summary>
        public bool AllowAllComment { get; set; }
        /// <summary>
        /// 用户头像地址（大图），180×180像素
        /// </summary>
        public string AvatarLarge { get; set; }
        /// <summary>
        /// 用户头像地址（高清），高清头像原图
        /// </summary>
        public string AvatarHd { get; set; }
        /// <summary>
        /// 认证原因
        /// </summary>
        public string VerifiedReason { get; set; }
        /// <summary>
        /// 该用户是否关注当前登录用户，true：是，false：否
        /// </summary>
        public bool FollowMe { get; set; }
        /// <summary>
        /// 用户的在线状态，0：不在线、1：在线
        /// </summary>
        public int OnlineStatus { get; set; }
        /// <summary>
        /// 用户的互粉数
        /// </summary>
        public int BiFollowersCount { get; set; }
        /// <summary>
        /// 用户当前的语言版本，zh-cn：简体中文，zh-tw：繁体中文，en：英语
        /// </summary>
        public string Lang { get; set; }
    }
}
