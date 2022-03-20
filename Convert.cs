namespace Price_Calculator_Kata;

public class Convert
{
    public static string ToTwoDicimalDigits(double value)
    {
        // value = Math.Truncate(value * 100) / 100;
        return string.Format("{0:0.00}", value);
    }
}