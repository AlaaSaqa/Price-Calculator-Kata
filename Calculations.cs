namespace Price_Calculator_Kata;

public class Calculations
{
    public static Tax tax = new Tax();
    public static Discount discount = new Discount();
    public static UPCDiscount upcDiscount = new UPCDiscount();
    public static Costs packaging = new Costs(CostTypes.Packaging);
    public static Costs transport = new Costs(CostTypes.Transport);
    public static Costs cap = new Costs(CostTypes.Cap);
    public static DiscountCountingType discountCountingType { get; set; }
    
    public static void FindAllCustomerNeeds(List<Product> products)
    {
        SetObjectsValues();
        foreach (var product in products)
        {
            product.PrintProductTitle();

            if (discountCountingType == DiscountCountingType.AfterOrBeforeTaxPriority)
            {
               CalculationsIsAfterOrBefore.DoCalculationsForIsAfterOrBefore(product);
               continue;
            }
            if (discountCountingType == DiscountCountingType.Multiplicative)
            {
                CalculationsMultiplicativeWay.DoCalculationsForMultiplicativeWay(product);
                continue;
            } 
            if (discountCountingType == DiscountCountingType.Additive)
            {
                CalculationsAdditionalWay.DoCalculationsForAdditionalWay(product);
                continue;
            }
            
            
        }
    }
    
    private static void SetObjectsValues()
    {
        tax.ReadValueFromCustomer();
        discount.ReadValueFromCustomer();
        upcDiscount.ReadValueFromCustomer();
        upcDiscount.ReadUPCValueFromCustomer();
        packaging.ReadValue();
        transport.ReadValue();
        cap.ReadValue();
        ReadDiscountCountingType();
        if (discountCountingType == DiscountCountingType.AfterOrBeforeTaxPriority)
        {
            discount.ReadIsAfter();
            upcDiscount.ReadIsAfter();
        }
    }

    public static void ReadDiscountCountingType()
    {
        Console.WriteLine("Please Select Discount Counting Type You Want");
        Console.WriteLine("1. After Or Before Priority ");
        Console.WriteLine("2. Additive Method");
        Console.WriteLine("3. Multiplicative Method");
        int calculationMethod = 0;
        bool IsValidChoice = int.TryParse(Console.ReadLine(),out calculationMethod);

        if (IsValidChoice)
        {
            switch (calculationMethod)
            {
                case 1:
                {
                    discountCountingType = DiscountCountingType.AfterOrBeforeTaxPriority;
                    return;
                }
                case 2:
                {
                    discountCountingType = DiscountCountingType.Additive;
                    return;
                }
                case 3:
                {
                    discountCountingType = DiscountCountingType.Multiplicative;
                    return;
                }
            }
            ReadDiscountCountingType();
        }

    }

    public static double FindFinalPrice(double tax, double discount, double productPrice)
    {
        discount = discount < Calculations.cap.FinalCostValue(productPrice)
            ?cap.FinalCostValue(productPrice)
            : discount;
        return productPrice + tax - discount;
    }
}