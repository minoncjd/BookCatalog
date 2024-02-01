using BookCatalog.Model;
using ExcentOne.BookCatalog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddServiceCollectionExtensions();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed default data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();

        // Check if there is existing data
        if (!context.Books.Any() && !context.Categories.Any())
        {
            // If no data exists, add some default Books and Categories
            var category1 = new Category { Name = "Fiction" };
            var category2 = new Category { Name = "Non-Fiction" };

            context.Categories.AddRange(category1, category2);

            context.Books.AddRange(
                new Book
                {
                    CategoryId = category1.Id,
                    Title = "The Great Gatsby",
                    Description = "A classic novel by F. Scott Fitzgerald",
                    PublishDateUtc = DateTime.UtcNow
                },
                new Book
                {
                    CategoryId = category2.Id,
                    Title = "Sapiens: A Brief History of Humankind",
                    Description = "A popular science book by Yuval Noah Harari",
                    PublishDateUtc = DateTime.UtcNow
                }
            );

            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
