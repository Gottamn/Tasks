using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ2
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = new List<int> { 2, 3, 8, -1, 0, 6 };



            if (numbers is null)
            {
                Console.WriteLine("Empty sequence");
                return;
            }

            Console.Write("Enter a number: ");

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

            //// 2.	Найти сумму всех элементов последовательности, предшествующих первому нулевому элементу.
            //// Если по какой-либо причине вычислить сумму не удается, выдать об этом сообщение с указанием причины.

            Console.WriteLine(numbers.TakeWhile(n => n != 0).Sum());


            // 3.Вставить заданное с консоли значение после элемента последовательности, расположенного до первого нулевого элемента.
            // Если вставка элементов невозможна, выдать об этом сообщение.


            var numList = numbers as List<int>;

            if (numList is null)
            {
                Console.WriteLine("Sequence is not List");
                return;
            }

            int indexOfZero = numList.FindIndex(n => n == 0);

            if (indexOfZero > -1)
            {
                numList.Insert(indexOfZero, readStr);
                Console.WriteLine(string.Join(",", numbers));
            }
            else
            {
                Console.WriteLine("There is no 0 in List");
            }
        }
    }
}

