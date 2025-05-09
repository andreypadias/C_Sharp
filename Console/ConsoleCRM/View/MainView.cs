public class MainView
{

    public void Show()
    {
        Console.WriteLine("*** Welcome to the Sales Management System***");
        Console.WriteLine("1. View Products");
        Console.WriteLine("2. View Sales");
        Console.WriteLine("3. View Customers");
        Console.WriteLine("4. Reports");
        Console.WriteLine("5. Exit");

        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":

                ViewProducts();
                break;
            case "2":
                ViewSales();
                break;
            case "3":
                ViewCustomers();
                break;
            case "4":
                ViewReports();
                break;
            case "5":
                ExitCRM();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                Show();
                break;
        }
    }

    public void ViewProducts()
    {
        // Create an instance of the ProductView class
        ProductView productView = new ProductView();
        productView.Show();
    }
    public void ViewSales()
    {
        // Create an instance of the SaleView class
        SaleView saleView = new SaleView();
        saleView.Show();
    }
    public void ViewCustomers()
    {
        // Create an instance of the CustomerView class
        CustomerView customerView = new CustomerView();
        customerView.Show();
    }   
    
    public void ViewReports()
    {
        ReportView reportView = new ReportView();
        reportView.Show();
    }
    public void ExitCRM()
    {
         Console.WriteLine("Do you want to exit? (y/n)");
                var exitChoice = Console.ReadLine();
                if (exitChoice?.ToLower() == "y")
                {
                    Console.WriteLine("Exiting the application...");
                    Environment.Exit(0);
                }
                else
                {
                    Show();
                }
                Console.WriteLine("Thank you for using the Sales Management System!");
                Environment.Exit(0);
    }
}   