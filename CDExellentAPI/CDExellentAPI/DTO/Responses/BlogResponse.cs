using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Responses
{
    public class BlogResponse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string? FilePath { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }

        public BlogResponse()
        {

        }

        public BlogResponse(Blog blog)
        {
            ID = blog.ID;
            Title = blog.Title;
            FilePath = blog.FilePath;
            Description = blog.Description;
            ImagePath = blog.ImagePath;
            CreatorId = blog.CreatorId;
            CreatedDate = blog.CreatedDate;
            Status = blog.Status;
        }
    }
}
