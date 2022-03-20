namespace Price_Calculator_Kata;

public class Product
{
    public string Name { get; set; }
    public int UPC { get; set; }
    public double Price { get; set; }

    public Product(string Name, int UPC, double Price)
    {
        this.Name = Name;
        this.UPC = UPC;
        this.Price = Price;
    }

    public void PrintProductTitle()
    {
        Console.WriteLine($"Sample product: Book with name = “{Name}”" +
                          $", UPC={UPC}, price=${Convert.ToTwoDicimalDigits(Price)}.");
    }
}