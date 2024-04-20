using static Business_Platform.Model.Office.OfficeProductOffer;

namespace Business_Platform.ViewModel
{
    public class ManageOfferViewModel
    {
        public DateTime OfferDate { get; set; }
        public double OfferPrice { get; set; }
        public OfferStatus Status { get; set; }
        public int OfficeProductOfferId { get; set; }
        public string? OfficeProdBranchProductName { get; set; }
    }
}
