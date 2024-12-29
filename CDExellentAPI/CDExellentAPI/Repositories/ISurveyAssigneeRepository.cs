using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface ISurveyAssigneeRepository
    {
        IEnumerable<SurveyAssigneeResponse> GetAll();
        SurveyAssigneeResponse? GetById(int SurveyRequestId, int AssigneeId);
        SurveyAssigneeResponse? Create(SurveyAssigneeRequest request);
        SurveyAssigneeResponse? Delete(int SurveyRequestId, int AssigneeId);
    }
}
