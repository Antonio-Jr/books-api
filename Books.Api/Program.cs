using System.Text.Json.Serialization;
using Books.Api.GraphQL;
using Books.Service.Author;
using Books.Service.Book;
using Books.Service.Category;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
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

builder.Services.AddCors();

builder.Services
    .AddGraphQLServer()
    .AddFiltering()
    .AddSorting()
    .AddProjections()
    .AddQueryType<Query>();

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
    using var serviceScope = app.Services.CreateScope();
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
    dbContext.Database.Migrate();
}

app.UseCors(options => { options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
app.MapGraphQL(path: "/graphql");

app.Run();