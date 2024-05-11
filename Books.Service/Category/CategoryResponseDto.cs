using Book.Service.Book;

namespace Book.Service.Category;
public record CategoryResponseDto(
    string Name,
    ICollection<BooksResponseDto> Books
);