namespace Business_Platform.DTOs.OfficeCompanyBranchDtos
{
    public class OfficeCompanyBranchPut
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string City { get; set; } = "";
        public string EMail { get; set; } = "";
        public string BranchCode { get; set; } = "";
        public byte StateId { get; set; }
        public int CompanyCategoryId { get; set; }
        public int OfficeCompanyId { get; set; }

    }
}
