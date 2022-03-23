namespace Price_Calculator_Kata;

public class CalculationsMultiplicativeWay
{
    public static void DoCalculationsForMultiplicativeWay(Product product)
    {
        double TaxAmount = Calculations.tax.FindValueAmount(product.Price);
        double DiscountsAmount = Calculations.discount.FindValueAmount(product.Price);
        DiscountsAmount += Calculations.upcDiscount.FindUPCAmount(product.Price-DiscountsAmount, product.UPC);
        double packaging = Calculations.packaging.FinalCostValue(product.Price);
        double transports = Calculations.transport.FinalCostValue(product.Price);
        double total = Calculations.FindFinalPrice(TaxAmount, DiscountsAmount, product.Price + packaging + transports);
        
        Console.WriteLine($"Cost = {product.Price}");
        Console.WriteLine($"Tax = {Convert.ToTwoDicimalDigits(TaxAmount)}");
        Console.WriteLine($"Discounts = {Convert.ToTwoDicimalDigits(DiscountsAmount)}");
        Console.WriteLine($"Packaging = {Convert.ToTwoDicimalDigits(packaging)}");
        Console.WriteLine($"Transport = {Convert.ToTwoDicimalDigits(transports)}");
        Console.WriteLine($"TOTAL = {Convert.ToTwoDicimalDigits(total)}");
        Console.WriteLine($"Program separately reports {Convert.ToTwoDicimalDigits(DiscountsAmount)} total discount"); 

    }
}