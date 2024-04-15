using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Business_Platform.Model.BaseModel;
using Business_Platform.Model.Identity;

namespace Business_Platform.Model.Clothing
{
    public class ClothingProduct : BaseProductModel
    {

        public string Size { get; set; } = ""; // Ayrı bir model oluşturabilir

        public string Color { get; set; } = ""; // Ayrı bir model oluşturabilir

        public string Pattern { get; set; } = ""; // Ayrı bir model oluşturabilir

        public string FabricType { get; set; } = ""; // Ayrı bir model oluşturabilir

        public int ClothingTypeId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Description { get; set; }
        public long AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; } // Ürün Satıcısı

        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }

        [ForeignKey("ClothingTypeId")]
        public ClothingType? ClothingType { get; set; }
        public int ClothingCompanyId { get; set; }

        [ForeignKey("ClothingCompanyId")]
        public ClothingCompany? ClothingCompany { get; set; }

        public int ClothingCompanyBranchId { get; set; }

        [ForeignKey("ClothingCompanyBranchId")]
        public ClothingCompanyBranch? ClothingCompanyBranch { get; set; }

        public List<ClothingProductComment>? ProductComments { get; set; }
        public List<ClothingProductOffer>? ClothingOffer { get; set; }
        public List<ClothingCompBranchProduct>? ClothingCompBranchProducts { get; set; }

    }
}
