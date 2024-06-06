using DrakeShop.Catalog.MongoDB.Repository;
using DrakeShop.Catalog.MongoDB.Settings;
using DrakeShop.Catalog.Services.CategoryServices;
using DrakeShop.Catalog.Services.ProductDetailServices;
using DrakeShop.Catalog.Services.ProductImageServices;
using DrakeShop.Catalog.Services.ProductServices;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

builder.Services.AddScoped(typeof(IMongoDbServices<>), typeof(MongoDbServices<>));

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
