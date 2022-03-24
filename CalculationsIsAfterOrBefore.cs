namespace Price_Calculator_Kata;

public class CalculationsIsAfterOrBefore
{
    public static void DoCalculationsForIsAfterOrBefore(Product product)
    {
        double totalDiscount=0;
        double totalPrice=0;
            
        Console.WriteLine($"Cost = ${Convert.ToTwoDicimalDigits(product.Price,product.Currency)}");

        switch (Calculations.upcDiscount.IsAfter)
        {
            case true when Calculations.discount.IsAfter:
                totalPrice= AllDiscountsAfter(product,out totalDiscount);
                break;
            case true when !Calculations.discount.IsAfter:
                totalPrice=UpcDiscountAfter(product,out totalDiscount);
                break;
            case false when Calculations.discount.IsAfter:
                totalPrice=UniversalDiscountAfter(product,out totalDiscount);
                break;
            case false when !Calculations.discount.IsAfter:
                totalPrice=AllDiscountsBefore(product,out totalDiscount);
                break;
        }

        PrintAllCosts(totalDiscount, totalPrice, product); 
    }
    public static double AllDiscountsBefore(Product product,out double totalDiscount)
    {
        double DiscountAmount = Calculations.discount.FindValueAmount(product.Price);
        double UPCDiscount=Calculations.upcDiscount.FindUPCAmount(product.Price,product.UPC);
        double TaxAmount = Calculations.tax.FindValueAmount(product.Price-DiscountAmount-UPCDiscount);
        totalDiscount = UPCDiscount + DiscountAmount;
        Console.WriteLine($"Tax = ${Convert.ToTwoDicimalDigits(TaxAmount,product.Currency)}");
        return Calculations.FindFinalPrice(TaxAmount,DiscountAmount+UPCDiscount,product.Price);
    }

    public static double UniversalDiscountAfter(Product product, out double totalDiscount)
    {
        double UPCDiscount = Calculations.upcDiscount.FindUPCAmount(product.Price,product.UPC);
        double DiscountAmount = Calculations.discount.FindValueAmount(product.Price-UPCDiscount);
        double TaxAmount = Calculations.tax.FindValueAmount(product.Price-UPCDiscount);
        totalDiscount = UPCDiscount + DiscountAmount;
        Console.WriteLine($"Tax = ${Convert.ToTwoDicimalDigits(TaxAmount,product.Currency)}");
        return Calculations.FindFinalPrice(TaxAmount,DiscountAmount+UPCDiscount,product.Price);
    }

    public static double UpcDiscountAfter(Product product , out double totalDiscount)
    {
        double DiscountAmount = Calculations.discount.FindValueAmount(product.Price);
        double UPCDiscount = Calculations.upcDiscount.FindUPCAmount(product.Price-DiscountAmount,product.UPC);
        double TaxAmount = Calculations.tax.FindValueAmount(product.Price-DiscountAmount);
        totalDiscount = UPCDiscount + DiscountAmount;
        Console.WriteLine($"Tax = ${Convert.ToTwoDicimalDigits(TaxAmount,product.Currency)}");
        return Calculations.FindFinalPrice(TaxAmount,DiscountAmount+UPCDiscount,product.Price);
    }

    public static double AllDiscountsAfter(Product product , out double totalDiscount)
    {
        double TaxAmount = Calculations.tax.FindValueAmount(product.Price);
        double DiscountAmount = Calculations.discount.FindValueAmount(product.Price);
        double UPCDiscount = Calculations.upcDiscount.FindUPCAmount(product.Price,product.UPC);
        totalDiscount = UPCDiscount + DiscountAmount;
        Console.WriteLine($"Tax = ${Convert.ToTwoDicimalDigits(TaxAmount,product.Currency)}");
        return Calculations.FindFinalPrice(TaxAmount,DiscountAmount+UPCDiscount,product.Price);
    }
    public static void PrintAllCosts(double totalDiscount, double totalPrice, Product product)
    {

        double finalPrice = totalPrice + Calculations.packaging.FinalCostValue(product.Price) + Calculations.transport.FinalCostValue(product.Price);
            
        if (totalDiscount != 0)
        {
            Console.WriteLine($"Discounts = ${Convert.ToTwoDicimalDigits(totalDiscount,product.Currency)}");
        }
        
        if (Calculations.packaging.CostValue != 0)
        {
            Console.Write($"Packaging = ${Convert.ToTwoDicimalDigits(Calculations.packaging.FinalCostValue(product.Price),product.Currency)}");
        }

        if (Calculations.transport.CostValue != 0)
        {
            Console.Write($"Transport = ${Convert.ToTwoDicimalDigits(Calculations.transport.CostValue,product.Currency)}");
        }
        
        Console.WriteLine($"TOTAL = ${Convert.ToTwoDicimalDigits(finalPrice,product.Currency)}");
       
        if(totalDiscount!=0)
            Console.WriteLine($"Program separately reports ${Convert.ToTwoDicimalDigits(totalDiscount,product.Currency)} total discount");
        else 
            Console.WriteLine("Program reports no discounts");
    }
}