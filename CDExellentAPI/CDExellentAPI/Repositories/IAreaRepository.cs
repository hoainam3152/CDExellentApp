using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;

namespace CDExellentAPI.Repositories
{
    public interface IAreaRepository
    {
        IEnumerable<AreaResponse> GetAll();
        AreaResponse? GetById(string id);
        AreaResponse? Create(AreaCreate request);
        AreaResponse? Update(string id, AreaUpdate request);
        AreaResponse? Delete(string id);
    }
}
