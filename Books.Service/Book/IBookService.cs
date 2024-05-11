namespace Book.Service.Book;

public interface IBookService
{
    Task<IEnumerable<BooksResponseDto>> GetAllAsync();
    Task<BooksResponseDto?> GetByTitleAsync(string title);
}