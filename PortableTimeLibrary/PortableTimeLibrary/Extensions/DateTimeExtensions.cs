using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
