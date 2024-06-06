using DrakeShop.Catalog.Entities.BaseClass;
using DrakeShop.Catalog.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DrakeShop.Catalog.Entities;

[BsonCollection("Product")]
public class Product: Document
{
    public string ProductName { get; set; }
    
    public string ProductPrice { get; set; }
    
    public string ProductImageUrl { get; set; }
    
    public string ProductDescription { get; set; }
    
    public string CategoryId { get; set; }
    
    [BsonIgnore]
    public Category Category { get; set; }
}