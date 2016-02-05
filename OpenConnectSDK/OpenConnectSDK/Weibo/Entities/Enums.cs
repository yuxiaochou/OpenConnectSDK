using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConnectSDK.Weibo.Entities
{
    /// <summary>
    /// 授权登录页面展示的样式
    /// </summary>
    public enum WeiboAuthorizeDisplay
    {
        /// <summary>
        /// 默认的授权页面，适用于web浏览器。
        /// </summary>
        Default,
        /// <summary>
        /// 移动终端的授权页面，适用于支持html5的手机。注：使用此版授权页请用 https://open.weibo.cn/oauth2/authorize 授权接口
        /// </summary>
        mobile,
        /// <summary>
        /// wap版授权页面，适用于非智能手机。
        /// </summary>
        wap,
        /// <summary>
        /// 客户端版本授权页面，适用于PC桌面应用。
        /// </summary>
        client,
        /// <summary>
        /// 默认的站内应用授权页，授权后不返回access_token，只刷新站内应用父框架。
        /// </summary>
        apponweibo,
    }

    /// <summary>
    /// 微博授权页语言
    /// </summary>
    public enum Language
    {
        /// <summary>
        /// 中文简体
        /// </summary>
        zh_CN,
        /// <summary>
        /// 英文（英文版测试中，开发者任何意见可反馈至 @微博API）
        /// </summary>
        en
    }
}
