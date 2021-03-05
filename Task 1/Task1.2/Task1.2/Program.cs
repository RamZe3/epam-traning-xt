using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._2
{
    class Program
    {
        // Task 1.2.1
        static void AVERAGES()
        {
            int countOfWords = 0;
            string str = Console.ReadLine();

            //way to split from Microsoft forum
            char[] separators = new char[] { ' ', ':', '.', ',', ';', '!', '?', '(', ')', '-', '"' };
            string[] words = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                countOfWords += word.Length;
            }

            int averageLength = countOfWords / words.Length;
            Console.WriteLine("Средняя длинна слов: {0}", averageLength);
        }

        // Task 1.2.2
        static void DOUBLER()
        {
            Console.Write("ВВОД 1: ");
            string str1 = Console.ReadLine();
            Console.Write("ВВОД 2: ");
            string str2 = Console.ReadLine();

            var sb = new StringBuilder();
            for (int i = 0; i < str1.Length; i++)
            {
                foreach(char item in str2)
                {
                    if (str1[i] == item)
                    {
                        sb.Append(str1[i], 1);
                        break;
                    }
                }
                sb.Append(str1[i], 1);
            }

            Console.WriteLine("ВЫВОД: {0}", sb.ToString());

        }

        // Task 1.2.3
        static void LOWERCASE()
        {
            int countOfWordsIsLower = 0;
            Console.Write("ВВОД: ");
            string str = Console.ReadLine();

            //way to split from Microsoft forum
            char[] separators = new char[] { ' ', ':', '.', ',', ';', '!', '?', '(', ')', '-', '"' };
            string[] words = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (Char.IsLower(word[0]))
                {
                    countOfWordsIsLower++;
                }
            }

            Console.WriteLine("ВЫВОД: {0}", countOfWordsIsLower);
        }

        // Task 1.2.4
        static void VALIDATOR()
        {
            Console.Write("ВВОД: ");
            string str = Console.ReadLine() + "AA";
            char[] endOfSentences = { '.', '?', '!' };
            var sb = new StringBuilder();
            int Length = str.Length;

            //sb.Append(Char.ToUpper(str[0]));
            for (int i = 0; i < Length; i++)
            {
                foreach (char item in endOfSentences)
                {
                    if(str[i] == item)
                    {
                        while (Char.IsPunctuation(str[i + 1]) || Char.IsSeparator(str[i + 1]) )
                        {
                            sb.Append(str[i]);
                            i++;
                        }
                        sb.Append(str[i]);
                        sb.Append(Char.ToUpper(str[i + 1]));
                        i+=2;
                    }
                }
                if (i < str.Length)
                {
                    sb.Append(str[i]);
                }
            }
            sb = sb.Remove(Length-2, 2);

           Console.WriteLine("ВЫВОД: {0}", sb.ToString());
        }

        // Main
        static void Main(string[] args)
        {
            VALIDATOR();
            
        }
    }
}
