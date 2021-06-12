using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ2
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = new int[] { 2, 3, 8, -1, 0, 6 };

            // 1.	Проверить, есть ли в последовательности элементы больше чем заданное с консоли значение.

            if (int.TryParse(Console.ReadLine(), out var readStr))
            {
                if (numbers.Any(n => n > readStr))
                {
                    Console.WriteLine("Ok");
                }
                else
                {
                    Console.WriteLine("Not ok");
                }
            }
            else
            {
                Console.WriteLine("Incorrect value");
            }




        }
    }
}
