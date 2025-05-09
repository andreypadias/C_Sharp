public class SaleView
{ 

      string _filePath = "Data/sales.json";

    public void Show()
    {
        do
        {
            Console.WriteLine("*** Sales Management ***");
            Console.WriteLine("1. Add Sale");
            Console.WriteLine("2. Delete Sale");
            Console.WriteLine("3. View Sales");
            Console.WriteLine("4. Back to Main Menu");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddSale();
                    break;
                case "2":
                    DeleteSale();
                    break;
                case "3":
                    ViewSales();
                    break;
                case "4":
                    BackToMainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Show();
                    break;
            }

        } while (true);


    }

    //Add Sale
   public void AddSale()
{
    // Load customers from the JSON file
    var customerController = new CustomerController("Data/customers.json");
    var customers = customerController.GetCustomers();

    if (customers.Count == 0)
    {
        Console.WriteLine("No customers found. Please add a customer first.");
        return;
    }

    // Display customers for selection
    Console.WriteLine("Select a customer for the sale:");
    foreach (var customer in customers)
    {
        Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}, Phone: {customer.Phone}");
    }

    Console.WriteLine("Enter the ID of the customer:");
    var customerId = int.Parse(Console.ReadLine() ?? "0");
    var selectedCustomer = customers.FirstOrDefault(c => c.Id == customerId);

    if (selectedCustomer == null)
    {
        Console.WriteLine("Invalid customer ID. Sale creation aborted.");
        return;
    }

    // Load products from the JSON file
    var productController = new ProductController("Data/products.json");
    var products = productController.GetProducts();

    if (products.Count == 0)
    {
        Console.WriteLine("No products found. Please add products first.");
        return;
    }

    // Allow the user to select multiple products
    var selectedProducts = new List<Product>();
    Console.WriteLine("Select products for the sale (enter product IDs, one at a time, and type 'done' when finished):");
    foreach (var product in products)
    {
        Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.StockQuantity}");
    }

    while (true)
    {
        Console.WriteLine("Enter Product ID (or type 'done' to finish):");
        var input = Console.ReadLine();

        if (input?.ToLower() == "done")
        {
            break;
        }

        if (int.TryParse(input, out var productId))
        {
            var selectedProduct = products.FirstOrDefault(p => p.Id == productId);

            if (selectedProduct != null)
            {
                Console.WriteLine($"Enter quantity for {selectedProduct.Name} (Available: {selectedProduct.StockQuantity}):");
                var quantity = int.Parse(Console.ReadLine() ?? "0");

                if (quantity > 0 && quantity <= selectedProduct.StockQuantity)
                {
                    // Clone the product and set the quantity for the sale
                    var productForSale = new Product
                    {
                        Id = selectedProduct.Id,
                        Name = selectedProduct.Name,
                        Description = selectedProduct.Description,
                        Price = selectedProduct.Price,
                        StockQuantity = quantity
                    };

                    selectedProducts.Add(productForSale);
                }
                else
                {
                    Console.WriteLine("Invalid quantity. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid product ID. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid product ID or 'done'.");
        }
    }

    if (selectedProducts.Count == 0)
    {
        Console.WriteLine("No products selected. Sale creation aborted.");
        return;
    }
    

    // Create a new sale object
        var sale = new Sale
    {
        Customer = selectedCustomer,
        Products = selectedProducts,
        SaleDate = DateTime.Now,
        Amount = selectedProducts.Sum(p => p.Price * p.StockQuantity), // Calculate total amount
        Id = new Random().Next(1, 1000) + (int)(DateTime.Now.Ticks) // Generate a random ID for simplicity
    };
    
    // Update the stock of the products in the inventory
    foreach (var soldProduct in selectedProducts)
    {
        var productToUpdate = products.FirstOrDefault(p => p.Id == soldProduct.Id);
        if (productToUpdate != null)
        {
            productToUpdate.StockQuantity -= soldProduct.StockQuantity;
        }
    }

    // Save the updated product inventory back to the JSON file
    productController.UpdateProducts(products);

    // Save the sale to the file
    var saleController = new SaleController(_filePath);
    saleController.AddSale(sale);

    Console.WriteLine("Sale added successfully!");
    Console.WriteLine($"Customer: {sale.Customer.Name}, Products Count: {sale.Products.Count}, Sale ID: {sale.Id}");
}
    
    // Delete Product
    public void DeleteSale()
    {
        Console.WriteLine("Enter Sales's ID to delete:");
        var id = int.Parse(Console.ReadLine() ?? "0");
        var salesController = new SaleController(_filePath);
        salesController.DeleteSale(id);
        System.Console.WriteLine("Sale with ID {0} was deleted successfully.", id);
    }

    //View Products
    public void ViewSales()
    {
        var salescController = new SaleController(_filePath);
        var sales = salescController.GetAllSales();

        if (sales.Count == 0)
        {
            Console.WriteLine("No sales found.");
            return;
        }

        Console.WriteLine("Sales List:");
        foreach (var sale in sales)
        {
            Console.WriteLine($"Sale ID: {sale.Id}, Customer: {sale.Customer.Name}, Amount: {sale.Amount}");
            foreach (var product in sale.Products)
            {
                Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.StockQuantity}");
            }
            Console.WriteLine($"Sale Date: {sale.SaleDate}");
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