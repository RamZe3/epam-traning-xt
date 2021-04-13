using System;
using System.Threading.Tasks;
using System.Threading;

namespace Task_3._3
{
    class Program
    {
        // Task 3.3.3
        public class Buyer
        {
            public int OrderNumber { get; private set; }
            private void WaitForPizza(Pizzeria pizzeria)
            {
                // ожидание заключается в периодических вопросах о состоянии приготовления заказа
                if (pizzeria.GetOrderInformation(OrderNumber) == "Пицца  ещё не готова!")
                {
                    Console.WriteLine("Пицца  ещё не готова!");
                    Thread.Sleep(1000);
                    WaitForPizza(pizzeria);
                }
                else
                {
                    Console.WriteLine("Пицца готова!");
                }
            }

            public void OrderPizza(Pizzeria pizzeria, string nameOfPizza)
            {
                OrderNumber = pizzeria.TakeOrder(nameOfPizza);
                WaitForPizza(pizzeria);
            }

        }

        public class Pizzeria
        {
            private bool[] orderTable;
            private int currentOrderNumber 
            {

                /*get
                {
                    if (currentOrderNumber == orderTable.Length-1)
                    {
                        currentOrderNumber = 1;
                        return currentOrderNumber;
                    }
                    else
                    {
                        return currentOrderNumber;
                    }
                }

                set
                {
                    currentOrderNumber = value;
                }*/
                get; set;
            }

            public Pizzeria(int countOfOrder)
            {
                orderTable = new bool[countOfOrder];
                currentOrderNumber = 0;
            }

            public int TakeOrder(string nameOfPizza)
            {
                currentOrderNumber++;

                CookPizza(currentOrderNumber);
                return currentOrderNumber;
            }

            public string GetOrderInformation(int orderNumber)
            {
                if (orderTable[orderNumber])
                {
                    orderTable[orderNumber] = false;
                    return "Пицца готова!";
                }
                else
                {
                    return "Пицца  ещё не готова!";
                }
            }

            async private void CookPizza(int orderNumber)
            {
                await Task.Delay(3000);
                orderTable[orderNumber] = true;
            }
        }

        //Main
        static void Main(string[] args)
        {
            // пицерия работает максимально просто - пиццы готовятся по очереди
            Buyer buyer = new Buyer();
            Buyer buyer2 = new Buyer();
            Pizzeria pizzeria = new Pizzeria(100);
            buyer2.OrderPizza(pizzeria, "Пиперони");
            Thread.Sleep(1000);
            buyer.OrderPizza(pizzeria ,"Пиперони");
        }
    }
}
