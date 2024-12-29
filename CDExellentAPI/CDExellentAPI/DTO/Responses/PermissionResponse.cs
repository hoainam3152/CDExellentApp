using CDExellentAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Responses
{
    public class PermissionResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ModuleId { get; set; }

        public PermissionResponse()
        {

        }

        public PermissionResponse(Permission permission)
        {
            ID = permission.ID;
            Name = permission.Name;
            ModuleId = permission.ModuleId;
        }
    }
}
