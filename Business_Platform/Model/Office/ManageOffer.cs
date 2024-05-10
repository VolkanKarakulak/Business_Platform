using Business_Platform.Model.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using static Business_Platform.Model.Office.OfficeProductOffer;

namespace Business_Platform.Model.Office
{
    public class ManageOffer
    {
        public int Id { get; set; }

        public DateTime OfferDate { get; set; }

        //public int Quantity { get; set; }
        public double OfferPrice { get; set; }

        public OfferStatus Status { get; set; }

        public int? OfficeCompanyBranchId { get; set; }

        [ForeignKey("OfficeCompanyBranchId")]
        public OfficeCompanyBranch? OfficeCompanyBranch { get; set; }

        public int? OfficeCompanyId { get; set; }

        [ForeignKey("OfficeCompanyId")]
        public OfficeCompany? OfficeCompany { get; set; }

        public int? OfficeProductOfferId {  get; set; }

        [ForeignKey("OfficeProductOfferId")]
        public OfficeProductOffer? OfficeProductOffer { get; set; }

        public long? AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; }

        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public OfficeProdBranchProduct? OfficeProdBranchProduct { get; set; }

  


    }
}
