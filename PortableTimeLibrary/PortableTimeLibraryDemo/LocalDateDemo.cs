using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PortableTimeLibrary.Extensions;
using PortableTimeLibrary.Time;

namespace PortableTimeLibraryDemo
{
    public class LocalDateDemo
    {
        public static void Demo()
        {
            LocalDate today = LocalDate.Today;
            LocalDate todayPlus = LocalDate.Today.AddYears(1).AddMonths(1).AddDays(1);
            LocalDate todayMinus = LocalDate.Today.AddYears(-1).AddMonths(-1).AddDays(-1);
            LocalDate today2 = LocalDate.Today;

            Console.WriteLine("*************** conversion from and to DateTime ***************");
            Console.WriteLine(DateTime.Now.ToString() + " DateTime to LocalDate: " + DateTime.Now.ToLocalDate().ToString());
            Console.WriteLine(today.ToString() + " LocalDate to DateTime: " + today.ToDateTime().ToString());

            Console.WriteLine("*************** today ***************");
            Console.WriteLine(today.ToString());

            Console.WriteLine("*************** today plus 1 year, month and day ***************");
            Console.WriteLine(todayPlus.ToString());

            Console.WriteLine("*************** today minus 1 year, month and day ***************");
            Console.WriteLine(todayMinus.ToString());

            Console.WriteLine("*************** first day of week ***************");
            Console.WriteLine(today.FirstDayOfWeek().ToString());

            Console.WriteLine("*************** comparison ***************");
            Console.WriteLine(today.ToString() + " < " + todayPlus.ToString() + ": " + (today < todayPlus));
            Console.WriteLine(today.ToString() + " > " + todayPlus.ToString() + ": " + (today > todayPlus));
            Console.WriteLine(today.ToString() + " == " + today2.ToString() + ": " + (today == today2));
            Console.WriteLine(today.ToString() + " != " + today2.ToString() + ": " + (today != today2));
        }
    }
}
