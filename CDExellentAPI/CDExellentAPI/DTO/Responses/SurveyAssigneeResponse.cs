using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Responses
{
    public class SurveyAssigneeResponse
    {
        public int SurveyRequestId { get; set; }
        public int AssigneeId { get; set; }
        public bool? IsFinished { get; set; }

        public SurveyAssigneeResponse()
        {

        }

        public SurveyAssigneeResponse(SurveyAssignee surveyassignee)
        {
            SurveyRequestId = surveyassignee.SurveyRequestId;
            AssigneeId = surveyassignee.AssigneeId;
            IsFinished = surveyassignee.IsFinished;
        }
    }
}
