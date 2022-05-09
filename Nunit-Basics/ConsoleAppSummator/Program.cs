using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSummator
{
    public class Program
    {
        static void Main(string[] args)
        {
            double sum = Summator.Sum(new double[] { 1, 2, 3, 4, 5, 6, });
            if (sum == 21)
            {
                Console.WriteLine("Test Pass");
            }
            else
            {
                Console.WriteLine("Test Fail");
            }

            double average = Summator.Average(new double[] { 5, 10, 15 });
            if (average == 10)
            {
                Console.WriteLine("Test Pass");
            }
            else
            {
                Console.WriteLine("Test Fail");
            }

        }
    }
}
