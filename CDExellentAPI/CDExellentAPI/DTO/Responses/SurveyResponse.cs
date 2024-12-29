using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Responses
{
    public class SurveyResponse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? QuestionCount { get; set; }
        public bool Status { get; set; }

        public SurveyResponse()
        {

        }

        public SurveyResponse(Survey survey)
        {
            ID = survey.ID;
            Title = survey.Title;
            CreatorId = survey.CreatorId;
            CreatedDate = survey.CreatedDate;
            QuestionCount = survey.Questions?.Count ?? 0;
            Status = survey.Status;
        }
    }
}
