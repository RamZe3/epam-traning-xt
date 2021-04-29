using System;
using System.Threading;

namespace Task_3._3
{
    class Program
    {
        // Task 3.3.3
        static int ValueXThree(int value)
        {
            return value*3;
        }

        //Main
        static void Main(string[] args)
        {
            // пицерия работает максимально просто - пиццы готовятся по очереди
            Buyer buyer1 = new Buyer();
            Buyer buyer2 = new Buyer();
            Pizzeria pizzeria = new Pizzeria(100);
            buyer2.OrderPizza(pizzeria, "Пепперони");
            Console.WriteLine(pizzeria.currentOrderNumber + " - Номер заказа\n");
            Thread.Sleep(2000);
            buyer1.OrderPizza(pizzeria ,"4 сыра");
            Console.WriteLine(pizzeria.currentOrderNumber + " - Номер заказа\n");
            


            int[] array = { 1, 2, 3, 4 , 3};

            array.SuperForeach(x => x * 2);
            array.SuperForeach(ValueXThree);

            Console.WriteLine(array.SuperSum());

            Console.WriteLine(array.MostRepeated());
        }
    }
}
