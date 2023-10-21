namespace eCommerce.Domain.Models;

public class User : BaseEntity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    
    //Relações
    //One-to-Many
    public ICollection<Order> Orders { get; set; }
    //One-to-Many
    public ICollection<Avaluation> Avaluations { get; set; }
}