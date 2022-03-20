namespace Price_Calculator_Kata;

public class Discount : IAmounts
{
    public double Value { get; set; }
    
    public bool IsAfter { get; set; }
    public void ReadValueFromCustomer()
    {
        while (true)
        {
            Console.WriteLine("Enter Discount Percentage You Want: ");

            double discount;
            var IsDoublediscount = double.TryParse(Console.ReadLine(),out discount);

            if (CheckValue(IsDoublediscount))
            {
                Value = (discount);
                return;
            }

            Console.WriteLine("Please Enter Double Number For Discount and between 0 and 100 ");

        } 
    }
    public void ReadIsAfter()
    {
        while (true)
        {
            Console.WriteLine("Is Universal After Tax ? (Y/N) ");

            string after = Console.ReadLine();

            if(!CheckAfter(after))
                Console.WriteLine("Please Enter Y For Yes And N For No  ");
            else
            {
                return;
            }

        } 
    }

    private bool CheckAfter(string? after)
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
    public bool CheckValue(bool IsDoubleDiscount)
    {
        return ((Value is >= 0 and <= 100 ) && IsDoubleDiscount);
    }

    public double FindValueAmount(double Price)
    {
        return (Price * (Value / 100.0)); 
    } 
}