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
            int.TryParse(str, out a);

            Console.WriteLine("Введите b: ");
            str = Console.ReadLine();
            int.TryParse(str, out b);

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
            Console.WriteLine("Введите N: ");
            int N = int.Parse(Console.ReadLine());

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
            Console.WriteLine("Введите N: ");
            int N = int.Parse(Console.ReadLine());

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
            Console.WriteLine("Введите N: ");
            int N = int.Parse(Console.ReadLine());

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

        // Task 1.1.6
        static void FONT_ADJUSTMENT()
        {
            string[] labelOptions = new string[4];
            int input; string str;

            while (true)
            {
                Console.WriteLine("Параметры надписи: {0}", showLabelOptions(labelOptions));
                Console.WriteLine("Введите: \n" +
                    "     1: bold\n     2: italic\n     3: underline");

                str = Console.ReadLine();
                input = int.Parse(str);
                if (input == 1)
                {
                    labelOptions = arrayCheck(labelOptions, "bold");
                }
                else if (input == 2)
                {
                    labelOptions = arrayCheck(labelOptions, "italic");
                }
                else if (input == 3)
                {
                    labelOptions = arrayCheck(labelOptions, "underline");
                }
            }
        }

        static string showLabelOptions(string[] labelOptions)
        {
            string str = "";

            foreach (string option in labelOptions)
            {
                if (option != null)
                {
                    str += option + ",";
                }
            }

            if (str == "")
            {
                return "None";
            }

            return str.Remove(str.Length - 1);
        }
        

        static string[] arrayCheck(string[] labelOptions, string soughtOption)
        {
            string[] answer = new string[4];
            int count = 0;
            bool soughtOptionInArr = false;
            foreach (string labelOption in labelOptions)
            {
                if (labelOption == null)
                {
                    break;
                }
                else if (labelOption != soughtOption)
                {
                    answer[count] = labelOption;
                    count++;
                }
                else
                {
                    soughtOptionInArr = true;
                }
            }

            if (soughtOptionInArr == false)
            {
                answer[count] = soughtOption;
            }

            return answer;
        }

        // Task 1.1.7
        static void ARRAY_PROCESSING()
        {
            int[] arr = new int[20];
            Random r = new Random();

            for (int i = 0; i < 20; i++)
            {
                arr[i] = r.Next(100);
            }

            arr = sortArr(arr);

            Console.WriteLine("Min: {0}", findMin(arr));
            Console.WriteLine("Max: {0}", findMax(arr));
            Console.WriteLine("Arr values:");

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("{0}: {1}", i, arr[i]);
            }
        }

        static int findMax(int[] arr)
        {
            int max = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        static int findMin(int[] arr)
        {
            int min = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return min;
        }

        static int[] sortArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length -1; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int per;
                        per = arr[i];
                        arr[i] = arr[j];
                        arr[j] = per;
                    }
                }
            }
            return arr;
        }

        // Task 1.1.8

        static void NO_POSITIVE()
        {
            int[,,] arr = new int[3, 3, 3];
            Random r = new Random();

            // заполнение массива случайными числами
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        arr[i, j, k] = r.Next(-100, 100);
                    }
                }
            }

            // поиск значений >0
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (arr[i, j, k] > 0)
                        {
                            arr[i, j, k] = 0;
                        }
                    }
                }
            }

            // вывод массива
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Console.WriteLine("[{0},{1},{2}]: {3}", i, j, k, arr[i, j, k]);
                    }
                }
            }
        }

        // Task 1.1.9

        static void NON_NEGATIVE_SUM()
        {
            int[] arr = new int[10];
            Random r = new Random();
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                arr[i] = r.Next(-10,10);
            }

            Console.WriteLine("Arr: ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}: {1}", i, arr[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                if (arr[i] > 0)
                {
                    sum += arr[i];
                }
            }

            Console.WriteLine("sum = {0}", sum);
        }

        // Task 1.1.10

        static void D_ARRAY()
        {
            int len = 3;
            int sum = 0;
            int[,] arr = new int[len, len];
            Random r = new Random();

            Console.WriteLine("Arr: ");
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    arr[i, j] = r.Next(10);
                    Console.WriteLine("[{0}, {1}]: {2}", i, j , arr[i,j]);
                }
            }

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += arr[i, j];
                    }
                }
            }

            Console.WriteLine("Sum = {0}", sum);
        }

        // Main
        static void Main(string[] args)
        {
            X_MAS_TREE();
        }

    }
}
