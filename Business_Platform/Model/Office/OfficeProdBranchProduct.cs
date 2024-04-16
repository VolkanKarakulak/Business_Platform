using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Office
{
    public class OfficeProdBranchProduct
    {
        public int Id { get; set; }

        public int OfficeProductId { get; set; }
        [ForeignKey("OfficeProductId")]
        public OfficeProduct? OfficeProduct { get; set; }

        public int OfficeCompanyBranchId { get; set; }

        [ForeignKey("OfficeCompanyBranchId")]
        public OfficeCompanyBranch? OfficeCompanyBranch { get; set; }

        public int Quantity { get; set; }

        public List<OfficeProductOffer>? officeProductOffers { get; set; }
       
    }
}
