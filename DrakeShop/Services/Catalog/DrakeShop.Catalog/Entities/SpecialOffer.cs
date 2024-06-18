using DrakeShop.Catalog.Entities.BaseClass;
using DrakeShop.Catalog.MongoDB;

namespace DrakeShop.Catalog.Entities
{
    [BsonCollection("SpecialOffer")]
    public class SpecialOffer : Document
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImgUrl { get; set; }
    }
}
