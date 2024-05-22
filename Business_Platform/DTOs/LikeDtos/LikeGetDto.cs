namespace Business_Platform.DTOs.LikeDtos
{
    public class LikeGetDto
    {
        public long? AppUserId { get; set; }
        public string? UserName { get; set; }
        public string? OfficeCompanyName { get; set; }
        public string? OfficeProductName { get; set; }
        public string? FoodCompanyName { get; set; }
        public string? FoodProductName { get; set; }
        public string? CompanyCategoryName { get; set; }
    }
}
