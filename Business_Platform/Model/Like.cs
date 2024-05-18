using Business_Platform.Model.Food;
using Business_Platform.Model.Identity;
using Business_Platform.Model.Office;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model
{
    public class Like
    {
        public int Id { get; set; }

        public long AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; }

        public int? OfficeProductId { get; set; }

        [ForeignKey("ProductId")]
        public OfficeProduct? Product { get; set; }

        public int? OfficeProdBranchProductId { get; set; }

        [ForeignKey("OfficeProdBranchProductId")]
        public OfficeProdBranchProduct? OfficeProdBranchProduct { get; set; }
        public int? OfficeCompanyId { get; set; }

        [ForeignKey("OfficeCompanyId")]
        public OfficeCompany? OfficeCompany { get; set; }
        public int? FoodCompanyId { get; set; }

        [ForeignKey("FoodCompanyId")]
        public FoodCompany? FoodCompany { get; set; }

        //public int? RestaurantFoodId { get; set; }

        //[ForeignKey("RestaurantFoodId")]
        //public RestaurantFood? RestaurantFood { get; set; }

        public int RestaurantBranchFoodId {  get; set; }

        public RestaurantBranchFood? RestaurantBranchFood { get; set; }
    }
}
