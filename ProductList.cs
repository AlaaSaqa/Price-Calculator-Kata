namespace Price_Calculator_Kata;


using System.Collections;

public class ProductsList : IEnumerable<Product>
{
    public static List<Product> Products = new List<Product>();

    public IEnumerator<Product> GetEnumerator()
    {
        return Products.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Products.GetEnumerator();
    }

    public static void ReadProducts()
    {
        int size = ReadNumberOfProducts();

        for (int index = 0; index < size; index++)
        {
            string name = ReadProductName();
            int upc = ReadProductUPC();
            double price = ReadProductPrice();
            string currrency = ReadProductCurrency();
            
            
            Product product = new Product(name, upc, price,currrency);
            Products.Add(product);
        }
    }

    private static string ReadProductCurrency()
    {
        while (true)
        {
            Console.WriteLine("Enter Product Currency : ");

            string currency = Console.ReadLine();

            if (currency.Length == 3)
            {
                return currency.ToUpper();
            }
            
            Console.WriteLine("Please Enter ISO-3 codes currency");

        } 
    }

    private static double ReadProductPrice()
    {
        while (true)
        {
            Console.WriteLine("Enter Product Price : ");

            double price;
            var IsDoublePrice = double.TryParse(Console.ReadLine(),out price);

            if (IsDoublePrice)
                return price;

            Console.WriteLine("Please Enter Double Number For Price");

        }
    }

    private static int ReadProductUPC()
    {
        while (true)
        {
            Console.WriteLine("Enter Product UPC : ");

            int upc;
            var IsIntUPC = int.TryParse(Console.ReadLine(),out upc);

            if (IsIntUPC)
                return upc;

            Console.WriteLine("Please Enter Integer Number For UPC");

        }
    }

    private static string ReadProductName()
    {
        Console.WriteLine("Enter Product Name : ");
        return Console.ReadLine();
    }

    public static int ReadNumberOfProducts()
    {
        while (true)
        {
            Console.WriteLine("Enter Number Of Products : ");

            int Size;
            var IsIntsize = int.TryParse(Console.ReadLine(),out Size);

            if (IsIntsize&&Size>0)
                return Size;

            Console.WriteLine("Please Enter Integer Number For Size");

        }

    }


}
