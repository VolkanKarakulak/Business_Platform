using Business_Platform.Model.Office;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Food
{
    public class RestaurantBranchComment
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Comment { get; set; }
        public DateTime CommmentDate { get; set; }

        public int RestaurantBranchId { get; set; }

        [ForeignKey("RestaurantBranchId")]
        public RestaurantBranch? RestaurantBranch { get; set; }
    }
}
