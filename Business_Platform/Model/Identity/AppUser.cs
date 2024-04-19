using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Business_Platform.Model.Office;
using Business_Platform.Model.Food;

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

        public int? FoodCompanyId { get; set; }

        [ForeignKey("FoodCompanyId")]
        public FoodCompany? FoodCompany { get; set; }

        public int? RestaurantBranchId { get; set; }

        [ForeignKey("RestaurantBranchId")]
        public RestaurantBranch? RestaurantBranch { get; set; }

        public List<Like>? Likes {  get; set; }
    }
}

