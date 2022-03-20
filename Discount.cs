namespace Price_Calculator_Kata;

public class Discount : IAmounts
{
    public double Value { get; set; }
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

    public bool CheckValue(bool IsDoubleDiscount)
    {
        return ((Value is >= 0 and <= 100 ) && IsDoubleDiscount);
    }

    public double FindValueAmount(double Price)
    {
        return (Price * (Value / 100.0)); 
    } 
}