using System.ComponentModel.DataAnnotations.Schema;
using Business_Platform.Model.BaseModel;
using Business_Platform.Model.Identity;

namespace Business_Platform.Model.Clothing
{
    public class ClothingCompanyBranch : BaseBranchModel
    {
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }
        public int ClothingCompanyId { get; set; }

        [ForeignKey("ClothingCompanyId")]
        public ClothingCompany? ClothingCompany { get; set; }

        public List<ClothingCompBranchProduct>? ClothingCompBranchProducts { get; set; }
    }
}
