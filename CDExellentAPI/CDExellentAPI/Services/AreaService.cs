using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;

namespace CDExellentAPI.Services
{
    public class AreaService : IAreaRepository
    {
        private readonly ManagementDbContext context;

        public AreaService(ManagementDbContext context)
        {
            this.context = context;
        }
        public AreaResponse Create(AreaCreate request)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
                return new AreaResponse()
                {
                    ID = area.ID,
                    Name = area.Name
                };
            }
            return null;
        }

        public void Update(AreaUpdate request)
        {
            throw new NotImplementedException();
        }
    }
}
