using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DrakeShop.Images.Models.BaseClass
{
    public class Document : IDocument
    {
        [BsonElement("id")]
        [BsonRepresentation(BsonType.String)]
        public string? Id { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
