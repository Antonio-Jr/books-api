using Book.Service.Book;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Book.Service.Category;

public class CategoryService(ICategoryRepository repository) : ICategoryService
{
    public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync()
    {
        var data = await repository.Find()
            .Include(c => c.Books)
            .Select(c =>
                new CategoryResponseDto(
                    c.Name,
                    c.Books.Select(b =>
                        new BooksResponseDto
                        (
                            b.Title,
                            b.Author.FullName,
                            nameof(b.BookType),
                            b.Isbn,
                            b.Category.Name,
                            b.Status.HasValue ? nameof(b.Status) : string.Empty,
                            b.TotalCopies,
                            b.CopiesInUse
                        )).ToList()
                ))
            .ToListAsync();

        return data;
    }

    public async Task<CategoryResponseDto?> GetByNameAsync(string name)
    {
        var author = await repository
            .Find(c => EF.Functions.Like(c.Name.ToLower(), name.ToLower()))
            .Include(c => c.Books)
            .ThenInclude(c => c.Category)
            .Select(c => new CategoryResponseDto(
                c.Name,
                c.Books.Select(b =>
                    new BooksResponseDto
                    (
                        b.Title,
                        b.Author.FullName,
                        nameof(b.BookType),
                        b.Isbn,
                        b.Category.Name,
                        b.Status.HasValue ? nameof(b.Status) : string.Empty,
                        b.TotalCopies,
                        b.CopiesInUse
                    )).ToList()
            )).FirstOrDefaultAsync();

        return author;
    }
}