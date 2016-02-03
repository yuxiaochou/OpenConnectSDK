using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConnectSDK.Helpers
{
    public class ConvertHelper
    {
        public static int DefaultInt
        {
            get
            {
                return 0;
            }
        }

        public static long DefaultLong
        {
            get
            {
                return 0;
            }
        }

        public static DateTime DefaultDateTime
        {
            get
            {
                return new DateTime(1970, 1, 1);
            }
        }


        public static Guid DefaultGuid
        {
            get
            {
                return Guid.Empty;
            }
        }

        public static Decimal DefaultDecimal
        {
            get
            {
                return new Decimal(0);
            }
        }

        public static bool DefaultBool
        {
            get
            {
                return false;
            }
        }

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
        public static int ToInt(string s)
        {
            return ToInt(s, DefaultInt);
        }


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
        public static long ToLong(string s)
        {
            return ToLong(s, DefaultLong);
        }


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
        /// 默认值是1970-01-01
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string s)
        {
            return ToDateTime(s, DefaultDateTime);
        }



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


        public static Guid ToGuid(string s)
        {
            return ToGuid(s, DefaultGuid);
        }



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

        public static Decimal ToDecimal(string s)
        {
            return ToDecimal(s, DefaultDecimal);
        }


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
        /// 默认值是false
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ToBool(string s)
        {
            return ToBool(s, DefaultBool);
        }
    }

}
