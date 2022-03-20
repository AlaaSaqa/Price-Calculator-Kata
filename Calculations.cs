namespace Price_Calculator_Kata;

public class Calculations
{
    public static void FindTax(List<Product> products)
    {
        Tax tax = new Tax();
        Discount discount = new Discount();
        
        tax.ReadValueFromCustomer();
        discount.ReadValueFromCustomer();
        
        foreach (var product in products)
        {
            product.PrintProductTitle();
            double TaxAmount = tax.FindValueAmount(product.Price);
            double DiscountAmount = discount.FindValueAmount(product.Price);
            double FinalPrice = FindFinalPrice(TaxAmount,DiscountAmount,product.Price);
            Console.WriteLine($"Price before = ${product.Price}, price after = ${Convert.ToTwoDicimalDigits(FinalPrice)}");
        }
    }

    private static double FindFinalPrice(double tax, double discount, double productPrice)
    {
        return productPrice + tax - discount;
    }
}