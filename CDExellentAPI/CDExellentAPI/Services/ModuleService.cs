using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class ModuleService : IModuleRepository
    {
        private readonly ManagementDbContext context;

        public ModuleService(ManagementDbContext context)
        {
            this.context = context;
        }

        public ModuleResponse? Create(ModuleRequest request)
        {
            try
            {
                context.Modules.Add(new Module()
                {
                    Name = request.Name
                });
                context.SaveChanges();
                var ob = context.Modules.OrderBy(ett => ett.ID).Last();
                return new ModuleResponse(ob);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public ModuleResponse? Delete(int id)
        {
            try
            {
                var ob = context.Modules.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    context.Modules.Remove(ob);
                    context.SaveChanges();
                    return new ModuleResponse(ob);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<ModuleResponse> GetAll()
        {
            return context.Modules
                .Select(ett => new ModuleResponse()
                {
                    ID = ett.ID,
                    Name = ett.Name
                })
                .ToList();
        }

        public ModuleResponse? GetById(int id)
        {
            var ob = context.Modules.FirstOrDefault(ett => ett.ID == id);
            if (ob != null)
            {
                return new ModuleResponse(ob);
            }
            return null;
        }

        public ModuleResponse? Update(int id, ModuleRequest request)
        {
            try
            {
                var ob = context.Modules.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    ob.Name = request.Name;
                    context.SaveChanges();
                    return new ModuleResponse(ob);
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
