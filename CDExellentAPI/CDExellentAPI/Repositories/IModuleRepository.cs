using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface IModuleRepository
    {
        IEnumerable<ModuleResponse> GetAll();
        ModuleResponse? GetById(int id);
        ModuleResponse? Create(ModuleRequest request);
        ModuleResponse? Update(int id, ModuleRequest request);
        ModuleResponse? Delete(int id);
    }
}
