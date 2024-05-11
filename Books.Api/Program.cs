using System.Text.Json.Serialization;
using Book.Service.Author;
using Book.Service.Book;
using Book.Service.Category;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<DataContext>(
    opts =>
    {
        opts
            .UseNpgsql(builder.Configuration.GetConnectionString("BooksDB"))
            .UseSnakeCaseNamingConvention();
    });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
    dbContext.Database.Migrate();
}

app.MapGet("/books", async (IBookService service) =>
{
    var data = await service.GetAllAsync();
    return data;
});

app.MapGet("/books/title", async ([FromQuery] string title, IBookService service) =>
{
    var data = await service.GetByTitleAsync(title);
    return data;
});

app.MapGet("/authors", async (IAuthorService service) =>
{
    var data = await service.GetAllAsync();
    return data;
});

app.MapGet("/authors/name", async ([FromQuery] string name, IAuthorService service) =>
{
    var data = await service.GetByNameAsync(name);
    return data;
});

app.MapGet("/categories", async (ICategoryService service) =>
{
    var data = await service.GetAllAsync();
    return data;
});

app.MapGet("/categories/name", async ([FromQuery] string name, ICategoryService service) =>
{
    var data = await service.GetByNameAsync(name);
    return data;
});

app.Run();