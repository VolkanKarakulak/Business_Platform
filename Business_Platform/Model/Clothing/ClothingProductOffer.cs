using System.ComponentModel.DataAnnotations.Schema;
using Business_Platform.Model.Identity;

namespace Business_Platform.Model.Clothing
{
    public class ClothingProductOffer
    {
        public enum OfferStatus
        {
            Pending, // Beklemede
            Accepted, // Kabul Edildi
            Rejected // Reddedildi      
        }

        public int Id { get; set; }
        public double OfferPrice { get; set; }
        public DateTime OfferDate { get; set; }
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        public int ClothingProductId {  get; set; }

        public int ClothingCompanyId { get; set; }

        [ForeignKey("ClothingCompanyId")]
        public ClothingCompany? ClothingCompany { get; set; }

        [ForeignKey("ClothingProductId")]
        public ClothingProduct? ClothingProduct { get; set; }

        public OfferStatus Status { get; set; } // Teklifin durumu
    }
}
