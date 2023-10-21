namespace eCommerce.Domain.Models;

public class Product : BaseEntity
{
    public string? Name { get; set; }
    public string? Manufacturer { get; set; }
    public decimal Value { get; set; }
    public string? Description { get; set; }
    public int Stock { get; set; }
    
    //Relações
    //Many-to-many
    public ICollection<Order> Orders { get; set; }
    //One-to-MAny
    public ICollection<Avaluation> Avaluations { get; set; }
    //One-to-Many
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}