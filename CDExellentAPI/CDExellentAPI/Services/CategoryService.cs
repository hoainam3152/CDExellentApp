using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly ManagementDbContext context;

        public CategoryService(ManagementDbContext context)
        {
            this.context = context;
        }

        public CategoryResponse? Create(CategoryRequest request)
        {
            try
            {
                context.Categories.Add(new Category()
                {
                    Name = request.Name
                });
                context.SaveChanges();
                var cat = context.Categories.OrderBy(cate => cate.ID).Last();
                return new CategoryResponse(cat);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public CategoryResponse? Delete(int id)
        {
            try
            {
                var cat = context.Categories.FirstOrDefault(ar => ar.ID == id);
                if (cat != null)   //Data exist
                {
                    context.Categories.Remove(cat);
                    context.SaveChangesAsync();
                    return new CategoryResponse(cat);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<CategoryResponse> GetAll()
        {
            return context.Categories
                .Select(cat => new CategoryResponse()
                {
                    ID = cat.ID,
                    Name = cat.Name
                })
                .ToList();
        }

        public CategoryResponse? GetById(int id)
        {
            var cat = context.Categories.FirstOrDefault(ar => ar.ID == id);
            if (cat != null)
            {
                return new CategoryResponse(cat);
            }
            return null;
        }

        public CategoryResponse? Update(int id, CategoryRequest request)
        {
            try
            {
                var cat = context.Categories.FirstOrDefault(ar => ar.ID == id);
                if (cat != null)   //Data exist
                {
                    cat.Name = request.Name;
                    context.SaveChangesAsync();
                    return new CategoryResponse(cat);
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
