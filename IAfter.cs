namespace Price_Calculator_Kata;

public interface IAfter
{
    public bool IsAfter { get; set; }

    public void ReadIsAfter();
    public bool CheckAfter(string after);

}