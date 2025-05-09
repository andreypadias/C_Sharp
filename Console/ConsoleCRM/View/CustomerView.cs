public class CustomerView
{
     string _filePath = "Data/customers.json";

    public void Show()
    {
        do
        {
            Console.WriteLine("*** Customers Management ***");
            Console.WriteLine("1. Add Customers");
            Console.WriteLine("2. Update Customers");
            Console.WriteLine("3. Delete Customers");
            Console.WriteLine("4. View Customers");
            Console.WriteLine("5. Back to Main Menu");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddCustomer();
                    break;
                case "2":
                    UpdateCustomer();
                    break;
                case "3":
                    DeleteCustomer();
                    break;
                case "4":
                    ViewCustomer();
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
    public void AddCustomer()
    {
        Console.WriteLine("Enter Customer Name:");
        var name = Console.ReadLine();
        Console.WriteLine("Enter Customer Email:");
        var email = Console.ReadLine();
        Console.WriteLine("Enter Customer Phone:");
        var phone = Console.ReadLine();

        // Create a new cusotmer object
        var customer = new Customer
        {
            Name = name,
            Email = email,
            Phone = phone,
            Id = new Random().Next(1, 1000) + (int)(DateTime.Now.Ticks)// Generate a random ID for simplicity
        };

        // Save the customer to the file
        var customerController = new CustomerController(_filePath);
        customerController.AddCustomer(customer);
        System.Console.WriteLine("Customer {0} Id: {1} was added successfully.", customer.Name, customer.Id);
    }

    // Update Product
    public void UpdateCustomer()
    {
        Console.WriteLine("Enter Csutomer's ID to update:");
        var id = int.Parse(Console.ReadLine() ?? "0");
        var customerController = new CustomerController(_filePath);
        var customer = customerController.GetCustomerById(id);

        if (customer != null)
        {
            Console.WriteLine("Enter new Customer Name (leave blank to keep current):");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                customer.Name = name;
            }

            Console.WriteLine("Enter new Customer Email (leave blank to keep current):");
            var email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email))
            {
                customer.Email = email;
            }

            Console.WriteLine("Enter new Customer Phone (leave blank to keep current):");
            var phone = Console.ReadLine();
            if (!string.IsNullOrEmpty(phone))
            {
                customer.Phone = phone;
            }

            // Update the customer in the file
            customerController.UpdateCustomer(customer);
            System.Console.WriteLine("Customer {0} Id: {1} was updated successfully.", customer.Name, customer.Id);
        }
        else
        {
            Console.WriteLine("Customer not found.");
        }
    }

    // Delete Product
    public void DeleteCustomer()
    {
        Console.WriteLine("Enter Customer's ID to delete:");
        var id = int.Parse(Console.ReadLine() ?? "0");
        var customerController = new CustomerController(_filePath);
        customerController.DeleteCustomer(id);
        System.Console.WriteLine("Customer with ID {0} was deleted successfully.", id);
    }

    //View Products
    public void ViewCustomer()
    {
        var customerController = new CustomerController(_filePath);
        var customers = customerController.GetCustomers();

        if (customers.Count == 0)
        {
            Console.WriteLine("No customers found.");
            return;
        }

        Console.WriteLine("Customers List:");
        foreach (var customer in customers)
        {
            Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Phone: {customer.Phone}, Email: {customer.Email}");
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