namespace DrakeShop.Catalog.MongoDB.Settings;

public interface IMongoDbSettings
{
    string DatabaseName { get; set; }
    
    string ConnectionString { get; set; }
}