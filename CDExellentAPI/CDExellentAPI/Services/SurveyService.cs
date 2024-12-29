using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class SurveyService : ISurveyRepository
    {
        private readonly ManagementDbContext context;

        public SurveyService(ManagementDbContext context)
        {
            this.context = context;
        }

        public SurveyResponse? Create(SurveyCreate request)
        {
            try
            {
                context.Surveys.Add(new Survey()
                {
                    Title = request.Title,
                    CreatorId = request.CreatorId,
                    CreatedDate = DateTime.Now,
                    Status = true
                });
                context.SaveChanges();
                var ob = context.Surveys.OrderBy(ett => ett.ID).Last();
                return new SurveyResponse(ob);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public SurveyResponse? Delete(int id)
        {
            try
            {
                var ob = context.Surveys.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    context.Surveys.Remove(ob);
                    context.SaveChanges();
                    return new SurveyResponse(ob);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<SurveyResponse> GetAll()
        {
            return context.Surveys
                .Select(ett => new SurveyResponse()
                {
                    ID = ett.ID,
                    Title = ett.Title,
                    CreatorId = ett.CreatorId,
                    CreatedDate = ett.CreatedDate,
                    QuestionCount = ett.Questions.Count,
                    Status = ett.Status,
                })
                .ToList();
        }

        public SurveyResponse? GetById(int id)
        {
            var ob = context.Surveys.Include(sv => sv.Questions).FirstOrDefault(ett => ett.ID == id);
            if (ob != null)
            {
                return new SurveyResponse(ob);
            }
            return null;
        }

        public SurveyResponse? Update(int id, SurveyUpdate request)
        {
            try
            {
                var ob = context.Surveys.Include(sv => sv.Questions).FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    ob.Title = request.Title;
                    context.SaveChanges();
                    return new SurveyResponse(ob);
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
