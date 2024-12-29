using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface IGuestRepository
    {
        IEnumerable<GuestResponse> GetAll();
        GuestResponse? GetById(int NotificationId, int GuestrId);
        GuestResponse? Create(GuestRequest request);
        GuestResponse? Delete(int NotificationId, int GuestrId);
    }
}
