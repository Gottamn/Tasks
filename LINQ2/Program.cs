using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ2
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = new int[] {2, 3, 8, -1, 0, 6 };

            // 1.	Проверить, есть ли в последовательности элементы больше чем заданное с консоли значение.

            if (int.TryParse(Console.ReadLine(), out var readStr))
            {
                if (numbers?.Any(n => n > readStr) ?? false)
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

            // 2.	Найти сумму всех элементов последовательности, предшествующих первому нулевому элементу.
            // Если по какой-либо причине вычислить сумму не удается, выдать об этом сообщение с указанием причины.

            if (numbers == null)
            {
                Console.WriteLine("Empty sequence");
            }
            else
            {
                Console.WriteLine(numbers.TakeWhile(n => n != 0).Sum()); 
            }

        }
    }
}
