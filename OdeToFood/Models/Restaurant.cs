using System.Collections.Generic;

namespace OdeToFood.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Country { get; set; }

        public ICollection<RestaurantReview> Reviews { get; set; }
    }
}
