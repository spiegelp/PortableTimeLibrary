using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableTimeLibraryDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MonthDemo.Demo();

            DateTimeDemo.Demo();

            LocalDateDemo.Demo();

            Console.WriteLine("\n\nPress enter to exit...");
            Console.Read();
        }
    }
}
