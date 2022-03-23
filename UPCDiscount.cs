namespace Price_Calculator_Kata;

public class UPCDiscount : IAmounts ,IAfter
{
    public double Value { get; set; }
    public double FindValueAmount(double Price)
    {
        return (Price * (Value / 100.0)); 
    }
    public bool CheckValue(bool IsDoubleDiscount)
    {
        return ((Value is >= 0 and <= 100) && IsDoubleDiscount);
    }
    public void ReadValueFromCustomer()
    {
        while (true)
        {
            Console.WriteLine("Enter UPC Discount Percentage You Want: ");

            double discount;
            var IsDoublediscount = double.TryParse(Console.ReadLine(),out discount);

            if (CheckValue(IsDoublediscount))
            {
                Value = (discount);
                return;
            }

            Console.WriteLine("Please Enter Double Number For UPC Discount and between 0 and 100 ");

        } 
    }
    
    
    public bool IsAfter { get; set; }
    public int SelectedUPC { get; set; }
    
    public void ReadUPCValueFromCustomer()
    {
        while (true)
        {
            Console.WriteLine("Enter The UPC  You Want: ");

            int upc;
            var IsIntUPC = int.TryParse(Console.ReadLine(),out upc);

            if (IsIntUPC)
            {
                SelectedUPC = (upc);
                return;
            }

            Console.WriteLine("Please Enter Int Number For UPC  ");

        } 
    }
    public void ReadIsAfter()
    {
        while (true)
        {
            Console.WriteLine("Is UPC After Tax ? (Y/N) ");

            string after = Console.ReadLine();

            if(!CheckAfter(after))
                Console.WriteLine("Please Enter Y For Yes And N For No  ");

            else
            {
                return;
            }

        } 
    }//
    public bool CheckAfter(string after)
    {
        if (after is "Y" or "y")
        {
            IsAfter = true;
            return true;
        }
        else if (after is "N" or "n")
        {
            IsAfter = false;
            return true;
        }

        return false;
    }
    public double FindUPCAmount(double Price , int UPC)
    {
        if (UPC == SelectedUPC)
        {
            return FindValueAmount(Price);
        }
        return 0;
    } 
}