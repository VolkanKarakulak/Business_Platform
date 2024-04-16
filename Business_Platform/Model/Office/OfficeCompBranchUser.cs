using System.ComponentModel.DataAnnotations.Schema;
using Business_Platform.Model.Identity;

namespace Business_Platform.Model.Office
{
    public class OfficeCompBranchUser
    {
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        public int OfficeCompanyBranchId { get; set; }

        [ForeignKey("OfficeCompanyBranchId")]
        public OfficeCompanyBranch? OfficeCompanyBranch { get; set; }


    }
}
