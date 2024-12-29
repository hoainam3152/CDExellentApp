using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<NotificationResponse> GetAll();
        NotificationResponse? GetById(int id);
        NotificationResponse? Create(NotificationRequest request);
        NotificationResponse? Delete(int id);
    }
}
