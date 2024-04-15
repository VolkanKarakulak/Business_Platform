using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Business_Platform.Model.BaseModel;

namespace Business_Platform.Model.Clothing
{
    public class ClothingProduct : BaseProductModel
    {
        public string Size { get; set; } = ""; // Ayrı bir model oluşturabilir

        public string Color { get; set; } = ""; // Ayrı bir model oluşturabilir

        public string Pattern { get; set; } = ""; // Ayrı bir model oluşturabilir

        public string FabricType { get; set; } = ""; // Ayrı bir model oluşturabilir

        public int ClothingTypeId { get; set; }

        [ForeignKey("ClothingTypeId")]
        public ClothingType? ClothingType { get; set; }

        public List<ClothingProductComment>? ProductComments { get; set; }
        public List<ClothingProductOffer>? ClothingOffer { get; set; }



    }
}
