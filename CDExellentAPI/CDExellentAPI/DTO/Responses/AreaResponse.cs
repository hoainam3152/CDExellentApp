using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Responses
{
    public class AreaResponse
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public AreaResponse()
        {
            
        }

        public AreaResponse(Area area)
        {
            ID = area.ID;
            Name = area.Name;
        }
    }
}
