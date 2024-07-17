using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddJwtBearer("OcelotAuthenticationScheme", opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceOcelot";
    opt.RequireHttpsMetadata = false;
});

// Ocelot konfig�rasyon dosyas�n� ekleyin
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("ocelot.json")
    .Build();

// Ocelot servisini ekleyin
builder.Services.AddOcelot(configuration);

var app = builder.Build();

// Ocelot middleware'i kullan�n
await app.UseOcelot();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();
