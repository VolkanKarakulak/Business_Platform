namespace Business_Platform.ViewModel
{
    public class FoodCategoryPostViewModel
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public byte StateId { get; set; }
        public int? RestaurantBranchId { get; set; }
    }
}
