using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Enums;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class TaskService : ITaskRepository
    {
        private readonly ManagementDbContext context;

        public TaskService(ManagementDbContext context)
        {
            this.context = context;
        }

        public TaskResponse? Create(TaskCreate request)
        {
            try
            {
                context.Tasks.Add(new Entities.Task()
                {
                    Title = request.Title,
                    AssigneeId = request.AssigneeId,
                    ReporterId = request.ReporterId,
                    Description = request.Description,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    PlanUserId = request.PlanUserId,
                    CreatedDate = DateTime.Now,
                    TaskStatusId = ETaskStatus.NEW,
                    VisitPlanId = request.VisitPlanId,
                });
                context.SaveChanges();
                var ob = context.Tasks.OrderBy(ett => ett.ID).Last();
                return new TaskResponse(ob);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public TaskResponse? Delete(int id)
        {
            try
            {
                var ob = context.Tasks.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    context.Tasks.Remove(ob);
                    context.SaveChanges();
                    return new TaskResponse(ob);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<TaskResponse> GetAll()
        {
            return context.Tasks
                .Select(ett => new TaskResponse()
                {
                    ID = ett.ID,
                    Title = ett.Title,
                    AssigneeId = ett.AssigneeId,
                    ReporterId = ett.ReporterId,
                    Description = ett.Description,
                    StartDate = ett.StartDate,
                    EndDate = ett.EndDate,
                    PlanUserId = ett.PlanUserId,
                    CreatedDate = ett.CreatedDate,
                    TaskStatusId = ett.TaskStatusId,
                    VisitPlanId = ett.VisitPlanId,
                })
                .ToList();
        }

        public TaskResponse? GetById(int id)
        {
            var ob = context.Tasks.FirstOrDefault(ett => ett.ID == id);
            if (ob != null)
            {
                return new TaskResponse(ob);
            }
            return null;
        }

        public TaskResponse? Update(int id, TaskUpdate request)
        {
            try
            {
                var ob = context.Tasks.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    ob.Title = request.Title;
                    ob.AssigneeId = request.AssigneeId;
                    ob.ReporterId = request.ReporterId;
                    ob.Description = request.Description;
                    ob.StartDate = request.StartDate;
                    ob.EndDate = request.EndDate;
                    context.SaveChanges();
                    return new TaskResponse(ob);
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
