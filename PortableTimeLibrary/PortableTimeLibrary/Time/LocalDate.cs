using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PortableTimeLibrary.Extensions;

namespace PortableTimeLibrary.Time
{
    /// <summary>
    /// A struct to represent a date without any time or timezone information. It relies on the .NET DateTime API for operations.
    /// </summary>
    public struct LocalDate
    {
        private int m_year;
        private Month m_month;
        private int m_day;

        /// <summary>
        /// The format string according to the ISO 8601 date format (example output: 2016-02-20).
        /// </summary>
        public static string IsoDateFormat
        {
            get
            {
                return "yyyy-MM-dd";
            }
        }

        /// <summary>
        /// Creates a new LocalDate with the given year, month and day.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        public LocalDate(int year, int month, int day) : this(year, (Month)month, day) { }

        /// <summary>
        /// Creates a new LocalDate with the given year, month and day.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        public LocalDate(int year, Month month, int day)
        {
            int monthNumber = month.Number();

            if (monthNumber < 1 || monthNumber > 12)
            {
                throw new ArgumentOutOfRangeException("month", "invalid month with number " + ((int)month));
            }

            if (day < 1)
            {
                throw new ArgumentOutOfRangeException("day", "day must be at least 1");
            }

            int monthLength = month.Length(DateTime.IsLeapYear(year));

            if (day > monthLength)
            {
                throw new ArgumentOutOfRangeException("day", month.Name() + " " + year + " has only " + monthLength + " days");
            }

            m_year = year;
            m_month = month;
            m_day = day;
        }

        /// <summary>
        /// Adds the number of days to this LocalDate and returns a new instance.
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public LocalDate AddDays(int days)
        {
            return ToDateTime().AddDays(days).ToLocalDate();
        }

        /// <summary>
        /// Adds the number of months to this LocalDate and returns a new instance.
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public LocalDate AddMonths(int months)
        {
            return ToDateTime().AddMonths(months).ToLocalDate();
        }

        /// <summary>
        /// Adds the number of years to this LocalDate and returns a new instance.
        /// </summary>
        /// <param name="years"></param>
        /// <returns></returns>
        public LocalDate AddYears(int years)
        {
            return ToDateTime().AddYears(years).ToLocalDate();
        }

        /// <summary>
        /// Returns a DateTime with this LocalDate at midnight.
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime()
        {
            return new DateTime(m_year, m_month.Number(), m_day, 0, 0, 0, 0);
        }

        public override string ToString()
        {
            return ToString(IsoDateFormat);
        }

        public string ToString(string format)
        {
            return ToDateTime().ToString(format);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return ToDateTime().ToString(format, formatProvider);
        }

        public static bool operator <(LocalDate localDate1, LocalDate localDate2)
        {
            return localDate1.ToDateTime() < localDate2.ToDateTime();
        }

        public static bool operator >(LocalDate localDate1, LocalDate localDate2)
        {
            return localDate1.ToDateTime() > localDate2.ToDateTime();
        }

        public static bool operator <=(LocalDate localDate1, LocalDate localDate2)
        {
            return localDate1.ToDateTime() <= localDate2.ToDateTime();
        }

        public static bool operator >=(LocalDate localDate1, LocalDate localDate2)
        {
            return localDate1.ToDateTime() >= localDate2.ToDateTime();
        }
    }
}
