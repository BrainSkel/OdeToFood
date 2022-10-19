using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Models
{
    public class RestaurantReview
    {
        public int Id { get; set; }

        [Range(1, 10)]
        [Required]
        public int Rating { get; set; }

        [Required]
        [StringLength(1024)]

        public string Body { get; set; }
        public int RestaurantId { get; set; }

        [Display(Name ="Reviewer Name")]
        [StringLength(1024)]
        [Required]
        public string ReviewerName { get; set; }

        public ICollection<RestaurantReview> RestaurantReviews { get; set; }

    }
}
