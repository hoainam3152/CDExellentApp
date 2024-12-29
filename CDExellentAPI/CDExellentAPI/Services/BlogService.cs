using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Enums;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class BlogService : IBlogRepository
    {
        private readonly ManagementDbContext context;

        public BlogService(ManagementDbContext context)
        {
            this.context = context;
        }

        public BlogResponse? Create(BlogCreate request)
        {
            try
            {
                context.Blogs.Add(new Blog()
                {
                    Title = request.Title,
                    FilePath = request.FilePath,
                    Description = request.Description,
                    ImagePath = request.ImagePath,
                    CreatorId = request.CreatorId,
                    CreatedDate = DateTime.Now,
                    Status = false,
                });
                context.SaveChanges();
                var ob = context.Blogs.OrderBy(ett => ett.ID).Last();
                return new BlogResponse(ob);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public BlogResponse? Delete(int id)
        {
            try
            {
                var ob = context.Blogs.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    context.Blogs.Remove(ob);
                    context.SaveChanges();
                    return new BlogResponse(ob);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<BlogResponse> GetAll()
        {
            return context.Blogs
                .Select(ett => new BlogResponse()
                {
                    ID = ett.ID,
                    Title = ett.Title,
                    FilePath = ett.FilePath,
                    Description = ett.Description,
                    ImagePath = ett.ImagePath,
                    CreatorId = ett.CreatorId,
                    CreatedDate = ett.CreatedDate,
                    Status = ett.Status,
                })
                .ToList();
        }

        public BlogResponse? GetById(int id)
        {
            var ob = context.Blogs.FirstOrDefault(ett => ett.ID == id);
            if (ob != null)
            {
                return new BlogResponse(ob);
            }
            return null;
        }

        public BlogResponse? Update(int id, BlogUpdate request)
        {
            try
            {
                var ob = context.Blogs.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    ob.Title = request.Title;
                    ob.FilePath = request.FilePath;
                    ob.Description = request.Description;
                    ob.ImagePath = request.ImagePath;
                    context.SaveChanges();
                    return new BlogResponse(ob);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }
    }
}
