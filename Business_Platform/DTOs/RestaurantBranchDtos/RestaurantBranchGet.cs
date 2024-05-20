namespace Business_Platform.DTOs.RestaurantBranchDtos
{
    public class RestaurantBranchGet
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime RegisterDate { get; set; }
        public string PostalCode { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string EMail { get; set; } = "";
        public string? City { get; set; }
        public string? BranchCode { get; set; }
        public string? State { get; set; }
        public int FoodCompanyId { get; set; }
        public string? FoodCompany { get; set; }

        public List<string>? RestaurantFoodNames { get; set; }
        public List<string>? FoodCategoryNames { get; set; }
        public List<string>? RestaurantBranchComments { get; set; }
        public List<string>? AppUsers { get; set; }
    }
}
