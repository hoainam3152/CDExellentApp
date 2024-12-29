using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class GuestService : IGuestRepository
    {
        private readonly ManagementDbContext context;

        public GuestService(ManagementDbContext context)
        {
            this.context = context;
        }

        public GuestResponse? Create(GuestRequest request)
        {
            try
            {
                context.Guests.Add(new Guest()
                {
                    VisitPlanId = request.VisitPlanId,
                    GuestUserId = request.GuestUserId,
                    IsAccept = true
                });
                context.SaveChanges();
                var ob = context.Guests.OrderBy(ett =>
                            ett.VisitPlanId == request.VisitPlanId &&
                            ett.GuestUserId == request.GuestUserId
                        ).Last();
                return new GuestResponse(ob);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public GuestResponse? Delete(int VisitPlanId, int GuestUserId)
        {
            try
            {
                var ob = context.Guests.FirstOrDefault(ett =>
                            ett.VisitPlanId == VisitPlanId &&
                            ett.GuestUserId == GuestUserId
                         );
                if (ob != null)   //Data exist
                {
                    context.Guests.Remove(ob);
                    context.SaveChanges();
                    return new GuestResponse(ob);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<GuestResponse> GetAll()
        {
            return context.Guests
                .Select(ett => new GuestResponse()
                {
                    VisitPlanId = ett.VisitPlanId,
                    GuestUserId = ett.GuestUserId,
                    IsAccept = ett.IsAccept
                })
                .ToList();
        }

        public GuestResponse? GetById(int VisitPlanId, int GuestUserId)
        {
            var ob = context.Guests.FirstOrDefault(ett =>
                            ett.VisitPlanId == VisitPlanId &&
                            ett.GuestUserId == GuestUserId
                        );
            if (ob != null)
            {
                return new GuestResponse(ob);
            }
            return null;
        }
    }
}
