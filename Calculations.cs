namespace Price_Calculator_Kata;

public class Calculations
{
    public static void FindTax(List<Product> products)
    {
        Tax tax = new Tax();
        Discount discount = new Discount();
        UPCDiscount upcDiscount = new UPCDiscount();
        
        tax.ReadValueFromCustomer();
        discount.ReadValueFromCustomer();
        upcDiscount.ReadValueFromCustomer();
        upcDiscount.ReadUPCValueFromCustomer();
        
        foreach (var product in products)
        {
            product.PrintProductTitle();
            double TaxAmount = tax.FindValueAmount(product.Price);
            double DiscountAmount = discount.FindValueAmount(product.Price);
            double UPCDiscount = upcDiscount.FindUPCAmount(product);
            double FinalPrice = FindFinalPrice(TaxAmount,DiscountAmount+UPCDiscount,product.Price);

            Console.WriteLine($"Program prints price ${Convert.ToTwoDicimalDigits(FinalPrice)}");
            Console.WriteLine($"Program reports total discount amount ${Convert.ToTwoDicimalDigits(UPCDiscount+DiscountAmount)}");
        }
    }

    private static double FindFinalPrice(double tax, double discount, double productPrice)
    {
        return productPrice + tax - discount;
    }
}