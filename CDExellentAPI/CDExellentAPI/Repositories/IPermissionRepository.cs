using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface IPermissionRepository
    {
        IEnumerable<PermissionResponse> GetAll();
        PermissionResponse? GetById(int id);
        PermissionResponse? Create(PermissionRequest request);
        PermissionResponse? Update(int id, PermissionRequest request);
        PermissionResponse? Delete(int id);
    }
}
