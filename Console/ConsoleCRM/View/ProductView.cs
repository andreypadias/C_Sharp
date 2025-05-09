public class ProductView
{
    string _filePath = "Data/products.json";

    public void Show()
    {
        do
        {
            Console.WriteLine("*** Product Management ***");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. View Products");
            Console.WriteLine("5. Back to Main Menu");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    UpdateProduct();
                    break;
                case "3":
                    DeleteProduct();
                    break;
                case "4":
                    ViewProducts();
                    break;
                case "5":
                    BackToMainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Show();
                    break;
            }

        } while (true);


    }

    //Add Product
    public void AddProduct()
    {
        Console.WriteLine("Enter Product Name:");
        var name = Console.ReadLine();
        Console.WriteLine("Enter Product Description:");
        var description = Console.ReadLine();
        Console.WriteLine("Enter Product Price:");
        var price = decimal.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Enter Product Quantity:");
        var quantity = int.Parse(Console.ReadLine() ?? "0");

        // Create a new product object
        var product = new Product
        {
            Name = name,
            Description = description,
            Price = price,
            StockQuantity = quantity,
            CreatedAt = DateTime.Now,
            Id = new Random().Next(1, 1000) + (int)(DateTime.Now.Ticks)// Generate a random ID for simplicity
        };

        // Save the product to the file
        var productController = new ProductController(_filePath);
        productController.AddProduct(product);
    }

    // Update Product
    public void UpdateProduct()
    {
        Console.WriteLine("Enter Product ID to update:");
        var id = int.Parse(Console.ReadLine() ?? "0");
        var productController = new ProductController(_filePath);
        var product = productController.GetProductById(id);

        if (product != null)
        {
            Console.WriteLine("Enter new Product Name (leave blank to keep current):");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                product.Name = name;
            }

            Console.WriteLine("Enter new Product Description (leave blank to keep current):");
            var description = Console.ReadLine();
            if (!string.IsNullOrEmpty(description))
            {
                product.Description = description;
            }

            Console.WriteLine("Enter new Product Price (leave blank to keep current):");
            var priceInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(priceInput))
            {
                product.Price = decimal.Parse(priceInput);
            }

            Console.WriteLine("Enter new Product Quantity (leave blank to keep current):");
            var quantityInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(quantityInput))
            {
                product.StockQuantity = int.Parse(quantityInput);
            }

            // Update the product in the file
            productController.UpdateProduct(product);
            System.Console.WriteLine("Product {0} Id: {1} was updated successfully.", product.Name, product.Id);
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    // Delete Product
    public void DeleteProduct()
    {
        Console.WriteLine("Enter Product ID to delete:");
        var id = int.Parse(Console.ReadLine() ?? "0");
        var productController = new ProductController(_filePath);
        productController.DeleteProduct(id);
        System.Console.WriteLine("Product with ID {0} was deleted successfully.", id);
    }

    //View Products
    public void ViewProducts()
    {
        var productController = new ProductController(_filePath);
        var products = productController.GetProducts();

        if (products.Count == 0)
        {
            Console.WriteLine("No products found.");
            return;
        }

        Console.WriteLine("Product List:");
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Description: {product.Description}, Price: {product.Price}, Quantity: {product.StockQuantity}");
        }
    }

    public void BackToMainMenu()
    {
        System.Console.WriteLine("Do you want to go back to the main menu? (y/n)");
                    var exitChoice = Console.ReadLine();
                    if (exitChoice?.ToLower() == "y")
                    {
                        Console.WriteLine("Going back to the main menu...");
                        var mainView = new MainView();
                        mainView.Show();
                    }
                    else
                    {
                        Show();
                    }
    }
}