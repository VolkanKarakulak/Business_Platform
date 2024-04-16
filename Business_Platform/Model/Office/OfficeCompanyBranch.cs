using System.ComponentModel.DataAnnotations.Schema;
using Business_Platform.Model.BaseModel;
using Business_Platform.Model.Identity;

namespace Business_Platform.Model.Office
{
    public class OfficeCompanyBranch : BaseBranchModel
    {
       
        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }
        public int OfficeCompanyId { get; set; }

        [ForeignKey("OfficeCompanyId")]
        public OfficeCompany? OfficeCompany { get; set; }

        public List<OfficeProdBranchProduct>? OfficeProdBranchProducts { get; set; }
    }
}
