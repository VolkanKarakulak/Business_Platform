using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Office
{
    public class OfficeProdBranchProduct 
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int Quantity { get; set; }

        public int Price { get; set; }

        public string Color { get; set; } = ""; 

        public string Material { get; set; } = "";
        [Column(TypeName = "nvarchar(200)")]
        public string? Description { get; set; }
        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }

        public int? ProductTypeId { get; set; }

        [ForeignKey("ProductTypeId")]
        public OfficeProductType? OfficeProductType { get; set; }

        public int OfficeCompanyId { get; set; }

        [ForeignKey("OfficeCompanyId")]
        public OfficeCompany? OfficeCompany { get; set; }

        public int OfficeProductId { get; set; }

        [ForeignKey("OfficeProductId")]
        public OfficeProduct? OfficeProduct { get; set; }

        public int OfficeCompanyBranchId { get; set; }

        [ForeignKey("OfficeCompanyBranchId")]
        public OfficeCompanyBranch? OfficeCompanyBranch { get; set; }

        public List<OfficeProductOffer>? OfficeProductOffers { get; set; }

        public List<BranchProductComment>? OfficeProductComments { get; set; }
       
    }
}
