namespace Business_Platform.DTOs.FoodCompanyDtos
{
    public class FoodCompanyPost
    {
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string EMail { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public DateTime RegisterDate { get; set; }
        public int? CompanyCategoryId { get; set; }
        public byte? StateId { get; set; }

    }
}
