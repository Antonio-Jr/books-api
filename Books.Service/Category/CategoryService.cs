using Books.Service.Book;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Books.Service.Category;

public class CategoryService(ICategoryRepository repository) : ICategoryService
{
    public IAsyncEnumerable<CategoryResponseDto> GetByNameAsync(string name)
    {
        var authors = repository
            .Find(c => EF.Functions.Like(c.Name.ToLower(), $"{name.ToLower()}%"))
            .Include(c => c.Books)
            .ThenInclude(c => c.Author)
            .Select(c => new CategoryResponseDto(
                c.Name,
                c.Books.Select(b =>
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

        return authors;
    }
}