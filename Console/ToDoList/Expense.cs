public class Expense
{
    public string Title { get; set; }
    public string Category { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public Expense(string title, string category, decimal amount, DateTime date)
    {
        Title = title;
        Category = category;
        Amount = amount;
        Date = date;
    }

    public override string ToString()
    {
        return $"Title: {Title}, Category: {Category}, Amount: {Amount:C}, Date: {Date.ToShortDateString()}";
    }
}