using DrakeShop.Catalog.Entities.BaseClass;
using DrakeShop.Catalog.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DrakeShop.Catalog.Entities;

[BsonCollection("ProductImages")]

public class ProductImages : Document
{
    public string Image1 { get; set; }
    
    public string Image2 { get; set; }
    
    public string Image3 { get; set; }
    
    public string ProductId { get; set; }
    
    [BsonIgnore]
    public Product Product { get; set; }
}