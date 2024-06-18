using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Business_Platform.Model.BaseModel
{
    public abstract class BaseProductModel
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

    }
}
