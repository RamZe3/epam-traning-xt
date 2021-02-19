﻿using System;

namespace _1._1._1
{
    class Program
    {
        // Task 1.1.1
        static void RECTANGLE()
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

        // Task 1.1.2
        static void TRIANGLE()
        {
            int N;
            string str;
            Console.WriteLine("Введите N: ");
            str = Console.ReadLine();
            N = int.Parse(str);

            string answer = "*";
            Console.WriteLine("Ответ:");

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(answer);
                answer += "*";
            }

        }

        static void ANOTHER_TRIANGLE()
        {
            int N;
            string str;
            Console.WriteLine("Введите N: ");
            str = Console.ReadLine();
            N = int.Parse(str);

            string leftSide, center;
            int countOfStar  = 1;
            for (int i = 1; i <= N; i++)
            {
                leftSide = new string(' ', N - i);
                center = new string('*', countOfStar);
                Console.WriteLine(leftSide + center);
                countOfStar += 2;
            }
        }

        static void Main(string[] args)
        {
            ANOTHER_TRIANGLE();
        }

    }
}