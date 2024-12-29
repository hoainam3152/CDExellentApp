using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class PermissionService : IPermissionRepository
    {
        private readonly ManagementDbContext context;

        public PermissionService(ManagementDbContext context)
        {
            this.context = context;
        }

        public PermissionResponse? Create(PermissionRequest request)
        {
            try
            {
                context.Permissions.Add(new Permission()
                {
                    Name = request.Name,
                    ModuleId = request.ModuleId
                });
                context.SaveChanges();
                var ob = context.Permissions.OrderBy(ett => ett.ID).Last();
                return new PermissionResponse(ob);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public PermissionResponse? Delete(int id)
        {
            try
            {
                var ob = context.Permissions.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    context.Permissions.Remove(ob);
                    context.SaveChanges();
                    return new PermissionResponse(ob);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<PermissionResponse> GetAll()
        {
            return context.Permissions
                .Select(ett => new PermissionResponse()
                {
                    ID = ett.ID,
                    Name = ett.Name,
                    ModuleId = ett.ModuleId
                })
                .ToList();
        }

        public PermissionResponse? GetById(int id)
        {
            var ob = context.Permissions.FirstOrDefault(ett => ett.ID == id);
            if (ob != null)
            {
                return new PermissionResponse(ob);
            }
            return null;
        }

        public PermissionResponse? Update(int id, PermissionRequest request)
        {
            try
            {
                var ob = context.Permissions.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    ob.Name = request.Name;
                    ob.ModuleId = request.ModuleId;
                    context.SaveChanges();
                    return new PermissionResponse(ob);
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
