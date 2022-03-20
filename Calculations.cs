namespace Price_Calculator_Kata;

public class Calculations
{
    static Tax tax = new Tax();
    static Discount discount = new Discount();
    static UPCDiscount upcDiscount = new UPCDiscount();
    
    public static void Find(List<Product> products)
    {
        SetValues();
        foreach (var product in products)
        {
            
            product.PrintProductTitle();
            double totalDiscount=0;
            double totalPrice=0;
            
            if (upcDiscount.IsAfter  && discount.IsAfter)
            {
               totalPrice= AllAfter(product,out totalDiscount);
            }
            else if (upcDiscount.IsAfter && !discount.IsAfter)
            { 
                totalPrice=UpcAfter(product,out totalDiscount);
            }
            else if (!upcDiscount.IsAfter && discount.IsAfter)
            {
                totalPrice=DiscountAfter(product,out totalDiscount);
            } 
            else if (!upcDiscount.IsAfter && !discount.IsAfter)
            {
                totalPrice=AllBefore(product,out totalDiscount);
            }
            Console.WriteLine($"Program prints price ${Convert.ToTwoDicimalDigits(totalPrice)}");
            Console.WriteLine($"Program reports total discount amount ${Convert.ToTwoDicimalDigits(totalDiscount)}");
            
        }
    }

    private static double AllBefore(Product product,out double totalDiscount)
    {
        double DiscountAmount = discount.FindValueAmount(product.Price);
        double UPCDiscount = upcDiscount.FindUPCAmount(product.Price,product.UPC);
        double TaxAmount = tax.FindValueAmount(product.Price-DiscountAmount-UPCDiscount);
        totalDiscount = UPCDiscount + DiscountAmount;
        return FindFinalPrice(TaxAmount,DiscountAmount+UPCDiscount,product.Price);
    }

    private static double DiscountAfter(Product product, out double totalDiscount)
    {
        double UPCDiscount = upcDiscount.FindUPCAmount(product.Price,product.UPC);
        double DiscountAmount = discount.FindValueAmount(product.Price-UPCDiscount);
        double TaxAmount = tax.FindValueAmount(product.Price-UPCDiscount);
        totalDiscount = UPCDiscount + DiscountAmount;
        return FindFinalPrice(TaxAmount,DiscountAmount+UPCDiscount,product.Price);
    }

    private static double UpcAfter(Product product , out double totalDiscount)
    {
        double DiscountAmount = discount.FindValueAmount(product.Price);
        double UPCDiscount = upcDiscount.FindUPCAmount(product.Price-DiscountAmount,product.UPC);
        double TaxAmount = tax.FindValueAmount(product.Price-DiscountAmount);
        totalDiscount = UPCDiscount + DiscountAmount;
        return FindFinalPrice(TaxAmount,DiscountAmount+UPCDiscount,product.Price);
    }

    private static double AllAfter(Product product , out double totalDiscount)
    {
        double TaxAmount = tax.FindValueAmount(product.Price);
        double DiscountAmount = discount.FindValueAmount(product.Price);
        double UPCDiscount = upcDiscount.FindUPCAmount(product.Price,product.UPC);
        totalDiscount = UPCDiscount + DiscountAmount;
        return FindFinalPrice(TaxAmount,DiscountAmount+UPCDiscount,product.Price);
    }

    private static void SetValues()
    {
        tax.ReadValueFromCustomer();
        discount.ReadValueFromCustomer();
        upcDiscount.ReadValueFromCustomer();
        upcDiscount.ReadUPCValueFromCustomer();
        discount.ReadIsAfter();
        upcDiscount.ReadIsAfter();
    }


    private static double FindFinalPrice(double tax, double discount, double productPrice)
    {
        return productPrice + tax - discount;
    }
}