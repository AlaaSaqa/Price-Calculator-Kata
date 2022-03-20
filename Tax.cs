namespace Price_Calculator_Kata;

public class Tax : IAmounts
{
    public double Value { get; set; }
    public void ReadValueFromCustomer()
    {
        while (true)
        {
            Console.WriteLine("Enter Tax Percentage You Want: ");

            double tax;
            var IsDoubleTax = double.TryParse(Console.ReadLine(),out tax);

            if (CheckValue(IsDoubleTax))
            {
                Value = (tax);
                return;
            }

            Console.WriteLine("Please Enter Double Number For Tax and between 0 and 100 ");

        } 
    }

    public bool CheckValue(bool IsDoubleTax)
    {
        return ((Value is >= 0 and <= 100 ) && IsDoubleTax);
    }

    public double FindValueAmount(double Price)
    {
        return (Price * (Value / 100.0)); 
    }
}