using Business_Platform.Model.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Clothing
{
    public class ClothingCompany : BaseCompanyModel
    {
        public int CompanyCategoryId { get; set; }

        [ForeignKey("CompanyCategoryId")]
        public CompanyCategory? CompanyCategory { get; set; }

        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }

        public List<ClothingProduct>? Products { get; set; }

        public List<ClothingProductOffer>? Offers { get; set; }

        public List<ClothingCompanyBranch>? Branches { get; set; }
    }
}
