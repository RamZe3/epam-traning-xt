using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task_3._1
{

    class Program


    {
        // Task 3.1.2
        static void TEXT_ANALYSIS()
        {

            string str = ReadWords();

            Console.WriteLine('\n');

            char[] separators = new char[] { ' ', ':', '.', ',', ';', '!', '?', '(', ')', '-', '"', '\n' };
            Dictionary<string, int> words = new Dictionary<string, int>();

            foreach (string item in str.Split(separators, StringSplitOptions.RemoveEmptyEntries))
            {
                str = item.ToLower();
                try
                {
                    words[str]++;
                }
                catch
                {
                    words.Add(str, 1);
                }
            }

            //OrderBy
            var words_ = words.OrderByDescending(pair => pair.Key);
            Console.WriteLine("Слово : Кол-во");
            foreach (var pair in words_.OrderByDescending(pair => pair.Value) )
            {
                Console.WriteLine(string.Format("{0} : {1}", pair.Key, pair.Value));
            }

        }

        public static string ReadWords()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Введите текст: ", "?");
            string str_ = "";

            while (str_ != "&")
            {
                var ReadKey = Console.ReadKey();
                str_ = ReadKey.KeyChar.ToString();
                if (ReadKey.Key.ToString() == "Enter")
                {
                    sb.Append("\n");
                    Console.WriteLine("");
                }
                else
                {
                    sb.Append(str_);
                }
            }

            return sb.ToString().Remove(sb.ToString().Length - 1);
        }

        // Main
        static void Main(string[] args)
        {
            TEXT_ANALYSIS();
        }
    }
}
