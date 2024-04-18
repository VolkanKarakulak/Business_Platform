using Business_Platform.Model.BaseModel;
using Business_Platform.Model.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Food
{
    public class RestaurantBranch : BaseBranchModel
    {

        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }
        public long AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; }
       
        public int FoodCompanyId { get; set; }

        [ForeignKey("FoodCompanyId")]
        public FoodCompany? FoodCompany { get; set; }
        public List<RestaurantFood>? RestaurantFoods { get; set; }
        public List<FoodCategory>? FoodCategories { get; set; }
        public List<RestaurantBranchComment>? RestaurantBranchComments { get; set; }


    }
}
