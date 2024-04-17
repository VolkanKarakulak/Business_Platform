using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Business_Platform.Model.Office;

namespace Business_Platform.Model.Identity
{
    public class AppUser : IdentityUser<long>
    {
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = "";

        [NotMapped]
        [StringLength(100, MinimumLength = 8)]
        public string PassWord { get; set; } = "";

        public DateTime RegisterDate { get; set; }

        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }

        public int? OfficeCompanyId { get; set; }

        [ForeignKey("OfficeCompanyId")]
        public OfficeCompany? OfficeCompany { get; set; }

        public int? OfficeCompanyBranchId { get; set; }

        [ForeignKey("OfficeCompanyId")]
        public OfficeCompanyBranch? OfficeCompanyBranch { get; set; }
        public int? MainCompanyId { get; set; }

        [ForeignKey("MainCompanyId")]
        public MainCompany? MainCompany { get; set; }


    }
}

