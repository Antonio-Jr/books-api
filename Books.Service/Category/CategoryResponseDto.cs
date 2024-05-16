using Books.Service.Book;

namespace Books.Service.Category;
public record CategoryResponseDto(
    string Name,
    ICollection<BooksResponseDto> Books
);