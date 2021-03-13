using System;
using System.Text;

namespace Task_2._1
{
    // Task 2.1.1
    class CustomString
    {
        public char[] custom_string { get; set; }

        public int GetLength()
        {
            return custom_string.Length;
        }

        public CustomString()
        {
            custom_string = null;
        }

        public CustomString(char[] arr)
        {
            custom_string = arr;
        }

        public CustomString(String stringValue)
        {
            custom_string = new char[stringValue.Length];
            for (int i = 0; i < stringValue.Length; i++)
            {
                custom_string[i] = stringValue[i];
            }
        }

        public int FindByValue(char value)
        {
            for (int i = 0; i < custom_string.Length; i++)
            {
                if (custom_string[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public string ConvertToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < custom_string.Length; i++)
            {
                sb.Append(custom_string[i]);
            }
            return sb.ToString();
        }

        public void Append(string string_)
        {
            char[] strings = new char[string_.Length];
            for (int i = 0; i < string_.Length; i++)
            {
                strings[i] = string_[i];
            }
            char[] answer = new char[custom_string.Length + string_.Length + 1];
            custom_string.CopyTo(answer, 0);
            strings.CopyTo(answer, custom_string.Length);
            custom_string = answer;
        }

        public int Compare(CustomString cs)
        {
            if (custom_string.Length > cs.custom_string.Length)
            {
                return 1;
            }
            else if (custom_string.Length < cs.custom_string.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            CustomString css = new CustomString("abc a");
            Console.WriteLine(css.FindByValue('b'));
            css.Append("123");
            css.Append("1235");
            Console.WriteLine(css.ConvertToString());
        }
    }
}
