using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryResponse> GetAll();
        CategoryResponse? GetById(int id);
        CategoryResponse? Create(CategoryRequest request);
        CategoryResponse? Update(int id, CategoryRequest request);
        CategoryResponse? Delete(int id);
    }
}
