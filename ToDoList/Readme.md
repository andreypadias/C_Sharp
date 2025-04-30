# Expense Manager Console Application

## Overview

This repository contains a **basic console application** for managing personal expenses. The project is designed as a simple exercise to demonstrate fundamental programming concepts in C#, such as object-oriented programming (OOP), file handling, and user interaction through a console-based interface.

The application allows users to:
- Add expenses.
- View a list of all expenses.
- Update existing expenses.
- Remove expenses.
- Persist expenses to a CSV file for data storage.

## Features

1. **Expense Management**:
   - Users can manage their expenses by adding, updating, and removing them.
   - Expenses include properties such as `Title`, `Category`, `Amount`, and `Date`.

2. **CSV File Integration**:
   - Expenses are saved to a CSV file (`expenses.csv`) using the `DocumentController` class.
   - This ensures that data is persisted between program runs.

3. **Console-Based User Interface**:
   - The `ExpensesView` class provides a simple and interactive menu for users to manage their expenses.

4. **Error Handling**:
   - The application includes basic error handling to ensure a smooth user experience.

## Project Structure

```
ToDoList/
├── Expense.cs              # Represents an individual expense.
├── ExpenseManager.cs       # Manages a list of expenses in memory.
├── DocumentController.cs   # Handles saving, loading, and updating expenses in a CSV file.
├── ExpensesView.cs         # Provides a console-based interface for managing expenses.
├── Program.cs              # Entry point of the application.
└── expenses.csv            # CSV file used to store expenses (created automatically).
```

### Key Classes

1. **`Expense`**:
   - Represents an individual expense with properties like `Title`, `Category`, `Amount`, and `Date`.

2. **`ExpenseManager`**:
   - Manages a list of expenses in memory.
   - Provides methods to add, remove, and retrieve expenses.

3. **`DocumentController`**:
   - Handles CRUD operations for expenses in a CSV file.
   - Ensures data persistence.

4. **`ExpensesView`**:
   - Provides a user-friendly console interface for managing expenses.
   - Integrates with `ExpenseManager` and `DocumentController`.

5. **`Program`**:
   - The entry point of the application.
   - Initializes the necessary components and starts the menu.

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/andreypadias/C_Sharp/expense-manager.git
   cd expense-manager
   ```

2. Compile the code:
   ```bash
   mcs -out:ExpenseManagerApp.exe Program.cs Expense.cs ExpenseManager.cs DocumentController.cs ExpensesView.cs
   ```

3. Run the application:
   ```bash
   mono ExpenseManagerApp.exe
   ```

4. Follow the on-screen menu to manage your expenses.

## Example Usage

### Adding an Expense
- Enter the title, category, amount, and date when prompted.
- The expense will be saved to the CSV file and displayed in the list.

### Viewing Expenses
- Displays all expenses along with the total amount.

### Updating an Expense
- Enter the title of the expense to update, followed by the new details.

### Removing an Expense
- Enter the title of the expense to remove it from the list and the CSV file.

## Error Handling

The application includes basic error handling to manage invalid inputs (e.g., incorrect date or amount formats) and unexpected issues (e.g., file access errors). If an error occurs, a message will be displayed in the console.

## Purpose

This project is a **basic exercise** designed for beginners to practice:
- Object-oriented programming in C#.
- File handling with CSV files.
- Building a simple console-based user interface.
- Error handling and debugging.

## Future Improvements

- Add support for filtering expenses by category or date.
- Implement sorting options for expenses.
- Enhance the user interface with colors or formatting.
- Add unit tests for better code reliability.

## License

This project is open-source and available under the [MIT License](LICENSE).

---

Enjoy learning and improving your C# skills with this simple expense manager! 😊