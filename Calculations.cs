namespace Price_Calculator_Kata;

public class Calculations
{
    static Tax tax = new Tax();
    static Discount discount = new Discount();
    static UPCDiscount upcDiscount = new UPCDiscount();
    static Costs packaging = new Costs(CostTypes.Packaging);
    static Costs transport = new Costs(CostTypes.Transport);
    
    
    public static void FindAllCustomerNeeds(List<Product> products)
    {
        SetObjectsValues();
        foreach (var product in products)
        {
            product.PrintProductTitle();
            double totalDiscount=0;
            double totalPrice=0;
            
            Console.WriteLine($"Cost = ${product.Price}");

            switch (upcDiscount.IsAfter)
            {
                case true when discount.IsAfter:
                    totalPrice= AllDiscountsAfter(product,out totalDiscount);
                    break;
                case true when !discount.IsAfter:
                    totalPrice=UpcDiscountAfter(product,out totalDiscount);
                    break;
                case false when discount.IsAfter:
                    totalPrice=UniversalDiscountAfter(product,out totalDiscount);
                    break;
                case false when !discount.IsAfter:
                    totalPrice=AllDiscountsBefore(product,out totalDiscount);
                    break;
            }

            PrintAllCosts(totalDiscount, totalPrice, product);
        }
    }

    private static void PrintAllCosts(double totalDiscount, double totalPrice, Product product)
    {
        double finalPrice = totalPrice + packaging.FinalCostValue(product.Price) + transport.FinalCostValue(product.Price);
        
        if(totalDiscount!=0)
            Console.WriteLine($"Discounts = ${Convert.ToTwoDicimalDigits(totalDiscount)}");
        
        if (packaging.CostValue != 0)
        {
            Console.Write($"Packaging = ${Convert.ToTwoDicimalDigits(packaging.FinalCostValue(product.Price))}");
            Console.WriteLine(packaging.IsAbsolute?"":"%");
        }

        if (transport.CostValue != 0)
        {
            Console.Write($"Transport = ${transport.CostValue}");
            Console.WriteLine(transport.IsAbsolute?"":"%");
        }
        
        Console.WriteLine($"TOTAL = ${Convert.ToTwoDicimalDigits(finalPrice)}");
       
        if(totalDiscount!=0)
            Console.WriteLine($"Program separately reports ${Convert.ToTwoDicimalDigits(totalDiscount)} total discount");
        else 
            Console.WriteLine("Program reports no discounts");
    }

    private static double AllDiscountsBefore(Product product,out double totalDiscount)
    {
        double DiscountAmount = discount.FindValueAmount(product.Price);
        double UPCDiscount=upcDiscount.FindUPCAmount(product.Price,product.UPC);
        double TaxAmount = tax.FindValueAmount(product.Price-DiscountAmount-UPCDiscount);
        totalDiscount = UPCDiscount + DiscountAmount;
        Console.WriteLine($"Tax = ${Convert.ToTwoDicimalDigits(TaxAmount)}");
        return FindFinalPrice(TaxAmount,DiscountAmount+UPCDiscount,product.Price);
    }

    private static double UniversalDiscountAfter(Product product, out double totalDiscount)
    {
        double UPCDiscount = upcDiscount.FindUPCAmount(product.Price,product.UPC);
        double DiscountAmount = discount.FindValueAmount(product.Price-UPCDiscount);
        double TaxAmount = tax.FindValueAmount(product.Price-UPCDiscount);
        totalDiscount = UPCDiscount + DiscountAmount;
        Console.WriteLine($"Tax = ${Convert.ToTwoDicimalDigits(TaxAmount)}");
        return FindFinalPrice(TaxAmount,DiscountAmount+UPCDiscount,product.Price);
    }

    private static double UpcDiscountAfter(Product product , out double totalDiscount)
    {
        double DiscountAmount = discount.FindValueAmount(product.Price);
        double UPCDiscount = upcDiscount.FindUPCAmount(product.Price-DiscountAmount,product.UPC);
        double TaxAmount = tax.FindValueAmount(product.Price-DiscountAmount);
        totalDiscount = UPCDiscount + DiscountAmount;
        Console.WriteLine($"Tax = ${Convert.ToTwoDicimalDigits(TaxAmount)}");
        return FindFinalPrice(TaxAmount,DiscountAmount+UPCDiscount,product.Price);
    }

    private static double AllDiscountsAfter(Product product , out double totalDiscount)
    {
        double TaxAmount = tax.FindValueAmount(product.Price);
        double DiscountAmount = discount.FindValueAmount(product.Price);
        double UPCDiscount = upcDiscount.FindUPCAmount(product.Price,product.UPC);
        totalDiscount = UPCDiscount + DiscountAmount;
        Console.WriteLine($"Tax = ${Convert.ToTwoDicimalDigits(TaxAmount)}");
        return FindFinalPrice(TaxAmount,DiscountAmount+UPCDiscount,product.Price);
    }

    private static void SetObjectsValues()
    {
        tax.ReadValueFromCustomer();
        discount.ReadValueFromCustomer();
        upcDiscount.ReadValueFromCustomer();
        upcDiscount.ReadUPCValueFromCustomer();
        discount.ReadIsAfter();
        upcDiscount.ReadIsAfter();
        packaging.ReadValue();
        transport.ReadValue();
    }
    
    private static double FindFinalPrice(double tax, double discount, double productPrice)
    {
        return productPrice + tax - discount;
    }
}