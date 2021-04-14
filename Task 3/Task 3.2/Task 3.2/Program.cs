using System;
using System.Collections.Generic;
using System.Collections;

namespace Task_3._2
{

    public class DynamicArray<T> : IEnumerable, IEnumerable<T>
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


        private void EnlargeArray()
        {
            T[] _array = new T[Capacity * 2];
            array.CopyTo(_array, 0);
            array = _array;
        }

        private void EnlargeArray(int size)
        {
            T[] _array = new T[Capacity + size];
            array.CopyTo(_array, 0);
            array = _array;
        }

        public void Add(T obj)
        {
            if (Length == Capacity)
            {
                EnlargeArray();
            }
            array[Length] = obj;
            Length++;
        }

        public void AddRange(ICollection<T> collection)
        {
            if (collection.Count > (Capacity - Length))
            {
                EnlargeArray(collection.Count);
            }

            foreach (var item in collection)
            {
                array[Length] = item;
                Length++;
            }
        }

        // TODO
        public bool Remove(T item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (item.ToString() == array[i].ToString())
                {
                    for (int j = i; j < Length - 1; j++)
                    {
                        array[j] = array[j + 1];
                    }
                    Length--;
                    return true;
                }
            }
            return false;
        }

        public bool Insert(int position, T item)
        {
            if (position < Length && position > 0)
            {
                if (Length == Capacity)
                {
                    EnlargeArray();
                }

                for (int i = Length; i >= position; i--)
                {
                    array[i+1] = array[i];
                }

                array[position] = item;
                Length++;

                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Вы вышли за границы коллекции");
            }
        }

        private T[] GetArrayWithValues()
        {
            T[] _array = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                _array[i] = array[i];
            }
            return _array;
        }

        public IEnumerator GetEnumerator()
        {
            return GetArrayWithValues().GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)GetArrayWithValues()).GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                try
                {
                    return array[index];
                }
                catch
                {
                    throw new ArgumentOutOfRangeException("Вы вышли за границы коллекции");
                }
            }

            set
            {
                try
                {
                    array[index] = value;
                }
                catch
                {

                    throw new ArgumentOutOfRangeException("Вы вышли за границы коллекции");
                }
            }   
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(34);
            list.Add(4);
            //list.Remove(4);

            DynamicArray<int> dynamicArray = new DynamicArray<int>(list);
            dynamicArray.Add(3);
            dynamicArray.Add(3);
            dynamicArray.AddRange(list); dynamicArray.AddRange(list);
            //dynamicArray.Add(333);
            //dynamicArray.Add(366);
            //dynamicArray.Remove(333);
            //Console.WriteLine(dynamicArray.Capacity);

            for (int i = 0; i < dynamicArray.Length; i++)
            {
                //Console.WriteLine(dynamicArray[i]);
            }
            Console.WriteLine();
            dynamicArray.Insert(1, 666);
            for (int i = 0; i < dynamicArray.Length; i++)
            {
                //Console.WriteLine(dynamicArray[i]);
            }

            foreach (var item in dynamicArray)
            {
                Console.WriteLine(item);
            }



        }
    }
}
