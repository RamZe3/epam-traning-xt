using System;
using System.Collections.Generic;
using System.Collections;

namespace Task_3._2
{

    public class DynamicArray<T>
    {
        private T[] array;
        public int Length { get; private set; } = 0;
        public int Capacity { get => array.Length;}

        public DynamicArray()
        {
            array = new T[8];
        }

        public DynamicArray(int size)
        {
            array = new T[size];
        }

        public DynamicArray(ICollection<T> collection)
        {
            array = new T[collection.Count];

            foreach (var item in collection)
            {
                array[Length] = item;
                Length++;
            }
        }

        public void Add(T obj)
        {
            if (Length == Capacity)
            {
                // TODO
                T[] _array = new T[array.Length*2];
                array.CopyTo(_array, Length);
                array = _array;
            }
            array[Length] = obj;
            Length++;
        }

        /*public bool Remove(T item)
        {
            int index;
            for (int i = 0; i < Length; i++)
            {
                if (array[i] == item)
                {

                }
                else
                {
                    return false;
                }
            }
        }*/
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(34);
            list.Add(4);
            list.Remove(0);

            DynamicArray<int> dynamicArray = new DynamicArray<int>(list);
            Console.WriteLine(dynamicArray.Capacity);
            dynamicArray.Add(3);
            Console.WriteLine(dynamicArray.Capacity);

        }
    }
}
