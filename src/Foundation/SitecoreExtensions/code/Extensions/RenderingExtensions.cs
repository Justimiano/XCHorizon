using Sitecore;
using Sitecore.Mvc.Presentation;

namespace XCHorizon.Foundation.SitecoreExtensions.Extensions
{
    public static class RenderingExtensions
    {
        public static bool GetUseStaticPlaceholderNames(this Rendering rendering)
        {
            return MainUtil.GetBool(rendering.Parameters[Constants.DynamicPlaceholdersLayoutParameters.UseStaticPlaceholderNames], false);
        }
    }
}