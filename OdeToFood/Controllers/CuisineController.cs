using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Filters;
using System.Text.Encodings.Web;

namespace OdeToFood.Controllers
{
    [Log]
    public class CuisineController : Controller
    {
        //[Authorize]
        public IActionResult Search( string name="UnKnown")
        {
            var message = HtmlEncoder.Default.Encode(name);
            //return Content(name);
            //return new EmptyResult();
            //return File("/css/site.css", "text/css");
            //return Json(HtmlEncoder.Default);

            //return Redirect("https://www.tthk.ee");
            //return RedirectPermanent("https://www.tthk.ee");
            return RedirectToRoute("default", new { controller= "Home",action = "About"});

        
        }
        public IActionResult Second(int count)
        {
            return Content($"Teine on siin! {count}");
            }
    }
}
