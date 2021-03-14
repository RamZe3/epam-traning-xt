using System;
using System.Text;

namespace Task_2._1
{
    // Task 2.1.1
    class CustomString
    {
        private char[] custom_string { get; set; }
        public int Length { get => this.custom_string.Length; }

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

        override
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < custom_string.Length; i++)
            {
                sb.Append(custom_string[i]);
            }
            return sb.ToString();
        }

        public char[] ConvertToArray()
        {
            return custom_string;
        }

        public void Append(string addStr)
        {
            char[] answer = new char[custom_string.Length + addStr.Length + 1];
            char[] addStrArr = new char[addStr.Length];
            for (int i = 0; i < addStr.Length; i++)
            {
                addStrArr[i] = addStr[i];
            }
            custom_string.CopyTo(answer, 0);
            addStrArr.CopyTo(answer, custom_string.Length);
            custom_string = answer;
        }

        public void Append(CustomString cs)
        {
            char[] answer = new char[custom_string.Length + cs.Length + 1];
            custom_string.CopyTo(answer, 0);
            cs.custom_string.CopyTo(answer, custom_string.Length);
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
            // Task 2.1.1
            char[] arr = { 'd', 'e', 'f' };
            CustomString cs1 = new CustomString("abc");
            CustomString cs1 = new CustomString("abc");
            CustomString cs2 = new CustomString(arr);
            cs1.Append(cs2);
            cs1.Append("ghi");
            Console.WriteLine("ToString: {0}",cs1.ToString());
            Console.WriteLine("ConvertToArray[0]: {0}", cs1.ConvertToArray()[0]);
            Console.WriteLine("Compare: {0}", cs1.Compare(cs2));
            Console.WriteLine("Length: {0}", cs1.Length);
        }
    }
}
