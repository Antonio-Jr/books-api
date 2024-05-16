namespace Books.Service.Author;

public interface IAuthorService
{
    IAsyncEnumerable<AuthorResponseDto> GetByNameAsync(string name);
}