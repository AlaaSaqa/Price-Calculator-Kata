namespace Price_Calculator_Kata;

public interface IAmounts
{
    public double Value { get; set; }

    public void ReadValueFromCustomer();

    public bool CheckValue(bool IsDoubleTax);

    public double FindValueAmount(double Price);

}