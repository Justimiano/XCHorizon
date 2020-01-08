using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace XCHorizon.Feature.Navigation.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult MainMenu()
        {
            return View("~/Views/Navigation/MainMenu.cshtml", RenderingContext.Current.ContextItem);
        }
    }
}