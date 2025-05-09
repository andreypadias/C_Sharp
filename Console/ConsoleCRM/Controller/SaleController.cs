public class SaleController
{
    private readonly string _filePath;
    private readonly DataReader _dataReader;

    public SaleController(string filePath)
    {
        _filePath = filePath;
        _dataReader = new DataReader(_filePath);
    }

    // Get all sales
    public List<Sale> GetAllSales()
    {
        return _dataReader.ReadData<Sale>();
    }

    // Add a new sale
    public void AddSale(Sale sale)
    {
        var sales = GetAllSales();
        sales.Add(sale);
        _dataReader.SaveData(sales);
    }

    // Update an existing sale
    public void UpdateSale(int id, Sale updatedSale)
    {
        var sales = GetAllSales();
        var sale = sales.FirstOrDefault(s => s.Id == id);
        if (sale != null)
        {
            sale.CustomerId = updatedSale.CustomerId;
            sale.ProductId = updatedSale.ProductId;
            sale.Amount = updatedSale.Amount;
            sale.SaleDate = updatedSale.SaleDate;
            _dataReader.SaveData(sales);
        }
    }

    // Delete a sale
    public void DeleteSale(int id)
    {
        var sales = GetAllSales();
        var sale = sales.FirstOrDefault(s => s.Id == id);
        if (sale != null)
        {
            sales.Remove(sale);
            _dataReader.SaveData(sales);
        }
    }

    // Get sales by ID
    public Sale GetSaleById(int id)
    {
        var sales = GetAllSales();
        return sales.FirstOrDefault(s => s.Id == id)?? new Sale();
    }
}
