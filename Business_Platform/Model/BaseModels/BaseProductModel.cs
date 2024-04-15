using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Business_Platform.Model.BaseModel
{
    public class BaseProductModel
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = "";

        [Range(0, float.MaxValue)]
        public float Price { get; set; }

        [DisplayName("Image")]
        [StringLength(150)]
        public string? ImageFileName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Description { get; set; }
        public long AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; } // Ürün Satıcısı

        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }


    }
}
