namespace eCommerce.Domain.Models;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    public DateTime UpdateDate { get; set; }
}