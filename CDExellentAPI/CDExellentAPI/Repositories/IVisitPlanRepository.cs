using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface IVisitPlanRepository
    {
        IEnumerable<VisitPlanResponse> GetAll();
        VisitPlanResponse? GetById(int id);
        VisitPlanResponse? Create(VisitPlanRequest request);
        VisitPlanResponse? Update(int id, VisitPlanRequest request);
        VisitPlanResponse? Delete(int id);
    }
}
