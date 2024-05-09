using Business_Platform.Model.BaseModel;
using Business_Platform.Model.Identity;
using Business_Platform.Model.Office;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Food
{
    public class FoodCompany : BaseCompanyModel
    {
        public int? CompanyCategoryId { get; set; }

        [ForeignKey("CompanyCategoryId")]
        public CompanyCategory? CompanyCategory { get; set; }

        public byte? StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }

        public List<RestaurantBranch>? RestaurantBranches { get; set; }
        public List<RestaurantFood>? RestaurantFoods { get; set; }
        public List<AppUser>? AppUsers { get; set; }
    }
}
