namespace Business_Platform.DTOs.OfficeProductTypeDtos
{
    public class OfficeProductTypePut
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = "";
        public string? Description { get; set; }
    }
}
