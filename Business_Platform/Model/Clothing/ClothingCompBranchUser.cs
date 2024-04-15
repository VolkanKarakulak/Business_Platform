using System.ComponentModel.DataAnnotations.Schema;
using Business_Platform.Model.Identity;

namespace Business_Platform.Model.Clothing
{
    public class ClothingCompBranchUser
    {
        public int ClothingCompanyBranchId { get; set; }

        [ForeignKey("ClothingCompBranchId")]
        public ClothingCompanyBranch? ClothingCompanyBranch { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }

    }
}
