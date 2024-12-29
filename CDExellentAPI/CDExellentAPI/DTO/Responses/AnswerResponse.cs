using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Responses
{
    public class AnswerResponse
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }

        public AnswerResponse()
        {

        }

        public AnswerResponse(Answer answer)
        {
            ID = answer.ID;
            Content = answer.Content;
            QuestionId = answer.QuestionId;
        }
    }
}
