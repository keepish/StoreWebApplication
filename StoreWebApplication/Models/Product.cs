namespace StoreWebApplication.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Article { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public decimal Price { get; set; }

    public int SupplierId { get; set; }

    public int ManufacturerId { get; set; }

    public string Category { get; set; } = null!;

    public int Discount { get; set; }

    public int Amount { get; set; }

    public string Description { get; set; } = null!;

    public string? Photo { get; set; }

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<OrderedProduct> OrderedProducts { get; set; } = new List<OrderedProduct>();

    public virtual Supplier Supplier { get; set; } = null!;
}
