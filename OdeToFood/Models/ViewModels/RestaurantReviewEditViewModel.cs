using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Models.ViewModels
{
    public class RestaurantReviewEditViewModel
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }

        public int Rating { get; set; }

        [Required]
        [StringLength(1024)]
        public string Body { get; set; }
    }
}
