using Business_Platform.Model.BaseModel;
using Business_Platform.Model.Office;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Office
{
    public class OfficeCompany : BaseCompanyModel
    {
        public int CompanyCategoryId { get; set; }

        [ForeignKey("CompanyCategoryId")]
        public CompanyCategory? CompanyCategory { get; set; }

        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }

        public List<OfficeProduct>? Products { get; set; }

        public List<OfficeProductOffer>? Offers { get; set; }

        public List<OfficeCompanyBranch>? Branches { get; set; }
    }
}
