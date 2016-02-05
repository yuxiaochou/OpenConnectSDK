using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConnectSDK.QQ.Entities
{
    /// <summary>
    /// QQ用户信息（主要来自QQ空间）
    /// </summary>
    public class QQUserInfo
    {

        /// <summary>
        /// 返回码 
        /// </summary>
        public int ReturnCode { get; set; }
        /// <summary>
        /// 如果ret 小于 0，会有相应的错误信息提示，返回数据全部用UTF-8编码 
        /// </summary>
        public string Msg { get; set; }


        /// <summary>
        /// 用户在QQ空间的昵称。 
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 大小为30×30像素的QQ空间头像URL。
        /// </summary>
        public string FigureUrl { get; set; }


        /// <summary>
        /// 大大小为50×50像素的QQ空间头像URL。
        /// </summary>
        public string FigureUrl1 { get; set; }


        /// <summary>
        /// 大小为100×100像素的QQ空间头像URL。
        /// </summary>
        public string FigureUrl2 { get; set; }


        /// <summary>
        /// 大小为40×40像素的QQ头像URL。
        /// </summary>
        public string FigureUrlQQ1 { get; set; }


        /// <summary>
        /// 大小为100×100像素的QQ头像URL。需要注意，不是所有的用户都拥有QQ的100x100的头像，但40x40像素则是一定会有。
        /// </summary>
        public string FigureUrlQQ2 { get; set; }

        /// <summary>
        /// 性别。 如果获取不到则默认返回"男"
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 标识用户是否为黄钻用户（0：不是；1：是）。 
        /// </summary>
        public int IsVip { get; set; }


        /// <summary>
        /// 标识用户是否为黄钻用户（0：不是；1：是）。 
        /// </summary>
        public int IsYellowVip { get; set; }

        /// <summary>
        /// 标识是否为年费黄钻用户（0：不是； 1：是）
        /// </summary>
        public int IsYellowYearVip { get; set; }


        /// <summary>
        ///  黄钻等级。如果不是黄钻用户，则返回0 
        /// </summary>
        public int VipLevel { get; set; }

        /// <summary>
        ///  黄钻等级。如果不是黄钻用户，则返回0 
        /// </summary>
        public int YellowVipLevel { get; set; }

    }
}
