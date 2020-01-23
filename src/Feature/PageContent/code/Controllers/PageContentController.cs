using Sitecore.Mvc.Controllers;
using System.Web.Mvc;

namespace XCHorizon.Feature.PageContent.Controllers
{
    public class PageContentController : SitecoreController
    {
        // GET: PageContent
        public ActionResult Title()
        {
            return View("~/Views/PageContent/Title.cshtml");
        }

        public ActionResult EventHeader ()
        {
            return View("~/Views/PageContent/EventHeader.cshtml");
        }
    }
}