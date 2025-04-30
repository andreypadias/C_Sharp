using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class DocumentController
{
    private readonly string filePath;

    public DocumentController(string filePath)
    {
        this.filePath = filePath;

        // Ensure the file exists
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
    }

    // Create or Add an expense to the CSV file
    public void AddExpense(Expense expense)
    {
        using (var writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{expense.Title},{expense.Category},{expense.Amount},{expense.Date:yyyy-MM-dd}");
        }
    }

    // Read all expenses from the CSV file
    public List<Expense> GetExpenses()
    {
        var expenses = new List<Expense>();

        if (!File.Exists(filePath)) return expenses;

        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length == 4)
            {
                expenses.Add(new Expense(
                    parts[0], // Title
                    parts[1], // Category
                    decimal.Parse(parts[2]), // Amount
                    DateTime.Parse(parts[3]) // Date
                ));
            }
        }

        return expenses;
    }

    // Update an expense in the CSV file by Title
    public void UpdateExpense(string title, Expense updatedExpense)
    {
        var expenses = GetExpenses();
        var expenseIndex = expenses.FindIndex(e => e.Title == title);

        if (expenseIndex != -1)
        {
            expenses[expenseIndex] = updatedExpense;
            SaveAllExpenses(expenses);
        }
    }

    // Delete an expense from the CSV file by Title
    public void RemoveExpense(string title)
    {
        var expenses = GetExpenses();
        var updatedExpenses = expenses.Where(e => e.Title != title).ToList();
        SaveAllExpenses(updatedExpenses);
    }

    // Save all expenses back to the CSV file (used internally)
    private void SaveAllExpenses(List<Expense> expenses)
    {
        using (var writer = new StreamWriter(filePath, false))
        {
            foreach (var expense in expenses)
            {
                writer.WriteLine($"{expense.Title},{expense.Category},{expense.Amount},{expense.Date:yyyy-MM-dd}");
            }
        }
    }
}