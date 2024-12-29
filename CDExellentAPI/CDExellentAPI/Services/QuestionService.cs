using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class QuestionService : IQuestionRepository
    {
        private readonly ManagementDbContext context;

        public QuestionService(ManagementDbContext context)
        {
            this.context = context;
        }

        public QuestionResponse? Create(QuestionCreate request)
        {
            try
            {
                context.Questions.Add(new Question()
                {
                    Content = request.Content,
                    IsMultiSelect = request.IsMultiSelect,
                    ImagePath = request.ImagePath,
                    SurveyId = request.SurveyId
                });
                context.SaveChanges();
                var ob = context.Questions.OrderBy(ett => ett.ID).Last();
                return new QuestionResponse(ob);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public QuestionResponse? Delete(int id)
        {
            try
            {
                var ob = context.Questions.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    context.Questions.Remove(ob);
                    context.SaveChanges();
                    return new QuestionResponse(ob);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<QuestionResponse> GetAll()
        {
            return context.Questions
                .Select(ett => new QuestionResponse()
                {
                    ID = ett.ID,
                    Content = ett.Content,
                    IsMultiSelect = ett.IsMultiSelect,
                    ImagePath = ett.ImagePath,
                    SurveyId = ett.SurveyId
                })
                .ToList();
        }

        public QuestionResponse? GetById(int id)
        {
            var ob = context.Questions.FirstOrDefault(ett => ett.ID == id);
            if (ob != null)
            {
                return new QuestionResponse(ob);
            }
            return null;
        }

        public QuestionResponse? Update(int id, QuestionUpdate request)
        {
            try
            {
                var ob = context.Questions.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    ob.Content = request.Content;
                    ob.IsMultiSelect = request.IsMultiSelect;
                    ob.ImagePath = request.ImagePath;
                    context.SaveChanges();
                    return new QuestionResponse(ob);
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
