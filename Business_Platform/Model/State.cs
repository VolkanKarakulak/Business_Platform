using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business_Platform.Model
{
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // veritabanında ıd otomatik olarak artmasın
        public byte Id { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        public string Name { get; set; } = "";
    }
}
