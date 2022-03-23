namespace Price_Calculator_Kata;

public class Costs
{
    public double CostValue { get; set; }
    public bool IsAbsolute { get; set; }
    public CostTypes type { get; set; }


    public double FinalCostValue(double price)
    {
        if (IsAbsolute)
            return CostValue;
        return price * (CostValue / 100.0);
    }
    
    public Costs(CostTypes type)
    {
        this.type = type;
    }
    
    public void ReadValue()
    {
        ReadValueType();
        while (true)
        {
            Console.WriteLine($"Enter {type} value You Want: ");

            double value;
            var IsDoubleValue = double.TryParse(Console.ReadLine(), out value);
            if (CheckIfValidValue(value, IsDoubleValue))
            {
                return;
            }
        }
    }

    private bool CheckIfValidValue(double value, bool isDoubleValue)
    {
        if (isDoubleValue)
        {
            if (IsAbsolute)
            {
                CostValue = value;
                return true;
            }
            else
            {
                if (value>= 0 && value <= 100)
                {
                    CostValue = value;
                    return true;
                }
            }
        }

        return false;
    }

    public void ReadValueType()
    {
        while (true)
        {
            Console.WriteLine($"Enter {type} type : (p:percentage , a:absolute value) ");

            string transType = Console.ReadLine();

            if (!CheckValueType(transType))
                Console.WriteLine("Please Enter Valid Value ");
            else
            {
                return;
            }

        } 
    }
    
    private bool CheckValueType(string type)
    {
        if (type is "p" or "P")
        {
            IsAbsolute = false;
            return true;
        } 
        if (type is "A" or "a")
        {
            IsAbsolute = true;
            return true;
        }

        return false;
    }
}