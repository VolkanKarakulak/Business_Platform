using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Office
{
    public class OfficeStock
    {
        public int Id { get; set; }

        public int OfficeProductId { get; set; }

        [ForeignKey("OfficeProductId")]
        public OfficeProduct? OfficeProduct { get; set; }

        public int TotalQuantity { get; set; } 
    }
}
