using Sitecore;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using XCHorizon.Foundation.SitecoreExtensions.WildCard;
using Sitecore.Layouts;

namespace XCHorizon.Foundation.SitecoreExtensions.Pipelines.HttpRequest
{
    public class WildcardItemResolver : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            // WildCard Item: Only handler wildcard item.
            if(!WildCardProvider.IsWildcardItem(Context.Item))
            {
                return;
            }

            string itemName = ResolveItemNameFromUrl(args.HttpContext);
            var datasourceItem = WildCardProvider.GetDatasourceItem(Context.Item, itemName);
            if (datasourceItem == null)
            {
                return;
            }

            Item layoutItem = Context.Item;
            args.HttpContext.Items[Templates.WildCard.Fields.ContextItemKey] = Context.Item;
            Context.Item = datasourceItem;
            Context.Page.FilePath = layoutItem.Visualization.Layout.FilePath;
            RenderingReference[] renderingReferences = layoutItem.Visualization.GetRenderings(Context.Device, true);
            foreach (var rendering in renderingReferences)
            {
                Context.Page.AddRendering(rendering);
            }
        }
 
        private string ResolveItemNameFromUrl(HttpContextBase context)
        {
            string name = context.Request.Url.AbsolutePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
            return HttpUtility.UrlDecode(name);
        }
    }
}