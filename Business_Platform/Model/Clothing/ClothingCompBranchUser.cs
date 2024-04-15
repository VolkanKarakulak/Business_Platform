using System.ComponentModel.DataAnnotations.Schema;

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
