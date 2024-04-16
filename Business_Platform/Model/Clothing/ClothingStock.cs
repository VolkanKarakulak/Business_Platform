using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Clothing
{
    public class ClothingStock
    {
        public int Id { get; set; }

        public int ClothingProductId { get; set; }

        [ForeignKey("ClothingProductId")]
        public ClothingProduct? ClothingProduct { get; set; }

        public int TotalQuantity { get; set; } 
    }
}
