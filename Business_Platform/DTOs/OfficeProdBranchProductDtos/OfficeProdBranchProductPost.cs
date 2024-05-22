namespace Business_Platform.DTOs.OfficeProdBranchProductDtos
{
    public class OfficeProdBranchProductPost
    {
        public string Name { get; set; } = "";
        public int? Quantity { get; set; }
        public int Price { get; set;}
        public string? Color { get; set; }
        public string? Material { get; set; }
        public byte StateId { get; set; }
        public int? OfficeProductTypeId { get; set; }
        public int OfficeCompanyId { get; set; }
        public int? OfficeProductId { get; set; }
        public int OfficeCompanyBranchId { get; set; }
        public int CompanyCategoryId { get; set; }

    }
}
