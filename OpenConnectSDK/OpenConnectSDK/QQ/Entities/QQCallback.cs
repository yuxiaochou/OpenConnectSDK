using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConnectSDK.QQ.Entities
{
    /// <summary>
    /// QQ返回OpenID的数据结构
    /// </summary>
    public class QQCallback
    {
        /// <summary>
        /// AppID
        /// </summary>
        public string AppID { get; set; }

        /// <summary>
        /// OpenID
        /// </summary>
        public string OpenId { get; set; }

    }
}
