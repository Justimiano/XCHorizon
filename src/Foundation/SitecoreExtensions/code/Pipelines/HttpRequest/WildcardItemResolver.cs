using Sitecore;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Linq;
using System.Web;
using XCHorizon.Foundation.SitecoreExtensions.WildCard;

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

            args.HttpContext.Items[Templates.WildCard.Fields.ContextItemKey] = Context.Item;
            Context.Item = datasourceItem;
        }

        private string ResolveItemNameFromUrl(HttpContextBase context)
        {
            string name = context.Request.Url.AbsolutePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
            return HttpUtility.UrlDecode(name);
        }
    }
}