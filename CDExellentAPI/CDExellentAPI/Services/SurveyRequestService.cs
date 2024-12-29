using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class SurveyRequestService : ISurveyRequestRepository
    {
        private readonly ManagementDbContext context;

        public SurveyRequestService(ManagementDbContext context)
        {
            this.context = context;
        }

        public SurveyRequestResponse? Create(SurveyRequestCU request)
        {
            try
            {
                context.SurveyRequests.Add(new SurveyRequest()
                {
                    Title = request.Title,
                    SurveyId = request.SurveyId,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate
                });
                context.SaveChanges();
                var ob = context.SurveyRequests.OrderBy(ett => ett.ID).Last();
                return new SurveyRequestResponse(ob);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public SurveyRequestResponse? Delete(int id)
        {
            try
            {
                var ob = context.SurveyRequests.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    context.SurveyRequests.Remove(ob);
                    context.SaveChanges();
                    return new SurveyRequestResponse(ob);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<SurveyRequestResponse> GetAll()
        {
            return context.SurveyRequests
                .Select(ett => new SurveyRequestResponse()
                {
                    ID = ett.ID,
                    Title = ett.Title,
                    SurveyId = ett.SurveyId,
                    StartDate = ett.StartDate,
                    EndDate = ett.EndDate,
                })
                .ToList();
        }

        public SurveyRequestResponse? GetById(int id)
        {
            var ob = context.SurveyRequests.FirstOrDefault(ett => ett.ID == id);
            if (ob != null)
            {
                return new SurveyRequestResponse(ob);
            }
            return null;
        }

        public SurveyRequestResponse? Update(int id, SurveyRequestCU request)
        {
            try
            {
                var ob = context.SurveyRequests.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    ob.Title = request.Title;
                    ob.SurveyId = request.SurveyId;
                    ob.StartDate = request.StartDate;
                    ob.EndDate = request.EndDate;
                    context.SaveChanges();
                    return new SurveyRequestResponse(ob);
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
