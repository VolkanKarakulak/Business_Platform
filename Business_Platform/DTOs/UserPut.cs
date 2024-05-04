namespace Business_Platform.DTOs
{
    public class UserPut
    {
        public DateTime RegisterDate { get; set; }
        public byte StateId { get; set; }
        public int? OfficeCompanyBranchId { get; set; }
        public int? OfficeCompanyId { get; set; }
        public int? FoodCompanyId { get; set; }
        public int? RestaurantBranchId { get; set; }
        public int? MainCompanyId { get; set; } 

    }
}
