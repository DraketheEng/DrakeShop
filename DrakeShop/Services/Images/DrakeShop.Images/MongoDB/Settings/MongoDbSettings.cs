namespace DrakeShop.Images.MongoDB.Settings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }

        public string ConnectionString { get; set; }
    }
}
