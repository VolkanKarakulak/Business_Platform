using Business_Platform.Model.Food;
using Business_Platform.Model.Identity;
using Business_Platform.Model.Office;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Platform.Model
{
    public class Like
    {
        public int Id { get; set; }

        public long AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; }

        public int OfficeProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual OfficeProduct? Product { get; set; }

        public int RestaurantFoodId { get; set; }

        [ForeignKey("RestaurantFoodId")]
        public RestaurantFood? RestaurantFood { get; set; }
    }
}
