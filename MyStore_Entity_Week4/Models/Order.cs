namespace MyStore_Entity_Week4.Models;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }

    public int CustomerId { get; set; }

    // navigation property
    public virtual Customer Customer { get; set; } = default!;

    // navigation property
    public virtual List<OrderItem> OrderItems { get; set; } = new();
    public decimal TotalPrice { get; set; }
}