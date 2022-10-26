using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Models
{
    public class OdeToFoodUser:IdentityUser
    {
        [StringLength(1024)]
        public string FavoriteRestaurant { get; set; }
    }
}
