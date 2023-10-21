

namespace eCommerce.Domain.Models;

public class Category : BaseEntity
{
    public string? Name { get; set; }
    
    //Relações
    //Ont-to-Many
    public ICollection<Product> Products { get; set; }
    
}