using Book.Service.Book;

namespace Book.Service.Author;
public record AuthorResponseDto(
    string FirstName,
    string LastName,
    string FullName,
    ICollection<BooksResponseDto> Books
);