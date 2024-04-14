namespace Business_Platform.Model
{
    public class ClothingType
    {
        public int Id { get; set; }

        public string TypeName { get; set; } = "";

        public string Description { get; set; } = "";

        public List<ClothingProduct>? ClothingProducts { get; set; }
    }
}
