# 💼 ConsoleCRM

ConsoleCRM is a simple **console-based Customer Relationship Management (CRM)** application. It allows users to manage customers, products, and sales, and generate insightful reports — all from the terminal.

---

## 🚀 Features

### 👤 Customer Management
- Add, update, and view customer details.

### 📦 Product Management
- Add, update, and view product inventory.

### 💰 Sales Management
- Create sales by selecting customers and products.
- Automatically update product stock after a sale.

### 📊 Reports
- View total sales for a specific customer.
- View sales within a specific date range.
- Identify the customer with the most sales.

---

## 📁 Project Structure

```
ConsoleCRM/
├── Controller/      # Business logic
├── Data/            # JSON files (customers, products, sales)
├── Model/           # Entity models (Customer, Product, Sale)
├── View/            # Terminal interface views
├── Program.cs       # Entry point
└── README.md        # Project documentation
```

---

## ⚙️ Getting Started

### ✅ Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later

### ▶️ Running the Application

```bash
git clone https://github.com/your-username/ConsoleCRM.git
cd ConsoleCRM
dotnet run
```

> Follow the on-screen instructions to navigate through the application.

---

## 🧭 Usage

### 📌 Main Menu
Choose from:
- Customer Management
- Product Management
- Sales Management
- Report Generation

### 📂 Data Storage
Data is stored in the `Data/` directory as JSON files:
- `customers.json`: Customer details
- `products.json`: Product inventory
- `sales.json`: Sales records

### 📈 Reports Include:
- Total sales for a specific customer
- Sales within a date range
- Customer with the most sales

---

## 📝 Example JSON Files

### `customers.json`
```json
[
  {
    "Id": 1,
    "Name": "John Doe",
    "Email": "john.doe@example.com",
    "Phone": "123-456-7890"
  }
]
```

### `products.json`
```json
[
  {
    "Id": 1,
    "Name": "Laptop",
    "Description": "High-performance laptop",
    "Price": 1200.00,
    "StockQuantity": 10
  }
]
```

### `sales.json`
```json
[
  {
    "Id": 1,
    "Customer": {
      "Id": 1,
      "Name": "John Doe"
    },
    "Products": [
      {
        "Id": 1,
        "Name": "Laptop",
        "Price": 1200.00,
        "StockQuantity": 1
      }
    ],
    "SaleDate": "2025-05-08T10:00:00",
    "Amount": 1200.00
  }
]
```

---

## 🤝 Contributing

Contributions are welcome!  
Feel free to:
- Submit a pull request
- Open an issue for bugs or feature requests

---

## 📄 License

This project is licensed under the **MIT License**.  
See the [LICENSE](LICENSE) file for details.

---

## 🙏 Acknowledgments

- Built with ❤️ using **C#** and **.NET 6.0**
- JSON powered by `System.Text.Json`
