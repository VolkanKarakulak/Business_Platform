using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business_Platform.Model
{
    public class AppUser : IdentityUser<long>
    {
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = "";

        [NotMapped]
        [StringLength(100, MinimumLength = 8)]
        public string PassWord { get; set; } = "";

        // State Eklenebilir
    }
}
