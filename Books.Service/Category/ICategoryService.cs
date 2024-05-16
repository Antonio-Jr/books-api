namespace Books.Service.Category;

public interface ICategoryService
{
    IAsyncEnumerable<CategoryResponseDto> GetByNameAsync(string name);
}