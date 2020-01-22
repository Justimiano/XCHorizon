using Sitecore;
using Sitecore.Buckets.Extensions;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using XCHorizon.Foundation.SitecoreExtensions.Indexing;

namespace XCHorizon.Foundation.SitecoreExtensions.WildCard
{
    public class WildCardProvider
    {
        public static bool IsWildcardItem(Item item)
        {
            return item?.Name == "*" && item?.TemplateID == Templates.WildCard.ID;
        }

        public static Item GetDatasourceItem(Item wildCardItem, string itemName)
        {
            ReferenceField datasourceReference = wildCardItem.Fields[Templates.WildCard.Fields.WildCardDatasourceField];
            return GetDatasourceItem(datasourceReference?.TargetItem?.Paths.FullPath, itemName);
        }

        public static Item GetDatasourceItem(string pathData, string itemName)
        {
            if(string.IsNullOrWhiteSpace(pathData))
            {
                return null;
            }

            Item itemData = Sitecore.Context.Database.GetItem(pathData);
            bool isBucket = itemData == null ? false : itemData.IsABucket();

            var searchName = isBucket ? StringUtil.EnsurePrefix('/', itemName) : itemName;
            searchName = searchName.ToLowerInvariant();
            pathData = pathData.ToLowerInvariant();

            var indexName = GetIndexName(Context.Item);
            var searchContext = ContentSearchManager.GetIndex(indexName).CreateSearchContext();

            var results = searchContext.GetQueryable<SearchResultItem>().Where(x =>
                         x.Path.StartsWith(StringUtil.EnsurePostfix('/', pathData), StringComparison.OrdinalIgnoreCase) &&
                         x.Path.EndsWith(searchName, StringComparison.OrdinalIgnoreCase) &&
                         x.Language == Context.Item.Language.Name);

           
            if (isBucket)
            {
                // Dot not return non-bucketable items, like underlying contentblocks.
                results = results.Where(c => c["__bucketable"] == "1");
            }

            return results.FirstOrDefault()?.GetItem();
        }

        private static string GetIndexName(Item item)
        {
            return ContentSearchManager.GetContextIndexName(new SitecoreIndexableItem(item));
        }

        public static string GetWildCardItemRelativeSitecorePathFromUrl(string path, Item wildcardItem)
        {
            List<string> itemPathParts = new List<string>();
            List<string> urlParts = path.Replace(".aspx", string.Empty)
                                        .Split(new char[] { '/' }, 100, StringSplitOptions.RemoveEmptyEntries)
                                        .Reverse()
                                        .ToList();

            Item wildcardAncestor = wildcardItem;

            while (IsWildcardItem(wildcardAncestor) && !string.IsNullOrEmpty(urlParts.LastOrDefault()))
            {
                itemPathParts.Insert(0, urlParts.FirstOrDefault());
                urlParts.RemoveAt(0);
                wildcardAncestor = wildcardAncestor.Parent;
            }


            string itemRelativePath = string.Join("/", itemPathParts);
            return itemRelativePath;
        }

    }
}