using FastKart.Models.Common;

namespace FastKart.Models;

public class Shop:BaseEntity
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}