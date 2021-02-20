using System;

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

        // Task 1.1.3
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

        // Task 1.1.4
        static void X_MAS_TREE()
        {
            int N;
            string str;
            Console.WriteLine("Введите N: ");
            str = Console.ReadLine();
            N = int.Parse(str);

            string leftSide, center;
            int countOfStar, rowsInTriangles;
            for (int j = 1; j <= N; j++)
            {
                countOfStar = 1;
                rowsInTriangles = j;
                for (int i = 1; i <= rowsInTriangles; i++)
                {
                    leftSide = new string(' ', N - i);
                    center = new string('*', countOfStar);
                    Console.WriteLine(leftSide + center);
                    countOfStar += 2;
                }
            }
        }

        // Task 1.1.5
        static void SUM_OF_NUMBERS()
        {
            int sum = 0;
            for (int i = 1; i < 1000; i++)
            {
                if (i %3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine("Сумма равна: {0}", sum);

        }

        static void Main(string[] args)
        {
            SUM_OF_NUMBERS();
        }

    }
}
