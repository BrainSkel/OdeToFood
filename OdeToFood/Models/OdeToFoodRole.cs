using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Models
{
    public class OdeToFoodRole : IdentityRole
    {

        [StringLength(128, MinimumLength = 1)]
        public string DisplayName { get; set; }
    }
}
