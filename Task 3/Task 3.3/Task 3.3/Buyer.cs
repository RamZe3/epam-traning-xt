using System;
using System.Threading;
public class Buyer
{
    public int OrderNumber { get; private set; }
    private void WaitForPizza(Pizzeria pizzeria, string nameOfPizza)
    {
        // ожидание заключается в периодических вопросах о состоянии приготовления заказа
        if (pizzeria.GetOrderInformation(OrderNumber) == "Пицца ещё не готова!")
        {
            Console.WriteLine(string.Format("Пицца {0} ещё не готова!", nameOfPizza));
            Thread.Sleep(2000);
            WaitForPizza(pizzeria, nameOfPizza);
        }
        else
        {
            Console.WriteLine(string.Format("Пицца {0} готова!", nameOfPizza));
        }
    }

    public void OrderPizza(Pizzeria pizzeria, string nameOfPizza)
    {
        OrderNumber = pizzeria.TakeOrder(nameOfPizza);
        WaitForPizza(pizzeria, nameOfPizza);
    }

}