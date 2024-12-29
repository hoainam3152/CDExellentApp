using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface IAnswerRepository
    {
        IEnumerable<AnswerResponse> GetAll();
        AnswerResponse? GetById(int id);
        AnswerResponse? Create(AnswerCreate request);
        AnswerResponse? Update(int id, AnswerUpdate request);
        AnswerResponse? Delete(int id);
    }
}
