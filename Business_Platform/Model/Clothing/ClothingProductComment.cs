using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Clothing
{
    public class ClothingProductComment
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Comment { get; set; }
        public DateTime CommmentDate { get; set; }

        public int ClothingProductId { get; set; }

        [ForeignKey("ClothingProductId")]
        public ClothingProduct? ClothingProduct { get; set; }
    }
}
