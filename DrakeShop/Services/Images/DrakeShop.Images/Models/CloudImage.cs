using DrakeShop.Images.Models.BaseClass;
using DrakeShop.Images.MongoDB;

namespace DrakeShop.Images.Models
{
    [BsonCollection("CloudImage")]
    public class CloudImage : Document
    {
        public string ImageUrl { get; set; }
    }
}
