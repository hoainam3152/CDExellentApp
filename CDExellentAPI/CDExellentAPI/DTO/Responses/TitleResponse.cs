using CDExellentAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Responses
{
    public class TitleResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }

        public TitleResponse()
        {

        }

        public TitleResponse(Title title)
        {
            ID = title.ID;
            Name = title.Name;
            CategoryId = title.CategoryId;
            CreatedDate = title.CreatedDate;
        }
    }
}
