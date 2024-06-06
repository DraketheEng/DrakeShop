using DrakeShop.Catalog.Entities.BaseClass;
using DrakeShop.Catalog.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DrakeShop.Catalog.Entities;

[BsonCollection("ProductDetail")]

public class ProductDetail : Document
{
    public string ProductDescription { get; set; }
    
    public string ProductInfo { get; set; }
    
    public string ProductId { get; set; }
    
    [BsonIgnore]
    public Product Product { get; set; }
}