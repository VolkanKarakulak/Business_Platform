using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Business_Platform.Model.BaseModel;
using Business_Platform.Model.Identity;

namespace Business_Platform.Model.Office
{
    public class OfficeProduct : BaseProductModel
    {

        public string Color { get; set; } = ""; // Ayrı bir model oluşturabilir

        public string Material { get; set; } = ""; // Ayrı bir model oluşturabilir

        [Column(TypeName = "nvarchar(200)")]
        public string? Description { get; set; }
        public long AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; } // Ürün Satıcısı

        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }

        public int? ProductTypeId { get; set; }

        [ForeignKey("ProductTypeId")]
        public OfficeProductType? OfficeProductType { get; set; }
        public int OfficeCompanyId { get; set; }

        [ForeignKey("OfficeCompanyId")]
        public OfficeCompany? OfficeCompany { get; set; }

        public int OfficeCompanyBranchId { get; set; }

        [ForeignKey("OfficeCompanyBranchId")]
        public OfficeCompanyBranch? OfficeCompanyBranch { get; set; }

        public List<OfficeProductComment>? ProductComments { get; set; }
        public List<OfficeProductOffer>? OfficeProductOffers { get; set; }
        public List<OfficeProdBranchProduct>? OfficeProdBranchProducts { get; set; }

    }
}
