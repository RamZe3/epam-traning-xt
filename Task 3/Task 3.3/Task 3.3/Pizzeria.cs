using System.Threading.Tasks;
public class Pizzeria
{
    private bool[] orderTable;
    public int currentOrderNumber
    {
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
            return "Пицца ещё не готова!";
        }
    }

    async private void CookPizza(int orderNumber)
    {
        await Task.Delay(3000);
        orderTable[orderNumber] = true;
    }
}