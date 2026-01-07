using FastKart.Models.Common;

namespace FastKart.Models;

public class Product:BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ICollection<Shop>Shops { get; set; }
}