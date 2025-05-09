public class Sale
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal Amount { get; set; }

    // Navigation properties
    public virtual Customer? Customer { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}