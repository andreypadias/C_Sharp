public class ReportController
{
    private readonly string _filePath;
    private readonly DataReader _dataReader;

    public ReportController(string filePath)
    {
        _filePath = filePath;
        _dataReader = new DataReader(_filePath);
    }

    // Get all reports
    public List<Report> GetAllReports()
    {
        return _dataReader.ReadData<Report>();
    }

    // Total sales report
    public decimal GetTotalSalesReport()
    {
        var sales = _dataReader.ReadData<Sale>();
        return sales.Sum(s => s.Amount);
    }

    //Sales based on date
    public List<Sale> GetSalesByDate(DateTime startDate, DateTime endDate)
    {
        var sales = _dataReader.ReadData<Sale>();
        return sales.Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate).ToList();
    }
    //Sales based on customer   

    public List<Sale> GetSalesByCustomer(int customerId)
    {
        var sales = _dataReader.ReadData<Sale>();
        return sales.Where(s => s.CustomerId == customerId).ToList();
    }

    //Sales based on product
    public List<Sale> GetSalesByProduct(int productId)
    {
        var sales = _dataReader.ReadData<Sale>();
        return sales.Where(s => s.ProductId == productId).ToList();
    }
  


}