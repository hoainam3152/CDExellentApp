using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Responses
{
    public class SurveyRequestResponse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int SurveyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public SurveyRequestResponse()
        {

        }

        public SurveyRequestResponse(SurveyRequest surveyrequest)
        {
            ID = surveyrequest.ID;
            Title = surveyrequest.Title;
            SurveyId = surveyrequest.SurveyId;
            StartDate = surveyrequest.StartDate;
            EndDate = surveyrequest.EndDate;
        }
    }
}
