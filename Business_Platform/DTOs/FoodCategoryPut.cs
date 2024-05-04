namespace Business_Platform.DTOs
{
    public class FoodCategoryPut
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; } 
        public byte StateId { get; set; }
        public int? RestaurantBranchId { get; set; }

    }
}
