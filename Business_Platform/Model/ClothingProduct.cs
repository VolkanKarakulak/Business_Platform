using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business_Platform.Model
{
    public class ClothingProduct
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = "";

        [Range(0, float.MaxValue)]
        public float Price { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Description { get; set; }

        public int ClothingTypeId { get; set; }

        [ForeignKey("ClothingTypeId")]
        public ClothingType? ClothingType { get; set; }





    }
}
