using Books.Service.Book;

namespace Books.Service.Author;
public record AuthorResponseDto(
    string FirstName,
    string LastName,
    string FullName,
    ICollection<BooksResponseDto> Books
);