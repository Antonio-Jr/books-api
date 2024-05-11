using Book.Service.Book;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Book.Service.Author;

public class AuthorService(IAuthorRepository repository) : IAuthorService
{
    public async Task<IEnumerable<AuthorResponseDto>> GetAllAsync()
    {
        var data = await repository.Find()
            .Include(c => c.Books)
            .ThenInclude(c => c.Category)
            .Select(a =>
                new AuthorResponseDto(
                    a.FirstName,
                    a.LastName,
                    a.FullName,
                    a.Books.Select(b =>
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

    public async Task<AuthorResponseDto?> GetByNameAsync(string name)
    {
        var author = await repository
            .Find(c => EF.Functions.Like(c.FirstName.ToLower(), name.ToLower()))
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