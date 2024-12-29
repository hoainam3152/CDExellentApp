using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class ReceiveService : IReceiveRepository
    {
        private readonly ManagementDbContext context;

        public ReceiveService(ManagementDbContext context)
        {
            this.context = context;
        }

        public ReceiveResponse? Create(ReceiveRequest request)
        {
            try
            {
                context.Receives.Add(new Receive()
                {
                    NotificationId = request.NotificationId,
                    ReceiverId = request.ReceiverId,
                    IsSeen = false
                });
                context.SaveChanges();
                var ob = context.Receives.OrderBy(ett =>
                            ett.NotificationId == request.NotificationId &&
                            ett.ReceiverId == request.ReceiverId
                        ).Last();
                return new ReceiveResponse(ob);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public ReceiveResponse? Delete(int NotificationId, int ReceiverId)
        {
            try
            {
                var ob = context.Receives.FirstOrDefault(ett =>
                            ett.NotificationId == NotificationId &&
                            ett.ReceiverId == ReceiverId
                         );
                if (ob != null)   //Data exist
                {
                    context.Receives.Remove(ob);
                    context.SaveChanges();
                    return new ReceiveResponse(ob);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<ReceiveResponse> GetAll()
        {
            return context.Receives
                .Select(ett => new ReceiveResponse()
                {
                    NotificationId = ett.NotificationId,
                    ReceiverId = ett.ReceiverId,
                    IsSeen = ett.IsSeen
                })
                .ToList();
        }

        public ReceiveResponse? GetById(int NotificationId, int ReceiverId)
        {
            var ob = context.Receives.FirstOrDefault(ett =>
                            ett.NotificationId == NotificationId &&
                            ett.ReceiverId == ReceiverId
                        );
            if (ob != null)
            {
                return new ReceiveResponse(ob);
            }
            return null;
        }
    }
}
