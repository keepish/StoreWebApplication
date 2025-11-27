namespace StoreWebApplication.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateTime DeliveryDate { get; set; }

    public int PickupPoint { get; set; }

    public int Code { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<OrderedProduct> OrderedProducts { get; set; } = new List<OrderedProduct>();

    public virtual User User { get; set; } = null!;
}
