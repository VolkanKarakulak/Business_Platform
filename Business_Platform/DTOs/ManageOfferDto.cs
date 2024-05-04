using static Business_Platform.Model.Office.OfficeProductOffer;

namespace Business_Platform.DTOs
{
    public class ManageOfferDto
    {
        public DateTime OfferDate { get; set; }
        public double OfferPrice { get; set; }
        public OfferStatus Status { get; set; }
        public int OfficeProductOfferId { get; set; }
        public string? OfficeProdBranchProductName { get; set; }
    }
}
