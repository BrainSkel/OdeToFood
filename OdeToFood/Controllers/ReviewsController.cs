using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OdeToFood.Models;
using System.Threading.Tasks;

namespace OdeToFood.Controllers 
{ 



    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> index([Bind(Prefix ="id")]int restaurantId)
        {
            var restaurant = await _context.Restaurants
                .Include(r=>r.Reviews)
                .FirstOrDefaultAsync(m => m.Id == restaurantId);
            if (restaurant == null)
            {
                 return NotFound();
            }
            return View(restaurant);

        }
    }


}
