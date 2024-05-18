using Business_Platform.Model.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Food
{
    public class RestaurantBranchFood : BaseProductModel
    {
        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }

        public int RestaurantBranchId { get; set; }

        [ForeignKey("RestaurantBranchId")]
        public RestaurantBranch? RestaurantBranch { get; set; }

        public int FoodCategoryId { get; set; }

        [ForeignKey("FoodCategoryId")]
        public FoodCategory? FoodCategory { get; set; }

        public int FoodCompanyId {  get; set; }

        [ForeignKey("FoodCompanyId")]
        public FoodCompany? FoodCompany { get; set; }


    }
}
