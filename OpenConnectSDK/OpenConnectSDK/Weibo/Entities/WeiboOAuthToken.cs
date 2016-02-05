using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConnectSDK.Weibo.Entities
{
    /// <summary>
    /// 微博OAuth2验证票据
    /// </summary>
    public class WeiboOAuthToken
    {
        /// <summary>
        /// AccessToken
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string UID { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public int ExpiresIn { get; set; }
    }
}
