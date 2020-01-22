using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Sitecore.Abstractions;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Pipelines.Response.GetPageItem;
using Sitecore.Data.Items;
using Sitecore.Mvc.Configuration;
using XCHorizon.Foundation.SitecoreExtensions.WildCard;
using Sitecore.Data.Fields;
using Sitecore;

namespace XCHorizon.Foundation.SitecoreExtensions.Pipelines.Mvc.GetPageItem
{
    public class GetFromRouteUrl : Sitecore.Mvc.Pipelines.Response.GetPageItem.GetFromRouteUrl
    {
        public GetFromRouteUrl(BaseClient baseClient) : base(baseClient)
        {
        }

        public override void Process(GetPageItemArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (args.Result != null)
            {
                return;
            }
            args.Result = this.ResolveItem(args);
        }

        protected new virtual Item ResolveItem(GetPageItemArgs args)
        {
            string path = this.GetPath(args.RouteData);
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            Item wildcardItem = this.GetItem(path, args);
            if (wildcardItem == null)
            {
                return null;
            }

            if (!WildCardProvider.IsWildcardItem(wildcardItem))
            {
                return wildcardItem;
            }

            ReferenceField datasourceReference = wildcardItem.Fields[Templates.WildCard.Fields.WildCardDatasourceField];
            if (datasourceReference == null || datasourceReference.TargetItem == null)
            {
                return wildcardItem;
            }

            if (HttpContext.Current.Items.Contains(Templates.WildCard.Fields.ContextItemKey))
            {
                HttpContext.Current.Items[Templates.WildCard.Fields.ContextItemKey] = wildcardItem;
            }
            else
            {
                HttpContext.Current.Items.Add(Templates.WildCard.Fields.ContextItemKey, wildcardItem);
            }

            string itemRelativePath = StringUtil.EnsurePrefix('/', WildCardProvider.GetWildCardItemRelativeSitecorePathFromUrl(path, wildcardItem));
            string itemPath = string.Concat(datasourceReference.TargetItem.Paths.FullPath, itemRelativePath);

            string[] pathSegments = itemPath.Split('/');
            return WildCardProvider.GetDatasourceItem(string.Join("/", pathSegments.Take(pathSegments.Length - 1)), pathSegments.LastOrDefault());
        }
           

        protected new virtual string GetPath( RouteData routeData)
        {
            Route route = routeData.Route as Route;
            if(route == null)
            {
                return null;
            }

            string url = route.Url;
            if(string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            char[] charArray = new char[] { '/' };
            string[] strArrays = url.Split(charArray, StringSplitOptions.RemoveEmptyEntries);
            url = GetPathFromParts(strArrays, routeData);

            if(url.StartsWith(Sitecore.Context.Site.SiteInfo.VirtualFolder) && url.Length != Sitecore.Context.Site.SiteInfo.VirtualFolder.Length)
            {
                int removeLength = Sitecore.Context.Site.VirtualFolder.Length - 1;
                if(removeLength <= url.Length)
                {
                    url = url.Remove(0, Sitecore.Context.Site.SiteInfo.VirtualFolder.Length - 1);
                }
            }
            return url;
        }

        protected new virtual string GetPathFromParts(string[] parts, RouteData routeData)
        {
            string ignoreKeyPrefix = MvcSettings.IgnoreKeyPrefix;
            string empty = string.Empty;
            string[] strArrays = parts;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str = strArrays[i];
                GetFromRouteUrl getFromRouteUrl = this;
                string str1 = str;
                RouteData routeDt = routeData;
                string str2 = getFromRouteUrl.ReplaceToken(str1, routeDt, (string key) => !routeData.Values.ContainsKey(string.Concat(ignoreKeyPrefix, key)));
                if (!string.IsNullOrEmpty(str2))
                {
                    empty = string.Concat(empty, "/", str2);
                }
            }

            return empty;
        }
    }
}