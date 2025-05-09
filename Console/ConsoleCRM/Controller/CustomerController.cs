public class CustomerController
{
    private readonly string _filePath;
    private readonly DataReader _dataReader;

    public CustomerController(string filePath)
    {
        _filePath = filePath;
        _dataReader = new DataReader(_filePath);
    }

    public List<Customer> GetCustomers()
    {
        return _dataReader.ReadData<Customer>();
    }

    public Customer? GetCustomerById(int id)
    {
        var customers = GetCustomers();
        return customers.FirstOrDefault(c => c.Id == id);
    }

    public void AddCustomer(Customer customer)
    {
        var customers = GetCustomers();
        customers.Add(customer);
        _dataReader.SaveData(customers);
    }

    public void UpdateCustomer(Customer customer)
    {
        var customers = GetCustomers();
        var existingCustomer = customers.FirstOrDefault(c => c.Id == customer.Id);
        if (existingCustomer != null)
        {
            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;
            _dataReader.SaveData(customers);
        }
    }

    public void DeleteCustomer(int id)
    {
        var customers = GetCustomers();
        var customerToRemove = customers.FirstOrDefault(c => c.Id == id);
        if (customerToRemove != null)
        {
            customers.Remove(customerToRemove);
            _dataReader.SaveData(customers);
        }
    }

 
}