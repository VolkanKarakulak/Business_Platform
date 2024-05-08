namespace Business_Platform.DTOs.UserDtos
{
    public class UserPost
    {
        public string Name { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PassWord { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public DateTime RegisterDate { get; set; }
        public byte StateId { get; set; }
        public int? OfficeCompanyId { get; set; }
        public int? OfficeCompanyBranchId { get; set; }
        public int? MainCompanyId { get; set; }
        public int? FoodCompanyId { get; set; }
        public int? RestaurantBranchId { get; set; }

    }
}
