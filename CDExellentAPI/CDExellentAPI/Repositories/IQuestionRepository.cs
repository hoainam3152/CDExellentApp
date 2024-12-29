using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface IQuestionRepository
    {
        IEnumerable<QuestionResponse> GetAll();
        QuestionResponse? GetById(int id);
        QuestionResponse? Create(QuestionCreate request);
        QuestionResponse? Update(int id, QuestionUpdate request);
        QuestionResponse? Delete(int id);
    }
}
