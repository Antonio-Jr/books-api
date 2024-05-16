using Books.Service.Author;
using Books.Service.Book;
using Books.Service.Category;

namespace Books.Api.GraphQL;

public class Query
{
    public IAsyncEnumerable<BooksResponseDto> GetBooksByTitleAsync([Service] IBookService bookService,
        string? title) => bookService.GetByTitleAsync(title ?? string.Empty);
    
    public IAsyncEnumerable<AuthorResponseDto> GetAuthorsByNameAsync([Service] IAuthorService authorService,
        string? name) => authorService.GetByNameAsync(name ?? string.Empty);
    
    public IAsyncEnumerable<CategoryResponseDto> GetCategoriesByNameAsync([Service] ICategoryService categoryService,
        string? name) => categoryService.GetByNameAsync(name ?? string.Empty);
}