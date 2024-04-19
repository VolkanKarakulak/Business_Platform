using Business_Platform.Model.Food;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Office
{
    public class BranchProductComment
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Comment { get; set; }
        public DateTime CommmentDate { get; set; }
        public int OfficeProdBranchProductId { get; set; }

        [ForeignKey("OfficeProdBranchProductId")]
        public OfficeProdBranchProduct? OfficeProdBranchProduct { get; set; }
    }
}
