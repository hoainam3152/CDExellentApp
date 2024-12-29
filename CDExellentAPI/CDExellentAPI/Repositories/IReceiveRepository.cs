using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface IReceiveRepository
    {
        IEnumerable<ReceiveResponse> GetAll();
        ReceiveResponse? GetById(int NotificationId, int ReceiverId);
        ReceiveResponse? Create(ReceiveRequest request);
        ReceiveResponse? Delete(int NotificationId, int ReceiverId);
    }
}
