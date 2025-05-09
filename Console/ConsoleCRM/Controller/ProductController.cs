public class ProductController
{
    private readonly string _filePath;
    private readonly DataReader _dataReader;

    public ProductController(string filePath)
    {
        _filePath = filePath;
        _dataReader = new DataReader(_filePath);
    }
    public List<Product> GetProducts()
    {
        return _dataReader.ReadData<Product>();
    }
    public Product? GetProductById(int id)
    {
        var products = GetProducts();
        return products.FirstOrDefault(p => p.Id == id);
    }
    public void AddProduct(Product product)
    {
        var products = GetProducts();
        products.Add(product);
        _dataReader.SaveData(products);
        System.Console.WriteLine("Product {0} Id: {1} was added successfully.", product.Name, product.Id);
    }

    //Delete a product by id
    public void DeleteProduct(int id)
    {
        var products = GetProducts();
        var productToRemove = products.FirstOrDefault(p => p.Id == id);
        if (productToRemove != null)
        {
            products.Remove(productToRemove);
            _dataReader.SaveData(products);
            System.Console.WriteLine("Product {0} Id: {1} was deleted successfully.", productToRemove.Name, productToRemove.Id);
        }
    }

    //Update a product by id
    public void UpdateProduct(Product product)
    {
        var products = GetProducts();
        var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;
            existingProduct.CreatedAt = product.CreatedAt;
            existingProduct.UpdatedAt = product.UpdatedAt;
            _dataReader.SaveData(products);
        }
    }
    
    public void UpdateProducts(List<Product> products)
    {
        _dataReader.SaveData(products);
        System.Console.WriteLine("The products stock was updated successfully.");
    }

}