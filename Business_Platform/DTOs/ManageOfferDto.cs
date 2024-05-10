using static Business_Platform.Model.Office.OfficeProductOffer;

namespace Business_Platform.DTOs
{
    public class ManageOfferDto
    {
        public DateTime OfferDate { get; set; }
        public double OfferPrice { get; set; }
        public OfferStatus Status { get; set; }

        //public int? OfficeProductOffer { get; set; } // Kontrol edilecek
        public string? AppUserName { get; set; }
        public string? OfficeCompanyName { get; set; }
        public string? OfficeCompanyBranchName { get; set; }
        public string? OfficeProdBranchProductName { get; set; }
    }
}
