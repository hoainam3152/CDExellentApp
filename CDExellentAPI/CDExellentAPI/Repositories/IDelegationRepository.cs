using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface IDelegationRepository
    {
        IEnumerable<DelegationResponse> GetAll();
        DelegationResponse? GetById(int UserId, int PermissionId);
        DelegationResponse? Create(DelegationRequest request);
        DelegationResponse? Delete(int UserId, int PermissionId);
    }
}
