using Business_Platform.Model.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Office
{
    public class OfficeProductComment
    {

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Comment { get; set; }
        public DateTime CommmentDate { get; set; }

        public int OfficeProductId { get; set; }

        [ForeignKey("OfficeProductId")]
        public OfficeProduct? OfficeProduct { get; set; }
    }
}
