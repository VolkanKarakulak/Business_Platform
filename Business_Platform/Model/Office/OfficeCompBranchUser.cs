using System.ComponentModel.DataAnnotations.Schema;
using Business_Platform.Model.Identity;

namespace Business_Platform.Model.Office
{
    public class OfficeCompBranchUser
    {
        public int OfficeCompanyBranchId { get; set; }

        [ForeignKey("OfficeCompBranchId")]
        public OfficeCompanyBranch? OfficeCompanyBranch { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }

    }
}
