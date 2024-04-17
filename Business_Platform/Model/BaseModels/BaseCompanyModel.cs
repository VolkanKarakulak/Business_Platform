using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.BaseModel
{
    public class BaseCompanyModel
    {
        public int Id { get; set; }

        [StringLength(150, MinimumLength = 3)]
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; } = "";

        [StringLength(150, MinimumLength = 3)]
        [Column(TypeName = "nvarchar(150)")]
        public string Address { get; set; } = "";

        [Phone]
        [StringLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string PhoneNumber { get; set; } = "";

        [EmailAddress]
        [Column(TypeName = "varchar(100)")]
        public string EMail { get; set; } = "";

        [StringLength(5, MinimumLength = 1)]
        [Column(TypeName = "char(5)")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; } = "";

        [Column(TypeName = "smalldatetime")]
        public DateTime RegisterDate { get; set; }

     
    }
}

