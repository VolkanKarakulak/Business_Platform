using System.ComponentModel.DataAnnotations.Schema;
using Business_Platform.Model.BaseModel;

namespace Business_Platform.Model.Clothing
{
    public class ClothingCompanyBranch : BaseBranchModel
    {
        public int ClothingCompanyId { get; set; }

        [ForeignKey("ClothingCompanyId")]
        public ClothingCompany? ClothingCompany { get; set; }
    }
}
