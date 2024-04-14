using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model
{
    public class ProductComment
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ClothingProduct? ClothingProduct { get; set; }
    }
}
