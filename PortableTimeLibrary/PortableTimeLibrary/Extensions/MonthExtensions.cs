using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PortableTimeLibrary.Time;

namespace PortableTimeLibrary.Extensions
{
    public static class MonthExtensions
    {
        /// <summary>
        /// The length of the month in days. A leap year for February is not considered.
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static int Length(this Month month)
        {
            return month.Length(false);
        }

        /// <summary>
        /// The length of the month in days considering a leap year for February if isLeapYear == true.
        /// </summary>
        /// <param name="month"></param>
        /// <param name="isLeapYear"></param>
        /// <returns></returns>
        public static int Length(this Month month, bool isLeapYear)
        {
            switch (month)
            {
                case Month.January:
                case Month.March:
                case Month.May:
                case Month.July:
                case Month.August:
                case Month.October:
                case Month.December:
                    return 31;

                case Month.April:
                case Month.June:
                case Month.September:
                case Month.November:
                    return 30;

                case Month.February:
                    if (isLeapYear)
                    {
                        return 29;
                    }
                    else
                    {
                        return 28;
                    }

                default:
                    throw new ArgumentException("invalid month with value " + ((int)month));
            }
        }

        /// <summary>
        /// The full name of the month in the current culture.
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static string Name(this Month month)
        {
            return month.Name(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// /// The full name of the month in the given current culture.
        /// </summary>
        /// <param name="month"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string Name(this Month month, CultureInfo culture)
        {
            return FormatMonth(month, "MMMM", culture);
        }

        /// <summary>
        /// The number of the month starting by 1 for January.
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static int Number(this Month month)
        {
            return (int)month;
        }

        /// <summary>
        /// The short name of the month (e.g. Mar for March in an English culture) in the current culture.
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static string ShortName(this Month month)
        {
            return month.ShortName(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// The short name of the month (e.g. Mar for March in an English culture) in the given current culture.
        /// </summary>
        /// <param name="month"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string ShortName(this Month month, CultureInfo culture)
        {
            return FormatMonth(month, "MMM", culture);
        }

        private static string FormatMonth(Month month, string format, CultureInfo culture)
        {
            // use an arbitrary DateTime in the given month and format it only with the full name of the month
            DateTime dateTime = new DateTime(2016, month.Number(), 1);

            return dateTime.ToString(format, culture);
        }
    }
}
