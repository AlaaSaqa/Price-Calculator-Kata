namespace Price_Calculator_Kata;
public class Program
{
    public static void Main(string[] args)
    {
        ProductsList.ReadProducts();
        Calculations.FindTax(ProductsList.Products);
    }

}