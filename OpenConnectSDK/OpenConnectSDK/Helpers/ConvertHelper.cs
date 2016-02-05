using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConnectSDK.Helpers
{
    /// <summary>
    /// 安全类型转换帮助类
    /// </summary>
    public class ConvertHelper
    {
        /// <summary>
        /// Int型默认值
        /// </summary>
        public static int DefaultInt
        {
            get
            {
                return 0;
            }
        }
        /// <summary>
        /// Long型默认值
        /// </summary>
        public static long DefaultLong
        {
            get
            {
                return 0;
            }
        }
        /// <summary>
        /// 日期时间默认值
        /// </summary>
        public static DateTime DefaultDateTime
        {
            get
            {
                return new DateTime(1970, 1, 1);
            }
        }

        /// <summary>
        /// Guid默认值
        /// </summary>
        public static Guid DefaultGuid
        {
            get
            {
                return Guid.Empty;
            }
        }
        /// <summary>
        /// Decimal型默认值
        /// </summary>
        public static Decimal DefaultDecimal
        {
            get
            {
                return new Decimal(0);
            }
        }
        /// <summary>
        /// Bool型默认值
        /// </summary>
        public static bool DefaultBool
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 将String型转换成Int型，失败返回默认值
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt(string s, int defaultValue)
        {
            int tempInt = DefaultInt;
            if (int.TryParse(s, out tempInt))
            {
                return tempInt;
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 将String型转换成Int型，失败返回默认值
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(string s)
        {
            return ToInt(s, DefaultInt);
        }

        /// <summary>
        /// 将String型转换成Long型，失败返回默认值
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long ToLong(string s, long defaultValue)
        {
            long tempLong = DefaultInt;
            if (long.TryParse(s, out tempLong))
            {
                return tempLong;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 将String型转换成Long型，失败返回默认值
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long ToLong(string s)
        {
            return ToLong(s, DefaultLong);
        }

        /// <summary>
        /// 将String型转换成DateTime，失败返回默认值
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string s, DateTime defaultValue)
        {
            DateTime tempDate = DefaultDateTime;
            if (DateTime.TryParse(s, out tempDate))
            {
                return tempDate;
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 将String型转换成DateTime，失败返回默认值,默认值是1970-01-01
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string s)
        {
            return ToDateTime(s, DefaultDateTime);
        }


        /// <summary>
        /// 将String型转换成Guid，失败返回默认值
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Guid ToGuid(string s, Guid defaultValue)
        {
            Guid tempGuid = DefaultGuid;
            if (Guid.TryParse(s, out tempGuid))
            {
                return tempGuid;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 将String型转换成Guid，失败返回默认值，默认值是Guid.Empty
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Guid ToGuid(string s)
        {
            return ToGuid(s, DefaultGuid);
        }


        /// <summary>
        /// 将String型转换成Decimal，失败返回默认值
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Decimal ToDecimal(string s, Decimal defaultValue)
        {
            Decimal tempDecimal = DefaultDecimal;
            if (Decimal.TryParse(s, out tempDecimal))
            {
                return tempDecimal;
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 将String型转换成Decimal，失败返回默认值
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Decimal ToDecimal(string s)
        {
            return ToDecimal(s, DefaultDecimal);
        }

        /// <summary>
        /// 将String型转换成Bool型，失败返回默认值
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool ToBool(string s, bool defaultValue)
        {
            bool tempBool = DefaultBool;
            if (Boolean.TryParse(s, out tempBool))
            {
                return tempBool;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 将String型转换成Bool型，失败返回默认值，默认值是false
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ToBool(string s)
        {
            return ToBool(s, DefaultBool);
        }
    }

}
