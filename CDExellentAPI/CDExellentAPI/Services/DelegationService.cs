using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class DelegationService : IDelegationRepository
    {
        private readonly ManagementDbContext context;

        public DelegationService(ManagementDbContext context)
        {
            this.context = context;
        }

        public DelegationResponse? Create(DelegationRequest request)
        {
            try
            {
                context.Delegations.Add(new Delegation()
                {
                    UserId = request.UserId,
                    PermissionId = request.PermissionId
                });
                context.SaveChanges();
                var ob = context.Delegations.OrderBy(ett =>
                            ett.UserId == request.UserId &&
                            ett.PermissionId == request.PermissionId
                        ).Last();
                return new DelegationResponse(ob);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public DelegationResponse? Delete(int UserId, int PermissionId)
        {
            try
            {
                var ob = context.Delegations.FirstOrDefault(ett =>
                            ett.UserId == UserId &&
                            ett.PermissionId == PermissionId
                         );
                if (ob != null)   //Data exist
                {
                    context.Delegations.Remove(ob);
                    context.SaveChanges();
                    return new DelegationResponse(ob);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<DelegationResponse> GetAll()
        {
            return context.Delegations
                .Select(ett => new DelegationResponse()
                {
                    UserId = ett.UserId,
                    PermissionId = ett.PermissionId
                })
                .ToList();
        }

        public DelegationResponse? GetById(int UserId, int PermissionId)
        {
            var ob = context.Delegations.FirstOrDefault(ett =>
                            ett.UserId == UserId &&
                            ett.PermissionId == PermissionId
                        );
            if (ob != null)
            {
                return new DelegationResponse(ob);
            }
            return null;
        }
    }
}
