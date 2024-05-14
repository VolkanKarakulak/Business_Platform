namespace Business_Platform.DTOs.OfficeCompanyBranchDtos
{
    public class OfficeCompanyBranchGet
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public DateTime RegisterDate { get; set; }
        public string PostalCode { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string EMail { get; set; } = "";
        public string? BranchCode { get; set; }
        public string? State { get; set; }
        public int? CompanyCategoryId { get; set; }
        public string? CompanyCategoryName { get; set; }
        public int? OfficeCompanyId { get; set; }
        public string? OfficeCompanyName { get; set; }

    }
}
