namespace Business_Platform.DTOs.LikeDtos
{
    public class LikePostDto
    {
        public int CompanyCategoryId { get; set; }
        public int? ProductId { get; set; }
        public int? OfficeProdBranchProductId { get; set; }
        public int? FoodCompanyId { get; set; }
        public int? RestaurantBranchFoodId { get; set; }

        //public string? ProductType { get; set; }
    }
}
