using Microsoft.EntityFrameworkCore;
using FA22.P03.Web.Features.Products;
using FA22.P03.Web.Data;
using FA22.P03.Web.Features.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // MigrateAndSeed.Initialize(services);
    var dataContext = services.GetRequiredService<DataContext>();

    dataContext.Database.Migrate();

    if (!dataContext.Products.Any())
    {


        dataContext.Products.Add(new Product());
        dataContext.SaveChanges();
    }
}

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var currentId = 1;
var products = new List<ProductDto>
{
    new ProductDto
    {
        Id = currentId++,
        Name = "Super Mario World",
        Description = "Super Nintendo (SNES) System. Mint Condition",
        
    },
    new ProductDto
    {
        Id = currentId++,
        Name = "Donkey Kong 64",
        Description = "Moderate Condition Donkey Kong 64 cartridge for the Nintendo 64",
       
    },
    new ProductDto
    {
        Id = currentId++,
        Name = "Half-Life 2: Collector's Edition",
        Description = "Good condition with all 5 CDs, booklets, and material from original",
       
    }
};



app.Run();

//see: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0
// Hi 383 - this is added so we can test our web project automatically. More on that later
public partial class Program { }
