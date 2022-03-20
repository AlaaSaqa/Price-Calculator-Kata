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
            Console.WriteLine($"Program prints price ${Convert.ToTwoDicimalDigits(FinalPrice)}");
            
            if (discount.Value == 0)
            {
                Console.WriteLine($"Program doesn’t show any discounted amount.");    
            }
            else
            {
                Console.WriteLine($"Program displays ${Convert.ToTwoDicimalDigits(DiscountAmount)} amount which was deduced");
            }
        }
    }

    private static double FindFinalPrice(double tax, double discount, double productPrice)
    {
        return productPrice + tax - discount;
    }
}