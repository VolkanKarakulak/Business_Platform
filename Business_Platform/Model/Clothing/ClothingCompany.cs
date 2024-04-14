namespace Business_Platform.Model.Clothing
{
    public class ClothingCompany : BaseCompanyModel
    {

        public List<ClothingProduct>? Products { get; set; }

        public List<Offer>? Offers { get; set; }
    }
}
