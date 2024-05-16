namespace Books.Service.Book;

public record BooksResponseDto(
    string Title,
    string Author,
    string Type,
    string Isbn,
    string Category,
    string Status,
    int TotalCopies,
    int CopiesInUse
);