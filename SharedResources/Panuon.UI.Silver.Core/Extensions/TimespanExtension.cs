using System;

namespace Panuon.UI.Silver.Core
{
    public static class TimespanExtension
    {
        #region Months
        /// <summary>
        /// Calculate the number of months before the specified date.
        /// </summary>
        /// <param name="endDate">Specified date.</param>
        public static int Months(this TimeSpan timeSpan, DateTime endDateTime)
        {
            var months = 0;
            var totalDays = timeSpan.TotalDays;
            var dateTime = endDateTime;
            var dayInLastMonth = dateTime.Subtract(dateTime.AddMonths(-1)).Days;
            var days = dayInLastMonth;
            dateTime = dateTime.AddMonths(-1);

            while (totalDays >= days)
            {
                months++;
                if (totalDays == days)
                    return months;
                dayInLastMonth = dateTime.Subtract(dateTime.AddMonths(-1)).Days;
                if ((totalDays - days) < dayInLastMonth)
                    break;
                days += dayInLastMonth;
                dateTime = dateTime.AddMonths(-1);
            }

            return months;
        }
        #endregion

        #region TotalMonths
        /// <summary>
        /// Calculate the total number of months before the specified date.
        /// </summary>
        /// <param name="endDate">Specified date.</param>
        public static double TotalMonths(this TimeSpan timeSpan, DateTime endDateTime)
        {
            var months = 0.0;
            var totalDays = timeSpan.TotalDays;
            var dateTime = endDateTime;
            var dayInLastMonth = dateTime.Subtract(dateTime.AddMonths(-1)).Days;
            var days = dayInLastMonth;
            dateTime = dateTime.AddMonths(-1);

            while (totalDays >= days)
            {
                months++;
                if (totalDays == days)
                    return months;
                dayInLastMonth = dateTime.Subtract(dateTime.AddMonths(-1)).Days;
                if ((totalDays - days) < dayInLastMonth)
                    break;
                days += dayInLastMonth;
                dateTime = dateTime.AddMonths(-1);
            }

            if (months == 0)
                months += (totalDays / dayInLastMonth);
            else if (totalDays != days)
                months += ((totalDays - days) / dayInLastMonth);
            return months;
        }
        #endregion
    }
}
