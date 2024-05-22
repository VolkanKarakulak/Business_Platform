using Business_Platform.Model.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Office
{
    public class OfficeProductComment
    {
        public int Id { get; set; }
        public long AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; }

        [StringLength(200, MinimumLength = 5)]
        [Column(TypeName = "nvarchar(200)")]
        public string Comment { get; set; } = "";
        public DateTime CommmentDate { get; set; }
        public int OfficeProdBranchProductId { get; set; }

        [ForeignKey("OfficeProdBranchProductId")]
        public OfficeProdBranchProduct? OfficeProdBranchProduct { get; set; }
    }
}
