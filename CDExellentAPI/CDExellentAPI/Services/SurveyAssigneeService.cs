using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class SurveyAssigneeService : ISurveyAssigneeRepository
    {
        private readonly ManagementDbContext context;

        public SurveyAssigneeService(ManagementDbContext context)
        {
            this.context = context;
        }

        public SurveyAssigneeResponse? Create(SurveyAssigneeRequest request)
        {
            try
            {
                context.SurveyAssignees.Add(new SurveyAssignee()
                {
                    SurveyRequestId = request.SurveyRequestId,
                    AssigneeId = request.AssigneeId,
                    IsFinished = false
                });
                context.SaveChanges();
                var ob = context.SurveyAssignees.OrderBy(ett => 
                            ett.SurveyRequestId == request.SurveyRequestId &&
                            ett.AssigneeId == request.AssigneeId
                        ).Last();
                return new SurveyAssigneeResponse(ob);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public SurveyAssigneeResponse? Delete(int SurveyRequestId, int AssigneeId)
        {
            try
            {
                var ob = context.SurveyAssignees.FirstOrDefault(ett => 
                            ett.SurveyRequestId == SurveyRequestId &&
                            ett.AssigneeId == AssigneeId
                         );
                if (ob != null)   //Data exist
                {
                    context.SurveyAssignees.Remove(ob);
                    context.SaveChanges();
                    return new SurveyAssigneeResponse(ob);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<SurveyAssigneeResponse> GetAll()
        {
            return context.SurveyAssignees
                .Select(ett => new SurveyAssigneeResponse()
                {
                    SurveyRequestId = ett.SurveyRequestId,
                    AssigneeId = ett.AssigneeId,
                    IsFinished = ett.IsFinished
                })
                .ToList();
        }

        public SurveyAssigneeResponse? GetById(int SurveyRequestId, int AssigneeId)
        {
            var ob = context.SurveyAssignees.FirstOrDefault(ett => 
                            ett.SurveyRequestId == SurveyRequestId &&
                            ett.AssigneeId == AssigneeId
                        );
            if (ob != null)
            {
                return new SurveyAssigneeResponse(ob);
            }
            return null;
        }
    }
}
