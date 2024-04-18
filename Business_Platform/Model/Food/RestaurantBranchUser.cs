using Business_Platform.Model.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Food
{
    public class RestaurantBranchUser
    {
        public int RestaurantBranchId { get; set; }

        [ForeignKey("RestaurantId")]
        public RestaurantBranch? RestaurantBranch { get; set; }

        public long AppUserId { get; set; } 

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; }
    }
}
