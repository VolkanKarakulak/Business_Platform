namespace Business_Platform.DTOs.RestaurantBranchDtos
{
    public class RestaurantBranchPost
    {   
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime RegisterDate { get; set; }
        public string PostalCode { get; set; } = "";
        public string PhoneNumber { get;  set; } = "";
        public string EMail { get; set; } = "";
        public string? City { get; set; }
        public string? BranchCode { get; set; }
        public byte StateId { get; set; }
        public int FoodCompanyId { get; set; }

    }
}
