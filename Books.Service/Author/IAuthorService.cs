namespace Book.Service.Author;

public interface IAuthorService
{
    Task<IEnumerable<AuthorResponseDto>> GetAllAsync();
    Task<AuthorResponseDto?> GetByNameAsync(string name);
}