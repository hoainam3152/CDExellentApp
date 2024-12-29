using CDExellentAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Responses
{
    public class QuestionResponse
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public bool? IsMultiSelect { get; set; }
        public string? ImagePath { get; set; }
        public int SurveyId { get; set; }

        public QuestionResponse()
        {

        }

        public QuestionResponse(Question question)
        {
            ID = question.ID;
            Content = question.Content;
            IsMultiSelect = question.IsMultiSelect;
            ImagePath = question.ImagePath;
            SurveyId = question.SurveyId;
        }
    }
}
