using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Links.UrlBuilders;

namespace XCHorizon.Foundation.SitecoreExtensions.Providers
{
    [System.Obsolete]
    public class LinkProvider : Sitecore.Links.LinkProvider
    {
        public override string GetItemUrl(Item item, ItemUrlBuilderOptions options)
        {
            Assert.ArgumentNotNull(item, "item");
            Assert.ArgumentNotNull(options, "options");

            // Store real item for later use
            Item realItem = item;

            // Check if item is an wildcard item
            bool isWildcardItem = WildCard.WildCardProvider.IsWildcardItem(item);
            if (isWildcardItem)
            {
                //item = Context.Database.GetItem(WildcardProvider.GetSetting(item.TemplateID).ItemID);
            }

            if (item == null)
            {
                item = realItem;
            }

            string text = base.GetItemUrl(item, options);
            if (isWildcardItem)
            {
                text = WildCard.WildCardProvider.GetWildcardItemUrl(item, realItem, UseDisplayName);
            }

            return text.ToLower();
        }
    }
}