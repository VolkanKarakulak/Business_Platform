using static Business_Platform.Model.Office.OfficeProductOffer;

namespace Business_Platform.DTOs.OfficeProductOfferDtos
{
    public class OfficeProductOfferGet
    {
        public int? Id { get; set; }
        public double OfferPrice { get; set; }
        public DateTime OfferDate { get; set; }
        public string? Name { get; set; }
        public string? OfficeCompanyName { get; set; }
        public string? OfficeCompanyBranchName { get; set; }
        public string? OfficeProdBranchProductName { get; set; }
        public OfferStatus Status { get; set; } 
    }
}
