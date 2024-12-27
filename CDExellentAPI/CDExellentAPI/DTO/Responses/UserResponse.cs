using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Responses
{
    public class UserResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int TitleId { get; set; }
        public bool Status { get; set; }

        public UserResponse()
        {

        }

        public UserResponse(User user)
        {
            ID = user.ID;
            Name = user.Name;
            Email = user.Email;
            TitleId = user.TitleId;
            Status = user.Status;
        }
    }
}
