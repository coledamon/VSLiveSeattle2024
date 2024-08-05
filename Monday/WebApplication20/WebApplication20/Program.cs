using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddNpgsqlDbContext<AppDbContext>("db");

builder.Services.AddHealthChecks().AddUrlGroup(new Uri("https://backend"), "backend");

builder.AddServiceDefaults();

var app = builder.Build();

app.MapGet("/", async (AppDbContext db) =>
{
    await db.Database.EnsureCreatedAsync();

    var product = new Product() { Name = Guid.NewGuid().ToString("d") };
    await db.Products.AddAsync(product);
    await db.SaveChangesAsync();

    var products = db.Products.ToList();
    return Results.Ok(products);
});

app.MapGet("/backend", async (HttpClient client) =>
{
    return await client.GetStringAsync("https://backend");
});

app.MapDefaultEndpoints();

app.Run();


class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}

class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
}