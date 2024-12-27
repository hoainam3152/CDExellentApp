using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class UserService : IUserRepository
    {
        private readonly ManagementDbContext context;

        public UserService(ManagementDbContext context)
        {
            this.context = context;
        }

        public UserResponse? Create(UserRequest request)
        {
            try
            {
                context.Users.Add(new User()
                {
                    Name = request.Name,
                    Email = request.Email,
                    TitleId = request.TitleId,
                    Status = request.Status
                });
                context.SaveChanges();
                //var us = context.Users.OrderBy(ett => ett.ID).Last();
                return new UserResponse(/*us*/);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public UserResponse? Delete(int id)
        {
            try
            {
                var us = context.Users.FirstOrDefault(ett => ett.ID == id);
                if (us != null)   //Data exist
                {
                    context.Users.Remove(us);
                    context.SaveChangesAsync();
                    return new UserResponse(us);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<UserResponse> GetAll()
        {
            return context.Users
                .Select(ett => new UserResponse()
                {
                    ID = ett.ID,
                    Name = ett.Name,
                    Email = ett.Email,
                    TitleId = ett.TitleId,
                    Status = ett.Status
                })
                .ToList();
        }

        public UserResponse? GetById(int id)
        {
            var us = context.Users.FirstOrDefault(ett => ett.ID == id);
            if (us != null)
            {
                return new UserResponse(us);
            }
            return null;
        }

        public UserResponse? Update(int id, UserRequest request)
        {
            try
            {
                var us = context.Users.FirstOrDefault(ett => ett.ID == id);
                if (us != null)   //Data exist
                {
                    us.Name = request.Name;
                    us.Email = request.Email;
                    us.TitleId = request.TitleId;
                    us.Status = request.Status;
                    context.SaveChangesAsync();
                    return new UserResponse(us);
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
