using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;

namespace CDExellentAPI.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserResponse> GetAll();
        UserResponse? GetById(int id);
        UserResponse? Create(UserRequest request);
        UserResponse? Update(int id, UserRequest request);
        UserResponse? Delete(int id);
    }
}
