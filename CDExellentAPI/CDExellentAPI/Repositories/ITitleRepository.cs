using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface ITitleRepository
    {
        IEnumerable<TitleResponse> GetAll();
        TitleResponse? GetById(int id);
        TitleResponse? Create(TitleRequest request);
        TitleResponse? Update(int id, TitleRequest request);
        TitleResponse? Delete(int id);
    }
}
