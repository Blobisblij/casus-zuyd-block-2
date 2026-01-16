namespace DefaultNamespace;

public class DALSQL

{

    private string webserver;

    private string database;

    private readonly string connectionstring;

        

    public DALSQL()

    {

        webserver = ".";

        database = "Bestelsysteem";

        connectionstring = $"Server={webserver};Database={database};Trusted_Connection=True;TrustServerCertificate=True;"

    }

    public void AddProduct(Product product)

    {

        string query = "INSERT INTO Product (Name, Price) VALUES (@Name, @Price)";


        using SqlConnection connection = new SqlConnection(_connectionString);

        using SqlCommand command = new SqlCommand(query, connection);


        command.Parameters.AddWithValue("@Name", product.Name);

        command.Parameters.AddWithValue("@Price", product.Price);


        connection.Open();

        command.ExecuteNonQuery();

    }
    public List<Product> GetAllProducts()

    {

        string query = "SELECT Id, Name, Price FROM Product";

        List<Product> products = new List<Product>();


        using (SqlConnection connection = new SqlConnection(connectionString))

        using (SqlCommand command = new SqlCommand(query, connectionString))

        {

            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())

            {

                while (reader.Read())

                {

                    int id = reader.GetInt32(0);

                    string productName = reader.GetString(1);

                    decimal productPrice = reader.GetDecimal(2);


                    var product = new Product(id, productName, productPrice);


                    products.Add(product);

                }

            }

        }


        return products;

    }
}

