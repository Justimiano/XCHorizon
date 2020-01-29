using Sitecore.Data.Fields;
using Sitecore.Mvc.Pipelines.Response.GetRenderer;
using System;
using System.Linq;
using System.Web;

namespace XCHorizon.Foundation.SitecoreExtensions.Pipelines.Mvc.GetRenderer
{
    public class WildCardDataSource : GetRendererProcessor
    {
        public string RenderingName { get; set; }
        public override void Process(GetRendererArgs args)
        {
            if (args.PageContext.Item.Name != "*" || !args.Rendering.RenderingItem.Name.Equals(RenderingName))
            {
                return;
            }


            var itemName = ResolveItemNameFromUrl(args.PageContext?.RequestContext?.HttpContext);
            var dataSourceItem = WildCard.WildCardProvider.GetDatasourceItem(args.PageContext.Item, itemName);
            if (dataSourceItem != null)
            {
                args.Rendering.DataSource = dataSourceItem.Paths.FullPath;
            }
        }

        private string ResolveItemNameFromUrl(HttpContextBase context)
        {
            string name = context.Request.Url.AbsolutePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
            return HttpUtility.UrlDecode(name);
        }
    }
}