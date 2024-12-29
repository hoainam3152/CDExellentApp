using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface ISurveyRequestRepository
    {
        IEnumerable<SurveyRequestResponse> GetAll();
        SurveyRequestResponse? GetById(int id);
        SurveyRequestResponse? Create(SurveyRequestCU request);
        SurveyRequestResponse? Update(int id, SurveyRequestCU request);
        SurveyRequestResponse? Delete(int id);
    }
}
