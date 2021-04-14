using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_3._3
{
    public static class SuperString
    {
        private static Regex EnglishRegex = new Regex(@"([A-Za-z])\w*");
        private static Regex RussianRegex = new Regex(@"([А-Яа-я])\w*");
        private static Regex NumberRegex = new Regex(@"\d");

        public static string Checker(this string str)
        {
            if (EnglishRegex.IsMatch(str) && RussianRegex.IsMatch(str) ||
                RussianRegex.IsMatch(str) && NumberRegex.IsMatch(str) ||
                EnglishRegex.IsMatch(str) && NumberRegex.IsMatch(str))
            {
                return "Mixed";
            }
            else if (EnglishRegex.IsMatch(str))
            {
                return "English";
            }
            else if (RussianRegex.IsMatch(str))
            {
                return "Russian";
            }
            else if (NumberRegex.IsMatch(str))
            {
                return "Number";
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
