using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PortableTimeLibrary.Extensions;
using PortableTimeLibrary.Time;

namespace PortableTimeLibraryDemo
{
    public class MonthDemo
    {
        public static void Demo()
        {
            Console.WriteLine("*************** month names, numbers and length in days ***************");
            CultureInfo[] cultures = new CultureInfo[] { CultureInfo.GetCultureInfo("de"), CultureInfo.GetCultureInfo("en") };
            Array monthsArray = Enum.GetValues(typeof(Month));

            foreach (CultureInfo culture in cultures) {
                Console.WriteLine("*************** locale: " + culture.DisplayName + " ***************");

                for (int i = 0; i < monthsArray.Length; i++)
                {
                    Month month = (Month)monthsArray.GetValue(i);

                    Console.WriteLine(month.Name(culture) + " - " + month.ShortName(culture) + " - nr. " + month.Number() + " - " + month.Length() + " days long");
                }
            }
        }
    }
}
