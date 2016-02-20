using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PortableTimeLibrary.Time;

namespace PortableTimeLibrary.Extensions
{
    /// <summary>
    /// Contains common extension methods for the DateTime class.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// The first day of the week of the given dateTime. The first day is taken by the current culture.
        /// </summary>
        /// <param name="dateTime">a DateTime in the week</param>
        /// <returns></returns>
        public static DateTime FirstDayOfWeek(this DateTime dateTime)
        {
            return dateTime.FirstDayOfWeek(CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
        }

        /// <summary>
        /// The first day of the week of the given dateTime considering firstDay as the first day of the week.
        /// </summary>
        /// <param name="dateTime">a DateTime in the week</param>
        /// <param name="firstDay">the day considered as the first day of the week</param>
        /// <returns></returns>
        public static DateTime FirstDayOfWeek(this DateTime dateTime, DayOfWeek firstDay)
        {
            DateTime dt = dateTime.Date;

            while (dt.DayOfWeek != firstDay)
            {
                dt = dt.AddDays(-1);
            }

            return dt.Date;
        }

        /// <summary>
        /// Merges the date with the time of this DateTime.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime MergeDate(this DateTime dateTime, DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond, dateTime.Kind);
        }

        /// <summary>
        /// Merges the time with the date of this DateTime.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime MergeTime(this DateTime dateTime, DateTime time)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, time.Hour, time.Minute, time.Second, time.Millisecond, dateTime.Kind);
        }

        /// <summary>
        /// Creates a new LocalDate out of this DateTime.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static LocalDate ToLocalDate(this DateTime dateTime)
        {
            return new LocalDate(dateTime.Year, dateTime.Month, dateTime.Day);
        }
    }
}
