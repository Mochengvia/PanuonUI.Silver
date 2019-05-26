using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panuon.UI.Silver
{
    public static class Extends
    {
        #region String
        /// <summary>
        /// 指示该字符串是否是Null或空字符串。
        /// </summary>
        /// <summary xml:lang="en">
        /// 
        /// </summary>
        public static bool IsNullOrEmpty(this string context)
        {
            return string.IsNullOrEmpty(context);
        }
        #endregion

        #region Timestamp <-> Datetime
        public static long ToTimeStamp(this DateTime date, bool withMilliseconds = true)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1);
            if (withMilliseconds)
                return Convert.ToInt64(ts.TotalMilliseconds);
            else
                return Convert.ToInt64(ts.TotalSeconds);
        }

        public static DateTime ToDateTime(this long timeStamp, bool withMilliseconds = true)
        {
            if(withMilliseconds)
                return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddMilliseconds((long)timeStamp);
            else
                return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds((long)timeStamp);
        }
        #endregion
    }
}
