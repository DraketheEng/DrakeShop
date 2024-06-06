using DrakeShop.Catalog.Entities.BaseClass;
using DrakeShop.Catalog.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DrakeShop.Catalog.Entities;

[BsonCollection("Category")]
public class Category : Document
{
    public string CategoryName { get; set; }
}