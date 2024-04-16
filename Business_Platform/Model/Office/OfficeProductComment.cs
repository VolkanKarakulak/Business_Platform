using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Office
{
    public class OfficeProductComment
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Comment { get; set; }
        public DateTime CommmentDate { get; set; }

        public int OfficeProductId { get; set; }

        [ForeignKey("OfficeProductId")]
        public OfficeProduct? OfficeProduct { get; set; }
    }
}
