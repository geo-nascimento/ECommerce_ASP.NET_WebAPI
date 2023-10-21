namespace eCommerce.Domain.Models;

public class Order : BaseEntity
{
    public decimal TotalValue { get; set; }
    public StatusOrder Status { get; set; }
    
    //Relações
    //Many-to-Many
    public ICollection<Product> Products { get; set; }  
    //One-toMany
    public int UserId { get; set; }
    public User User { get; set; }
}