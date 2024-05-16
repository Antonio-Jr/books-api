using Books.Service.Book;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Books.Service.Author;

public class AuthorService(IAuthorRepository repository) : IAuthorService
{
    public IAsyncEnumerable<AuthorResponseDto> GetByNameAsync(string name)
    {
        var author = repository
            .Find(c =>
                EF.Functions.Like(c.FirstName.ToLower(), $"%{name.ToLower()}%") ||
                EF.Functions.Like(c.LastName.ToLower(), $"%{name.ToLower()}%")
            )
            .Include(c => c.Books)
            .ThenInclude(c => c.Category)
            .Select(a => new AuthorResponseDto(
                a.FirstName,
                a.LastName,
                a.FullName,
                a.Books.Select(b =>
                    new BooksResponseDto
                    (
                        b.Title,
                        b.Author.FullName,
                        b.BookType.ToString(),
                        b.Isbn,
                        b.Category.Name,
                        b.Status.HasValue ? b.Status.Value.ToString() : string.Empty,
                        b.TotalCopies,
                        b.CopiesInUse
                    )).ToList()
            ))
            .AsNoTracking()
            .AsAsyncEnumerable();

        return author;
    }
}