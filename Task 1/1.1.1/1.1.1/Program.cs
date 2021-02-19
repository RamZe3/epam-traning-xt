using System;

namespace _1._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            int a, b;

            Console.WriteLine("Введите a: ");
            str = Console.ReadLine();
            a = int.Parse(str);

            Console.WriteLine("Введите b: ");
            str = Console.ReadLine();
            b = int.Parse(str);

            if (a > 0 && b > 0)
            {
                Console.WriteLine("Площадь равна: " + (a * b));
            }
            else
            {
                Console.WriteLine("Введены некорректные значения!");
            }
        }
    }
}
