using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface IBlogRepository
    {
        IEnumerable<BlogResponse> GetAll();
        BlogResponse? GetById(int id);
        BlogResponse? Create(BlogCreate request);
        BlogResponse? Update(int id, BlogUpdate request);
        BlogResponse? Delete(int id);
    }
}
