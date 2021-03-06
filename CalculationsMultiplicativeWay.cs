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
        DiscountsAmount = DiscountsAmount < Calculations.cap.FinalCostValue(product.Price)
            ? Calculations.cap.FinalCostValue(product.Price)
            : DiscountsAmount;
        
        double total = Calculations.FindFinalPrice(TaxAmount, DiscountsAmount, product.Price + packaging + transports);
        
        Console.WriteLine($"Cost = {Convert.ToTwoDicimalDigits(product.Price,product.Currency)}");
        Console.WriteLine($"Tax = {Convert.ToTwoDicimalDigits(TaxAmount,product.Currency)}");
        Console.WriteLine($"Discounts = {Convert.ToTwoDicimalDigits(DiscountsAmount,product.Currency)}");
        if(packaging!=0)
            Console.WriteLine($"Packaging = {Convert.ToTwoDicimalDigits(packaging,product.Currency)}");
        if(transports!=0)
            Console.WriteLine($"Transport = {Convert.ToTwoDicimalDigits(transports,product.Currency)}");
        Console.WriteLine($"TOTAL = {Convert.ToTwoDicimalDigits(total,product.Currency)}");
        Console.WriteLine($"Program separately reports {Convert.ToTwoDicimalDigits(DiscountsAmount,product.Currency)} total discount"); 

    }
}