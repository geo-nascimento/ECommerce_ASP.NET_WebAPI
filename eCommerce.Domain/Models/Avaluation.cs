namespace eCommerce.Domain.Models;

public class Avaluation : BaseEntity
{
    public decimal Grade { get; set; }
    public string? Comment { get; set; }
    
    //Relações
    //One-to-Many
    public int UserId { get; set; }
    public User User { get; set; }
    //One-to-Many
    public int ProductId { get; set; }
    public Product Product { get; set; }
}