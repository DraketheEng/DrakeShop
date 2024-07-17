using MongoDB.Bson.Serialization.Attributes;

namespace DrakeShop.Images.Models.BaseClass
{
    public interface IDocument
    {
        [BsonId]
        [BsonElement("id")]
        public string? Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
