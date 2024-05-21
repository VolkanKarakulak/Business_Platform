namespace Business_Platform.DTOs.OfficeProdBranchProductDtos
{
    public class OfficeProdBranchProductGet
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int? Quantity { get; set; }
        public int? OfficeProductId { get; set; }
        public int OfficeCompanyBranchId { get; set; }
        public string OfficeCompanyBranchName { get; set; } = "";

    }
}
