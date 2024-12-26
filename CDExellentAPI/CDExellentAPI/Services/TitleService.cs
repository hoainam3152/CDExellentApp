using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class TitleService : ITitleRepository
    {
        private readonly ManagementDbContext context;

        public TitleService(ManagementDbContext context)
        {
            this.context = context;
        }

        public TitleResponse? Create(TitleRequest request)
        {
            try
            {
                context.Titles.Add(new Title()
                {
                    Name = request.Name,
                    CategoryId = request.CategoryId,
                    CreatedDate = DateTime.Now
                });
                context.SaveChanges();
                var ti = context.Titles.OrderBy(tit => tit.ID).Last();
                return new TitleResponse(ti);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public TitleResponse? Delete(int id)
        {
            try
            {
                var ti = context.Titles.FirstOrDefault(ar => ar.ID == id);
                if (ti != null)   //Data exist
                {
                    context.Titles.Remove(ti);
                    context.SaveChangesAsync();
                    return new TitleResponse(ti);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<TitleResponse> GetAll()
        {
            return context.Titles
                .Select(ar => new TitleResponse()
                {
                    ID = ar.ID,
                    Name = ar.Name,
                    CategoryId = ar.CategoryId,
                    CreatedDate = ar.CreatedDate
                })
                .ToList();
        }

        public TitleResponse? GetById(int id)
        {
            var ti = context.Titles.FirstOrDefault(ar => ar.ID == id);
            if (ti != null)
            {
                return new TitleResponse(ti);
            }
            return null;
        }

        public TitleResponse? Update(int id, TitleRequest request)
        {
            try
            {
                var ti = context.Titles.FirstOrDefault(ar => ar.ID == id);
                if (ti != null)   //Data exist
                {
                    ti.Name = request.Name;
                    ti.CategoryId = request.CategoryId;
                    context.SaveChangesAsync();
                    return new TitleResponse(ti);
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
