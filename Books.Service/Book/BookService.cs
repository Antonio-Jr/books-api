using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Books.Service.Book;

public class BookService(IBookRepository repository) : IBookService
{
    public IAsyncEnumerable<BooksResponseDto> GetByTitleAsync(string title)
    {
        var books = repository
            .Find(c => EF.Functions.Like(c.Title.ToLower(), $"%{title.ToLower()}%"))
            .Include(c => c.Category)
            .Include(c => c.Author)
            .Select(b => new BooksResponseDto(
                b.Title,
                b.Author.FullName,
                b.BookType.ToString(),
                b.Isbn,
                b.Category.Name,
                b.Status.HasValue ? b.Status.Value.ToString() : string.Empty,
                b.TotalCopies,
                b.CopiesInUse)
            )
            .AsNoTracking()
            .AsAsyncEnumerable();

        return books;
    }
}