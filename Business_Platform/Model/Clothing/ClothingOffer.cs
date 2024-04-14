using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model.Clothing
{
    public class ClothingOffer
    {
        public double OfferPrice { get; set; }
        public DateTime OfferDate { get; set; }
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        public int ClothingProductId {  get; set; }

        [ForeignKey("ClothingProductId")]
        public ClothingProduct? ClothingProduct { get; set; }


    }
}
