namespace Business_Platform.DTOs.FoodCategoryDtos
{
    public class FoodCategoryGet
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public string? State { get; set; }
        public string? RestaurantBranchName { get; set; }

    }
}
