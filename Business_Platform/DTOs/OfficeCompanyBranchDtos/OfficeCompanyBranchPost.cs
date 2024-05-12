namespace Business_Platform.DTOs.OfficeCompanyBranchDtos
{
    public class OfficeCompanyBranchPost
    {
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string EMail { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public int? OfficeCompanyId { get; set; }
        public byte StateId { get; set; }
    }
}
