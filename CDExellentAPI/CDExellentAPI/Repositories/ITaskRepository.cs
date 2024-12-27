using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskResponse> GetAll();
        TaskResponse? GetById(int id);
        TaskResponse? Create(TaskCreate request);
        TaskResponse? Update(int id, TaskUpdate request);
        TaskResponse? Delete(int id);
    }
}
