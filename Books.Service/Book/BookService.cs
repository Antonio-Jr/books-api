using Domain.Enums;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Book.Service.Book;

public class BookService(IBookRepository repository) : IBookService
{
    public async Task<IEnumerable<BooksResponseDto>> GetAllAsync()
    {
        var data = await repository.Find()
            .Include(c => c.Author)
            .Include(c => c.Category)
            .Select(b => new BooksResponseDto
            (
                b.Title,
                b.Author.FullName,
                nameof(b.BookType),
                b.Isbn,
                b.Category.Name,
                b.Status.HasValue ? nameof(b.Status) : string.Empty,
                b.TotalCopies,
                b.CopiesInUse
            ))
            .ToListAsync();

        return data;
    }

    public async Task<BooksResponseDto?> GetByTitleAsync(string title)
    {
        var book = await repository
            .Find(c => EF.Functions.Like(c.Title.ToLower(), title.ToLower()))
            .Include(c => c.Category)
            .Include(c => c.Author)
            .Select(b => new BooksResponseDto(
                b.Title,
                b.Author.FullName,
                nameof(b.BookType),
                b.Isbn,
                b.Category.Name,
                b.Status.HasValue ? nameof(b.Status) : string.Empty,
                b.TotalCopies,
                b.CopiesInUse)
            )
            .FirstOrDefaultAsync();

        return book;
    }
}