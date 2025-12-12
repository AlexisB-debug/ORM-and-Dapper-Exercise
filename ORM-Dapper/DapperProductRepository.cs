using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DapperProductRepository : IProductRepository
{
    private readonly IDbConnection  _dbConnection;

    public DapperProductRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _dbConnection.Query<Product>("SELECT * FROM products");
    }

    public void CreateProduct(string name, double price, int categoryID)
    {
        _dbConnection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID)", new { name = name, price = price, categoryID = categoryID });
    }

    public Product GetProductByProductID(int productID)
    {
        return _dbConnection.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @productID", new { productID });
    }

    public void UpdateProduct(Product product)
    {
        _dbConnection.Execute(
            "UPDATE products SET Name = @name, Price = @price, CategoryID = @categoryID, OnSale = @onSale, StockLevel = @stock WHERE ProductID = @productID",
            new { productID = product.ProductID, name = product.Name, price = product.Price, CategoryID = product.CategoryID, onSale = product.OnSale, stock = product.StockLevel });
    }
}