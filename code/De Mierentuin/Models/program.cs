namespace MyNamespace;


static void Main(string[] args)

{

    Console.OutputEncoding = Encoding.UTF8; // Dit is nodig voor het tonen van de prijs tekens zoals €;

       

    // Persist the new product

    Product newProduct = new Product(

        "Koffie",

        2,65m

    );


    newProduct.CreateProductData();

    

    // Get all products

    Product emptyProduct = new Product();


    List<Product> producten = emptyProduct.GetAllProducts();


    foreach (Product product in producten)

    {

        Console.WriteLine($"{product.Id}: {product.Name} - {product.Price.ToString("C", CultureInfo.CurrentCulture)}");

    }

}