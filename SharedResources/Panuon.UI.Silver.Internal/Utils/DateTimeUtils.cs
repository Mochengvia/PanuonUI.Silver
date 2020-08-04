using System;

namespace Panuon.UI.Silver.Internal.Utils
{
    internal static class DateTimeUtils
    {
        internal static DateTime GetDate(DateTime? date)
        {
            return date == null ? DateTime.Now.Date : ((DateTime)date).Date;
        }

        internal static DateTime GetFirstDayDate(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        internal static DateTime GetFirstMonthDate(DateTime date)
        {
            return new DateTime(date.Year, 1, 1);
        }

        internal static DayOfWeek GetNextDayOfWeek(DayOfWeek daysOfWeek)
        {
            var days = (int)daysOfWeek;
            days++;
            if(days == 7)
            {
                days = 0;
            }
            return (DayOfWeek)days;
        }

        internal static int GetDayInMonth(DateTime? date)
        {
            var dateTime = GetDate(date);
            return DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
        }

        internal static DateTime VerifyDateTime(int year, int month, int day)
        {
            if(year < 0)
            {
                year = 0;
            }

            if(month > 12)
            {
                month = 12;
            }
            else if (month < 1)
            {
                month = 1;
            }

            var days = DateTime.DaysInMonth(year, month);
            if(day < 1)
            {
                day = 1;
            }
            else if(day > days)
            {
                day = days;
            }
            return new DateTime(year, month, day);
        }
    }
}
