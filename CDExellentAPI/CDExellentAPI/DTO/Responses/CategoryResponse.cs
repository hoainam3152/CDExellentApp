using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Responses
{
    public class CategoryResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public CategoryResponse()
        {

        }

        public CategoryResponse(Category cat)
        {
            ID = cat.ID;
            Name = cat.Name;
        }
    }
}
