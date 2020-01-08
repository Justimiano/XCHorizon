using Sitecore.Mvc.Helpers;
using System.Web;

namespace XCHorizon.Foundation.SitecoreExtensions.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString DynamicPlaceholder(this SitecoreHelper helper, string placeholderName, bool useStaticPlaceholderNames = false)
        {
            return useStaticPlaceholderNames ? helper.Placeholder(placeholderName) : helper.DynamicPlaceholder(placeholderName);
        }
    }
}