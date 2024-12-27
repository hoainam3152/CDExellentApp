using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Responses
{
    public class DistributorResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int SalesManagementId { get; set; }
        public int? SalesId { get; set; }
        public bool Status { get; set; }
        public string? AreaId { get; set; }

        public DistributorResponse()
        {

        }

        public DistributorResponse(Distributor distributor)
        {
            ID = distributor.ID;
            Name = distributor.Name;
            Email = distributor.Email;
            Address = distributor.Address;
            PhoneNumber = distributor.PhoneNumber;
            SalesManagementId = distributor.SalesManagementId;
            SalesId = distributor.SalesId;
            Status = distributor.Status;
            AreaId = distributor.AreaId;
        }
    }
}
