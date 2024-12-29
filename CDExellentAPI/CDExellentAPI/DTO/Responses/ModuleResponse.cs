using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Responses
{
    public class ModuleResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ModuleResponse()
        {

        }

        public ModuleResponse(Module module)
        {
            ID = module.ID;
            Name = module.Name;
        }
    }
}
