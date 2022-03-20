namespace Price_Calculator_Kata;

public class UPCDiscount : IAmounts
{
    public double Value { get; set; }
    public int SelectedUPC { get; set; }
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
    

    public bool CheckValue(bool IsDoubleDiscount)
    {
        return ((Value is >= 0 and <= 100) && IsDoubleDiscount);
    }
    public double FindUPCAmount(Product product)
    {
        if (product.UPC == SelectedUPC)
        {
            return FindValueAmount(product.Price);
        }
        return 0;
    } 
    public double FindValueAmount(double Price)
    {
        return (Price * (Value / 100.0)); 
    }
}