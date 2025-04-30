public class ExpenseManager
{ 

    private List<Expense> expenses;

    public ExpenseManager()
    {
        expenses = new List<Expense>();
    }

    public void AddExpense(string title, string category, decimal amount, DateTime date)
    {
        Expense expense = new Expense(title, category, amount, date);
        expenses.Add(expense);
    }

    public void RemoveExpense(string title)
    {
        var expenseToRemove = expenses.FirstOrDefault(e => e.Title == title);
    if (expenseToRemove != null)
    {
        expenses.Remove(expenseToRemove);
    }
    }

    public List<Expense> GetExpenses()
    {
        return expenses;
    }

    public decimal GetTotalExpenses()
    {
        decimal total = 0;
        foreach (var expense in expenses)
        {
            total += expense.Amount;
        }
        return total;
    }

}