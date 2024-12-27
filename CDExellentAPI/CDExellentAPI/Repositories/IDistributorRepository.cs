using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface IDistributorRepository
    {
        IEnumerable<DistributorResponse> GetAll();
        DistributorResponse? GetById(int id);
        DistributorResponse? Create(DistributorRequest request);
        DistributorResponse? Update(int id, DistributorRequest request);
        DistributorResponse? Delete(int id);
    }
}
