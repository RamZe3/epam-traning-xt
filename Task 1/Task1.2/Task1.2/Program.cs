using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._2
{
    class Program
    {
        static void AVERAGES()
        {
            int countOfWords = 0;
            string str = Console.ReadLine();
            //string s = "wqea, asd,qwe";

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
        static void Main(string[] args)
        {
            AVERAGES();
        }
    }
}
