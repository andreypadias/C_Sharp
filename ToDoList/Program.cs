try
{
    
     var expenseManager = new ExpenseManager();
        var documentController = new DocumentController("expenses.csv");
        var expensesView = new ExpensesView(expenseManager, documentController);

        expensesView.DisplayMenu();
    
}
catch (System.Exception ex)
{
    Console.WriteLine("An error occurred while displaying expenses. Error: " + ex.Message);
}