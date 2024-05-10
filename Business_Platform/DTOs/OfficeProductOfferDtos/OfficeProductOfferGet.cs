using static Business_Platform.Model.Office.OfficeProductOffer;

namespace Business_Platform.DTOs.OfficeProductOfferDtos
{
    public class OfficeProductOfferGet
    {
        public int? Id { get; set; }
        public double OfferPrice { get; set; }
        public DateTime OfferDate { get; set; }
        public long UserId { get; set; }
        public int? OfficeCompanyId { get; set; }
        public int? OfficeCompanyBranchId { get; set; }
        public int? OfficeProdBranchProductId { get; set; }
        public OfferStatus Status { get; set; } 
    }
}
