public class ReportView
{
    public void Show()
    {
        Console.WriteLine("*** Reports Management ***");
        Console.WriteLine("1. Total of Sales per customer");
        Console.WriteLine("2. Sales by date");
        System.Console.WriteLine("3. Customer with most sales");
        Console.WriteLine("4. Back to Main Menu");

        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                TotalSalesPerCustomer();
                break;
            case "2":
                SalesByDate();
                break;
            case "3":
                BackToMainMenu();
                break;
            case "4":
                CustomerWithMostSales();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                Show();
                break;
        }
    }
    
    public void TotalSalesPerCustomer()
    {
    // Load sales from the JSON file
    var saleController = new SaleController("Data/sales.json");
    var sales = saleController.GetAllSales();

    if (sales.Count == 0)
    {
        Console.WriteLine("No sales data found.");
        return;
    }

    // Prompt the user to enter the customer ID
    Console.WriteLine("Enter the Customer ID to view total sales:");
    if (!int.TryParse(Console.ReadLine(), out var customerId))
    {
        Console.WriteLine("Invalid Customer ID. Please try again.");
        return;
    }

    // Filter sales for the specific customer
    var customerSales = sales.Where(sale => sale.Customer.Id == customerId).ToList();

    if (customerSales.Count == 0)
    {
        Console.WriteLine("No sales found for the specified customer.");
        return;
    }

    // Calculate the total sales amount
    var totalSalesAmount = customerSales.Sum(sale => sale.Amount);

    // Display the result
    Console.WriteLine($"Total sales for Customer ID {customerId}: {totalSalesAmount:C}");

    }
    public void SalesByDate()
    {
       // Load sales from the JSON file
    var saleController = new SaleController("Data/sales.json");
    var sales = saleController.GetAllSales();

    if (sales.Count == 0)
    {
        Console.WriteLine("No sales data found.");
        return;
    }

    // Prompt the user to enter the start and end dates
    Console.WriteLine("Enter the start date (yyyy-MM-dd):");
    if (!DateTime.TryParse(Console.ReadLine(), out var startDate))
    {
        Console.WriteLine("Invalid start date. Please try again.");
        return;
    }

    Console.WriteLine("Enter the end date (yyyy-MM-dd):");
    if (!DateTime.TryParse(Console.ReadLine(), out var endDate))
    {
        Console.WriteLine("Invalid end date. Please try again.");
        return;
    }

    // Filter sales within the date range
    var filteredSales = sales.Where(sale => sale.SaleDate.Date >= startDate.Date && sale.SaleDate.Date <= endDate.Date).ToList();

    if (filteredSales.Count == 0)
    {
        Console.WriteLine($"No sales found between {startDate:yyyy-MM-dd} and {endDate:yyyy-MM-dd}.");
        return;
    }

    // Display the filtered sales
    Console.WriteLine($"Sales from {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}:");
    foreach (var sale in filteredSales)
    {
        Console.WriteLine($"Sale ID: {sale.Id}, Customer: {sale.Customer.Name}, Amount: {sale.Amount:C}, Date: {sale.SaleDate:yyyy-MM-dd}");
    }

    // Calculate and display the total sales amount
    var totalSalesAmount = filteredSales.Sum(sale => sale.Amount);
    Console.WriteLine($"Total Sales Amount: {totalSalesAmount:C}");
    }

    public void CustomerWithMostSales()
    {

        // Load sales from the JSON file
        var saleController = new SaleController("Data/sales.json");
        var sales = saleController.GetAllSales();

        if (sales.Count == 0)
        {
            Console.WriteLine("No sales data found.");
            return;
        }

        // Group sales by customer and calculate the total sales amount for each customer
        var customerSales = sales
            .GroupBy(sale => sale.Customer.Id)
            .Select(group => new
            {
                CustomerId = group.Key,
                CustomerName = group.First().Customer.Name,
                TotalSalesAmount = group.Sum(sale => sale.Amount)
            })
            .OrderByDescending(cs => cs.TotalSalesAmount)
            .FirstOrDefault();

        if (customerSales == null)
        {
            Console.WriteLine("No sales data available to determine the customer with the most sales.");
            return;
        }

        // Display the customer with the most sales
        Console.WriteLine($"Customer with the most sales:");
        Console.WriteLine($"Customer ID: {customerSales.CustomerId}");
        Console.WriteLine($"Customer Name: {customerSales.CustomerName}");
        Console.WriteLine($"Total Sales Amount: {customerSales.TotalSalesAmount:C}");
    
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