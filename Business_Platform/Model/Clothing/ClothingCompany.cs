namespace Business_Platform.Model.Clothing
{
    public class ClothingCompany : BaseCompanyModel
    {

        public List<ClothingProduct>? Products { get; set; }

        public List<ClothingOffer>? Offers { get; set; }
    }
}
