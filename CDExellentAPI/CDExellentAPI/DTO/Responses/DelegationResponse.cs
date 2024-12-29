using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Responses
{
    public class DelegationResponse
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        public DelegationResponse()
        {

        }

        public DelegationResponse(Delegation delegation)
        {
            UserId = delegation.UserId;
            PermissionId = delegation.PermissionId;
        }
    }
}
