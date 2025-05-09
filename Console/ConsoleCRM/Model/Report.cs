public class Report
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? GeneratedBy { get; set; }
    public string? Content { get; set; }

    // Navigation properties
    public virtual ICollection<Sale>? Sales { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
    public virtual ICollection<Customer>? Customers { get; set; }
}