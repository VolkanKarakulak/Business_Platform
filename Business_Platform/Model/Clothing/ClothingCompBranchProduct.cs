using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Clothing
{
    public class ClothingCompBranchProduct
    {
        public int Id { get; set; }

        public int ClothingProductId { get; set; }
        [ForeignKey("ClothingProductId")]
        public ClothingProduct? ClothingProduct { get; set; }

        public int ClothingCompanyBranchId { get; set; }
        [ForeignKey("ClothingCompanyBranchId")]
        public ClothingCompanyBranch? ClothingCompanyBranch { get; set; }
    }
}
