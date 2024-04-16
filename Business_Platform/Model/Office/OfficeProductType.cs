namespace Business_Platform.Model.Office
{
    public class OfficeProductType
    {
        public int Id { get; set; }

        public string TypeName { get; set; } = "";

        public string Description { get; set; } = "";

        public List<OfficeProduct>? OfficeProducts { get; set; }
    }
}
