using System;

public class ExpensesView
{
    private ExpenseManager expenseManager;
    private DocumentController documentController;

    public ExpensesView(ExpenseManager manager, DocumentController controller)
    {
        expenseManager = manager;
        documentController = controller;

        // Load existing expenses from the file into the ExpenseManager
        var savedExpenses = documentController.GetExpenses();
        foreach (var expense in savedExpenses)
        {
            expenseManager.AddExpense(expense.Title, expense.Category, expense.Amount, expense.Date);
        }
    }

    public void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine("\nExpense Manager");
            Console.WriteLine("1. View Expenses");
            Console.WriteLine("2. Add Expense");
            Console.WriteLine("3. Update Expense");
            Console.WriteLine("4. Remove Expense");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayExpenses();
                    break;
                case "2":
                    AddExpense();
                    break;
                case "3":
                    UpdateExpense();
                    break;
                case "4":
                    RemoveExpense();
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayExpenses()
    {
        var expenses = expenseManager.GetExpenses();
        Console.WriteLine("\nExpenses:");
        foreach (var expense in expenses)
        {
            Console.WriteLine(expense.ToString());
        }
        Console.WriteLine($"Total Expenses: {expenseManager.GetTotalExpenses():C}");
    }

    private void AddExpense()
    {
        Console.Write("\nEnter Title: ");
        var title = Console.ReadLine();

        Console.Write("Enter Category: ");
        var category = Console.ReadLine();

        Console.Write("Enter Amount: ");
        if (!decimal.TryParse(Console.ReadLine(), out var amount))
        {
            Console.WriteLine("Invalid amount. Operation canceled.");
            return;
        }

        Console.Write("Enter Date (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out var date))
        {
            Console.WriteLine("Invalid date. Operation canceled.");
            return;
        }

        expenseManager.AddExpense(title, category, amount, date);
        documentController.AddExpense(new Expense(title, category, amount, date));
        Console.WriteLine("Expense added successfully.");
    }

    private void UpdateExpense()
    {
        Console.Write("\nEnter the Title of the expense to update: ");
        var title = Console.ReadLine();

        Console.Write("Enter New Title: ");
        var newTitle = Console.ReadLine();

        Console.Write("Enter New Category: ");
        var newCategory = Console.ReadLine();

        Console.Write("Enter New Amount: ");
        if (!decimal.TryParse(Console.ReadLine(), out var newAmount))
        {
            Console.WriteLine("Invalid amount. Operation canceled.");
            return;
        }

        Console.Write("Enter New Date (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out var newDate))
        {
            Console.WriteLine("Invalid date. Operation canceled.");
            return;
        }

        expenseManager.RemoveExpense(title);
        expenseManager.AddExpense(newTitle, newCategory, newAmount, newDate);

        documentController.RemoveExpense(title);
        documentController.AddExpense(new Expense(newTitle, newCategory, newAmount, newDate));
        Console.WriteLine("Expense updated successfully.");
    }

    private void RemoveExpense()
    {
        Console.Write("\nEnter the Title of the expense to remove: ");
        var title = Console.ReadLine();

        expenseManager.RemoveExpense(title);
        documentController.RemoveExpense(title);
        Console.WriteLine("Expense removed successfully.");
    }
}