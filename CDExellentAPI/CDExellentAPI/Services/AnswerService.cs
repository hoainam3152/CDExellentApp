using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Services
{
    public class AnswerService : IAnswerRepository
    {
        private readonly ManagementDbContext context;

        public AnswerService(ManagementDbContext context)
        {
            this.context = context;
        }

        public AnswerResponse? Create(AnswerCreate request)
        {
            try
            {
                context.Answers.Add(new Answer()
                {
                    Content = request.Content,
                    QuestionId = request.QuestionId
                });
                context.SaveChanges();
                var ob = context.Answers.OrderBy(ett => ett.ID).Last();
                return new AnswerResponse(ob);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public AnswerResponse? Delete(int id)
        {
            try
            {
                var ob = context.Answers.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    context.Answers.Remove(ob);
                    context.SaveChanges();
                    return new AnswerResponse(ob);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<AnswerResponse> GetAll()
        {
            return context.Answers
                .Select(ett => new AnswerResponse()
                {
                    ID = ett.ID,
                    Content = ett.Content,
                    QuestionId = ett.QuestionId
                })
                .ToList();
        }

        public AnswerResponse? GetById(int id)
        {
            var ob = context.Answers.FirstOrDefault(ett => ett.ID == id);
            if (ob != null)
            {
                return new AnswerResponse(ob);
            }
            return null;
        }

        public AnswerResponse? Update(int id, AnswerUpdate request)
        {
            try
            {
                var ob = context.Answers.FirstOrDefault(ett => ett.ID == id);
                if (ob != null)   //Data exist
                {
                    ob.Content = request.Content;
                    context.SaveChanges();
                    return new AnswerResponse(ob);
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
