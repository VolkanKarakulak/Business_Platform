using Business_Platform.Model.Food;
using Business_Platform.Model.Identity;

namespace Business_Platform.DTOs.FoodCompanyDtos
{
    public class FoodCompanyGet
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string EMail { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public DateTime RegisterDate { get; set; }
        public string? CompanyCategoryName { get; set; }
        public string? State { get; set; }

        public List<string>? RestaurantBranchNames { get; set; }
        public List<string>? RestaurantFoodNames { get; set; }
        public List<string>? AppUserNames { get; set; }
    }
}
