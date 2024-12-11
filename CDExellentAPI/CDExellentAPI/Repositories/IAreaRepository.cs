using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;

namespace CDExellentAPI.Repositories
{
    public interface IAreaRepository
    {
        IEnumerable<AreaResponse> GetAll();
        AreaResponse? GetById(string id);
        AreaResponse Create(AreaCreate request);
        void Update(AreaUpdate request);
        void Delete(int id);
    }
}
