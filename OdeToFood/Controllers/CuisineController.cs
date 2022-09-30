using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace OdeToFood.Controllers
{
    public class CuisineController : Controller
    {
        public IActionResult Search( string name="UnKnown")
        {
            var message = HtmlEncoder.Default.Encode(name);
            //return Content(name);
            //return new EmptyResult();
            return File("/css/site.css", "text/css");
        }
    }
}
