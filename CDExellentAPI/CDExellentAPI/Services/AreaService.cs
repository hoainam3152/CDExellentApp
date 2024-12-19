using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class AreaService : IAreaRepository
    {
        private readonly ManagementDbContext context;

        public AreaService(ManagementDbContext context)
        {
            this.context = context;
        }

        public AreaResponse? Create(AreaCreate request)
        {
            try
            {
                var area = context.Areas.FirstOrDefault(ar => ar.ID == request.ID);
                if (area == null)   //Data not exist
                {
                    context.Areas.Add(new Area()
                    {
                        ID = request.ID,
                        Name = request.Name
                    });
                    context.SaveChangesAsync();
                    return null;    
                }
                return new AreaResponse(area);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public AreaResponse? Delete(string id)
        {
            try
            {
                var area = context.Areas.FirstOrDefault(ar => ar.ID == id);
                if (area != null)   //Data exist
                {
                    context.Areas.Remove(area);
                    context.SaveChangesAsync();
                    return new AreaResponse(area);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<AreaResponse> GetAll()
        {
            return context.Areas
                .Select(ar => new AreaResponse()
                {
                    ID = ar.ID,
                    Name = ar.Name
                })
                .ToList();
        }

        public AreaResponse? GetById(string id)
        {
            var area = context.Areas.FirstOrDefault(ar => ar.ID == id);
            if (area != null)
            {
                return new AreaResponse(area);
            }
            return null;
        }

        public AreaResponse? Update(string id, AreaUpdate request)
        {
            try
            {
                var area = context.Areas.FirstOrDefault(ar => ar.ID == id);
                if (area != null)   //Data exist
                {
                    area.Name = request.Name;
                    context.SaveChangesAsync();
                    return new AreaResponse(area);
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
