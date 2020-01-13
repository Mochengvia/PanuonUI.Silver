using System;
using System.Collections.Generic;
using System.Text;

namespace Panuon.UI.Silver.Internal.Utils
{
    internal static class DateTimeUtils
    {
        public static int GetDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return 7;
                default:
                    return (int)dayOfWeek;
            }
        }

        public static DateTime GetFirstDayDate(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public static DayOfWeek GetNextDayOfWeek(DayOfWeek daysOfWeek)
        {
            switch (daysOfWeek)
            {
                case DayOfWeek.Monday:
                    return DayOfWeek.Tuesday;
                case DayOfWeek.Tuesday:
                    return DayOfWeek.Wednesday;
                case DayOfWeek.Wednesday:
                    return DayOfWeek.Thursday;
                case DayOfWeek.Thursday:
                    return DayOfWeek.Friday;
                case DayOfWeek.Friday:
                    return DayOfWeek.Saturday;
                case DayOfWeek.Saturday:
                    return DayOfWeek.Sunday;
                case DayOfWeek.Sunday:
                    return DayOfWeek.Monday;
            }
            throw new NotImplementedException();
        }

        public static int GetDayInMonth(DateTime dateTime)
        {
            return DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
        }
    }
}
