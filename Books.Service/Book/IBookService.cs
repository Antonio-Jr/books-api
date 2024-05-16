namespace Books.Service.Book;

public interface IBookService
{
    IAsyncEnumerable<BooksResponseDto> GetByTitleAsync(string title);
}