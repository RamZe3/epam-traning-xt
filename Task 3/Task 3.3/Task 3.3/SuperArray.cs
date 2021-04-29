using System;
using System.Linq;

namespace Task_3._3
{
    public static class SuperIntArray
    {
        public static void SuperForeach<T>(this T[] array, Func<T, T> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func.Invoke(array[i]);
            }
        }

        public static int SuperSum(this int[] array)
        {
            return array.Sum();
        }

        public static double SuperSum(this double[] array)
        {
            return array.Sum();
        }

        public static double SuperAverage(this int[] array)
        {
            return array.Average();
        }

        public static double SuperAverage(this double[] array)
        {
            return array.Average();
        }

        public static int MostRepeated(this int[] array)
        {
            return array.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
        }

        public static double MostRepeated(this double[] array)
        {
            return array.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
        }
    }

}

