using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.BaseModel
{
    public class BaseBranchModel
    {
        public int Id { get; set; }

        [StringLength(150, MinimumLength = 3)]
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; } = "";

        [StringLength(150, MinimumLength = 3)]
        [Column(TypeName = "nvarchar(150)")]
        public string Address { get; set; } = "";

        [Phone]
        [StringLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string PhoneNumber { get; set; } = "";

        [EmailAddress]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; } = "";
        public string? City { get; set; }
        public int BranchCode { get; set; } // Ayrı bir model oluşturabilir
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }

    }
}
