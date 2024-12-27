using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class VisitPlanService : IVisitPlanRepository
    {
        private readonly ManagementDbContext context;

        public VisitPlanService(ManagementDbContext context)
        {
            this.context = context;
        }

        public VisitPlanResponse? Create(VisitPlanRequest request)
        {
            try
            {
                context.VisitPlans.Add(new VisitPlan()
                {
                    PlanDate = request.PlanDate,
                    TypeDateId = request.TypeDateId,
                    DistributorId = request.DistributorId,
                    Purpose = request.Purpose,
                    PlanUserId = request.PlanUserId,
                    CreatedDate = DateTime.Now,
                    PlanStatusId = request.PlanStatusId,
                });
                context.SaveChanges();
                var vp = context.VisitPlans.OrderBy(ett => ett.ID).Last();
                return new VisitPlanResponse(vp);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public VisitPlanResponse? Delete(int id)
        {
            try
            {
                var vp = context.VisitPlans.FirstOrDefault(ett => ett.ID == id);
                if (vp != null)   //Data exist
                {
                    context.VisitPlans.Remove(vp);
                    context.SaveChanges();
                    return new VisitPlanResponse(vp);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<VisitPlanResponse> GetAll()
        {
            return context.VisitPlans
                .Select(ett => new VisitPlanResponse()
                {
                    ID = ett.ID,
                    PlanDate = ett.PlanDate,
                    TypeDateId = ett.TypeDateId,
                    DistributorId = ett.DistributorId,
                    Purpose = ett.Purpose,
                    PlanUserId = ett.PlanUserId,
                    CreatedDate = ett.CreatedDate,
                    PlanStatusId = ett.PlanStatusId,
                })
                .ToList();
        }

        public VisitPlanResponse? GetById(int id)
        {
            var vp = context.VisitPlans.FirstOrDefault(ett => ett.ID == id);
            if (vp != null)
            {
                return new VisitPlanResponse(vp);
            }
            return null;
        }

        public VisitPlanResponse? Update(int id, VisitPlanRequest request)
        {
            try
            {
                var vp = context.VisitPlans.FirstOrDefault(ett => ett.ID == id);
                if (vp != null)   //Data exist
                {
                    vp.PlanDate = request.PlanDate;
                    vp.TypeDateId = request.TypeDateId;
                    vp.DistributorId = request.DistributorId;
                    vp.Purpose = request.Purpose;
                    vp.PlanStatusId = request.PlanStatusId;
                    context.SaveChanges();
                    return new VisitPlanResponse(vp);
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
