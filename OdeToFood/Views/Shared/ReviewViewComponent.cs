using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace OdeToFood.Views.Shared
{
    public class BestReviewCompoment :ViewComponent
    {
        public BestReviewCompoment()
        {

        }
        public IViewComponentResult Invoke(List<RestaurantReview> reviews)
        {
            var bestReview = from r in reviews
                             orderby r.Rating descending
                             select r;
            return View(bestReview.First());
        }

    }
}
