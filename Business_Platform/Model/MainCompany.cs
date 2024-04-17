using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Business_Platform.Model.Identity;
using Business_Platform.Model.BaseModel;

namespace Business_Platform.Model
{
    public class MainCompany : BaseCompanyModel
    {

        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }
        public virtual List<AppUser>? AppUsers { get; set; }

    }
}
