
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Helpers;
using System.Web;

namespace XCHorizon.Foundation.SitecoreExtensions.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString ImageField(this SitecoreHelper helper, ID fieldID, int mh = 0, int mw = 0, string cssClass = null, bool disableWebEditing = false)
        {
            return helper.Field(fieldID.ToString(), new
            {
                mh,
                mw,
                DisableWebEdit = disableWebEditing,
                @class = cssClass ?? ""
            });
        }

        public static HtmlString ImageField(this SitecoreHelper helper, ID fieldID, Item item, int mh = 0, int mw = 0, string cssClass = null, bool disableWebEditing = false)
        {
            return helper.Field(fieldID.ToString(), item, new
            {
                mh,
                mw,
                DisableWebEdit = disableWebEditing,
                @class = cssClass ?? ""
            });
        }

        public static HtmlString ImageField(this SitecoreHelper helper, string fieldName, Item item, int mh = 0, int mw = 0, string cssClass = null, bool disableWebEditing = false)
        {
            return helper.Field(fieldName, item, new
            {
                mh,
                mw,
                DisableWebEdit = disableWebEditing,
                @class = cssClass ?? ""
            });
        }

        public static HtmlString DynamicPlaceholder(this SitecoreHelper helper, string placeholderName, bool useStaticPlaceholderNames = false)
        {
            return useStaticPlaceholderNames ? helper.Placeholder(placeholderName) : helper.DynamicPlaceholder(placeholderName);
        }
    }
}