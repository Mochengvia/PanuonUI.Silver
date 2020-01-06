using System;

namespace Panuon.UI.Silver.Core
{
    public static class LongExtension
    {
        #region ToDateTime
        /// <summary>
        /// Get date time from timestamp.
        /// </summary>
        /// <param name="withMilliseconds">Include milliseconds(13 bit) or not(10 bit).</param>
        public static DateTime ToDateTime(this long timeStamp, bool withMilliseconds = true)
        {
            if (withMilliseconds)
                return TimeZoneInfo.ConvertTimeToUtc(new DateTime(1970, 1, 1)).AddMilliseconds(timeStamp);
            else
                return TimeZoneInfo.ConvertTimeToUtc(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
        }
        #endregion
    }
}
