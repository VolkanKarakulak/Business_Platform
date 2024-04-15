using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model
{
    public class BaseBranchModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string? City { get; set; }
        public int BranchCode { get; set; }
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }

    }
}
