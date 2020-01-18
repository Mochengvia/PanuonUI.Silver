using System;

namespace Panuon.UI.Silver.Core
{
    public static class DateTimeExtension
    {
        #region ToTimestamp
        /// <summary>
        /// Get timestamp of date time.
        /// </summary>
        /// <param name="withMilliseconds">Include milliseconds(13 bit) or not(10 bit).</param>
        public static long ToTimestamp(this DateTime date, bool withMilliseconds = true)
        {
            var timeSpan = date.Subtract(new DateTime(1970, 1, 1));
            if (withMilliseconds)
                return Convert.ToInt64(timeSpan.TotalMilliseconds);
            else
                return Convert.ToInt64(timeSpan.TotalSeconds);
        }
        #endregion

        #region Time
        public static DateTime Time(this DateTime dateTime)
        {
            return new DateTime(1, 1, 1, dateTime.Hour, dateTime.Minute, dateTime.Second);
        }

        #endregion
    }
}
