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

        public int OfficeProductTypeId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Description { get; set; }
        public long AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; } // Ürün Satıcısı

        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }

        [ForeignKey("OfficeTypeId")]
        public OfficeProductType? OfficeProductType { get; set; }
        public int OfficeCompanyId { get; set; }

        [ForeignKey("OfficeCompanyId")]
        public OfficeCompany? OfficeCompany { get; set; }

        public int OfficeCompanyBranchId { get; set; }

        [ForeignKey("OfficeCompanyBranchId")]
        public OfficeCompanyBranch? OfficeCompanyBranch { get; set; }

        public List<OfficeProductComment>? ProductComments { get; set; }
        public List<OfficeProductOffer>? OfficeProductOffer { get; set; }
        public List<OfficeProdBranchProduct>? OfficeProdBranchProducts { get; set; }

    }
}
