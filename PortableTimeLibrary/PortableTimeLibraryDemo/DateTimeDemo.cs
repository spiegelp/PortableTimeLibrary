using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PortableTimeLibrary.Extensions;

namespace PortableTimeLibraryDemo
{
    public class DateTimeDemo
    {
        public static void Demo()
        {
            Console.WriteLine("*************** first day of week ***************");
            DateTime today = DateTime.Today;
            Console.WriteLine("first day of the week with " + today.ToString() + " is " + today.FirstDayOfWeek());

            Console.WriteLine("*************** merge day and time of two instances ***************");
            DateTime time = new DateTime(2016, 1, 1, 23, 59, 58);
            Console.WriteLine("merge day " + today.ToString() + " with time component " + time + ": " + today.MergeTime(time));
            Console.WriteLine("merge time " + time.ToString() + " with day component " + today + ": " + time.MergeDate(today));
        }
    }
}
