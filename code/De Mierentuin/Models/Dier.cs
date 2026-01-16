namespace DefaultNamespace;

public class Dier
{
    public void CreateProductData()

    {

        DALSQL dalSql = new DALSQL();

        dalSql.AddProduct(this);

    }
    public List<Product> GetAllProducts()

    {

        //Maak hier de bijbehorende logica om via de DALSQL alle producten op te halen.

    }
}