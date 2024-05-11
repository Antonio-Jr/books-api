using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration;

public static class SeedData
{
    public static void Seed(this ModelBuilder builder)
    {
        builder.Entity<Author>().HasData(
            new() { Id = Guid.Parse("1c98c000-8f8e-4d3c-8d1e-7ec0ec93f1bb"), FirstName = "Jane", LastName = "Austen" },
            new() { Id = Guid.Parse("251e8346-65c1-496d-823c-cd433649347c"), FirstName = "Harper", LastName = "Lee" },
            new() { Id = Guid.Parse("517c6f8c-8abc-4183-a2b9-5bb9e76b3b3a"), FirstName = "J.D", LastName = "Salinger" },
            new()
            {
                Id = Guid.Parse("55febf99-1b0d-42b8-a43b-8e5a1c4b3690"), FirstName = "F. Scott", LastName = "Fitzgerald"
            },
            new() { Id = Guid.Parse("7b453ac1-18ca-4887-a8d9-ab81b4276d1e"), FirstName = "Paulo", LastName = "Coelho" },
            new() { Id = Guid.Parse("8997e2d9-5f02-4da4-a4ad-d069608fccde"), FirstName = "Markus", LastName = "Zusak" },
            new() { Id = Guid.Parse("b48af8fc-0899-4b36-9140-19c64a4f6fcd"), FirstName = "C.S", LastName = "Lewis" },
            new() { Id = Guid.Parse("b614713f-239b-4e6a-8ade-b87c9425c874"), FirstName = "Dan", LastName = "Brown" },
            new()
            {
                Id = Guid.Parse("c32c75c2-d6be-4391-97d5-b35f54a5520c"), FirstName = "John", LastName = "Steinbeck"
            },
            new()
            {
                Id = Guid.Parse("e9c23ec1-d8d2-4142-84ae-bbfdf1beab9a"), FirstName = "Douglas", LastName = "Adams"
            },
            new()
            {
                Id = Guid.Parse("f0024628-4947-41b2-8ed0-aab6c9e2bd51"), FirstName = "Herman", LastName = "Melville"
            }
        );

        builder.Entity<Category>().HasData(
            new() { Id = Guid.Parse("1994ecb4-d361-4739-871d-c2bf902e463c"), Name = "Fiction" },
            new() { Id = Guid.Parse("21bcefe9-7b70-48a5-9438-fe9281411403"), Name = "Non-Fiction" },
            new() { Id = Guid.Parse("46123bcc-66c8-4360-a10e-c020989b66e5"), Name = "Biography" },
            new() { Id = Guid.Parse("534f3066-8ac4-49c4-abac-db5351d916bf"), Name = "Mystery" },
            new() { Id = Guid.Parse("d09ddf34-e274-4807-94ec-ea5566358746"), Name = "Sci-Fi" }
        );

        builder.Entity<Book>().HasData(
            new()
            {
                Id = Guid.Parse("c2c9d469-d4d9-4f3e-86c6-88dcddf9a406"),
                Title = "Pride and Prejudice",
                AuthorId = Guid.Parse("1c98c000-8f8e-4d3c-8d1e-7ec0ec93f1bb"),
                TotalCopies = 100,
                CopiesInUse = 80,
                BookType = EBookType.Hardcover,
                Isbn = "1234567891",
                CategoryId = Guid.Parse("1994ecb4-d361-4739-871d-c2bf902e463c")
            },
            new()
            {
                Id = Guid.Parse("339d8705-50fa-4bf6-b69b-f91456e3c907"),
                Title = "To Kill a Mockingbird",
                AuthorId = Guid.Parse("251e8346-65c1-496d-823c-cd433649347c"),
                TotalCopies = 75,
                CopiesInUse = 65,
                BookType = EBookType.Paperback,
                Isbn = "1234567892",
                CategoryId = Guid.Parse("1994ecb4-d361-4739-871d-c2bf902e463c")
            },
            new()
            {
                Id = Guid.Parse("dc6efd59-b2b6-4f81-9608-dce9c39945cf"),
                Title = "The Catcher in the Rye",
                AuthorId = Guid.Parse("517c6f8c-8abc-4183-a2b9-5bb9e76b3b3a"),
                TotalCopies = 50,
                CopiesInUse = 45,
                BookType = EBookType.Hardcover, 
                Isbn = "1234567893",
                CategoryId = Guid.Parse("1994ecb4-d361-4739-871d-c2bf902e463c")
            },
            new()
            {
                Id = Guid.Parse("a7e05753-b12f-41e0-86b1-0b639c25eacd"),
                Title = "The Great Gatsby",
                AuthorId = Guid.Parse("55febf99-1b0d-42b8-a43b-8e5a1c4b3690"),
                TotalCopies = 50,
                CopiesInUse = 22,
                BookType = EBookType.Hardcover,
                Isbn = "1234567894",
                CategoryId = Guid.Parse("21bcefe9-7b70-48a5-9438-fe9281411403")
            },
            new()
            {
                Id = Guid.Parse("e172454f-82aa-472f-bdb2-6781477c651a"),
                Title = "The Alchemist",
                AuthorId = Guid.Parse("7b453ac1-18ca-4887-a8d9-ab81b4276d1e"),
                TotalCopies = 50,
                CopiesInUse = 35,
                BookType = EBookType.Hardcover,
                Isbn = "1234567895",
                CategoryId = Guid.Parse("46123bcc-66c8-4360-a10e-c020989b66e5")
            },
            new()
            {
                Id = Guid.Parse("0e733f33-1e0b-4702-822a-8723e77509db"),
                Title = "The Book Thief",
                AuthorId = Guid.Parse("8997e2d9-5f02-4da4-a4ad-d069608fccde"),
                TotalCopies = 75,
                CopiesInUse = 11,
                BookType = EBookType.Hardcover,
                Isbn = "1234567896",
                CategoryId = Guid.Parse("534f3066-8ac4-49c4-abac-db5351d916bf")
            },
            new()
            {
                Id = Guid.Parse("7da57676-de31-4104-825c-c895db522ab2"),
                Title = "The Chronicles of Narnia",
                AuthorId = Guid.Parse("b48af8fc-0899-4b36-9140-19c64a4f6fcd"),
                TotalCopies = 100,
                CopiesInUse = 14,
                BookType = EBookType.Paperback,
                Isbn = "1234567897",
                CategoryId = Guid.Parse("d09ddf34-e274-4807-94ec-ea5566358746")
            },
            new()
            {
                Id = Guid.Parse("16056931-4d00-4aca-958d-ae698f8f64cd"),
                Title = "The Da Vinci Code",
                AuthorId = Guid.Parse("b614713f-239b-4e6a-8ade-b87c9425c874"),
                TotalCopies = 50,
                CopiesInUse = 40,
                BookType = EBookType.Paperback, 
                Isbn = "1234567898",
                CategoryId = Guid.Parse("d09ddf34-e274-4807-94ec-ea5566358746")
            },
            new()
            {
                Id = Guid.Parse("cb577182-fe3c-4c6f-ae4e-45e4d3cd202f"), 
                Title = "The Grapes of Wrath",
                AuthorId = Guid.Parse("c32c75c2-d6be-4391-97d5-b35f54a5520c"),
                TotalCopies = 50,
                CopiesInUse = 35,
                BookType = EBookType.Hardcover,
                Isbn = "1234567899",
                CategoryId = Guid.Parse("1994ecb4-d361-4739-871d-c2bf902e463c")
            },
            new()
            {
                Id = Guid.Parse("3112e468-a139-464b-bff3-40fd3e30d7c9"),
                Title = "The Hitchhiker''s Guide to the Galaxy",
                AuthorId = Guid.Parse("e9c23ec1-d8d2-4142-84ae-bbfdf1beab9a"),
                TotalCopies = 50,
                CopiesInUse = 35,
                BookType = EBookType.Paperback,
                Isbn = "1234567900",
                CategoryId = Guid.Parse("21bcefe9-7b70-48a5-9438-fe9281411403")
            },
            new()
            {
                Id = Guid.Parse("abbb48f7-1eee-4c02-99e1-039a5ed353cb"),
                Title = "Moby-Dick",
                AuthorId = Guid.Parse("f0024628-4947-41b2-8ed0-aab6c9e2bd51"),
                TotalCopies = 30,
                CopiesInUse = 8,
                BookType = EBookType.Hardcover,
                Isbn = "8901234567",
                CategoryId = Guid.Parse("1994ecb4-d361-4739-871d-c2bf902e463c")
            },
            new()
            {
                Id = Guid.Parse("2c471656-d95e-4a3f-b4f0-5c8b30aa8011"),
                Title = "To Kill a Mockingbird",
                AuthorId = Guid.Parse("251e8346-65c1-496d-823c-cd433649347c"),
                TotalCopies = 20,
                CopiesInUse = 0,
                BookType = EBookType.Paperback,
                Isbn = "9012345678",
                CategoryId = Guid.Parse("21bcefe9-7b70-48a5-9438-fe9281411403")
            },
            new()
            {
                Id = Guid.Parse("a4804e31-4e9c-4d44-be70-57e084134a28"),
                Title = "The Catcher in the Rye",
                AuthorId = Guid.Parse("517c6f8c-8abc-4183-a2b9-5bb9e76b3b3a"),
                TotalCopies = 10,
                CopiesInUse = 1,
                BookType = EBookType.Hardcover,
                Isbn = "0123456789",
                CategoryId = Guid.Parse("21bcefe9-7b70-48a5-9438-fe9281411403")
            }
        );
    }
}