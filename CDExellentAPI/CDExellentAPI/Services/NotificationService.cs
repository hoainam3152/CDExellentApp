using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class NotificationService : INotificationRepository
    {
        private readonly ManagementDbContext context;

        public NotificationService(ManagementDbContext context)
        {
            this.context = context;
        }

        public NotificationResponse? Create(NotificationRequest request)
        {
            try
            {
                context.Notifications.Add(new Notification()
                {
                    Title = request.Title,
                    Content = request.Content,
                    CreatorId = request.CreatorId,
                    CreatedDate = DateTime.Now
                });
                context.SaveChanges();
                var ob = context.Notifications.OrderBy(ett => ett.ID).Last();
                return new NotificationResponse(ob);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public NotificationResponse? Delete(int id)
        {
            try
            {
                var ob = context.Notifications.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    context.Notifications.Remove(ob);
                    context.SaveChanges();
                    return new NotificationResponse(ob);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<NotificationResponse> GetAll()
        {
            return context.Notifications
                .Select(ett => new NotificationResponse()
                {
                    ID = ett.ID,
                    Title = ett.Title,
                    Content = ett.Content,
                    CreatorId = ett.CreatorId,
                    CreatedDate = ett.CreatedDate,
                })
                .ToList();
        }

        public NotificationResponse? GetById(int id)
        {
            var ob = context.Notifications.FirstOrDefault(ett => ett.ID == id);
            if (ob != null)
            {
                return new NotificationResponse(ob);
            }
            return null;
        }
    }
}
