using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface ISurveyRepository
    {
        IEnumerable<SurveyResponse> GetAll();
        SurveyResponse? GetById(int id);
        SurveyResponse? Create(SurveyCreate request);
        SurveyResponse? Update(int id, SurveyUpdate request);
        SurveyResponse? Delete(int id);
    }
}
