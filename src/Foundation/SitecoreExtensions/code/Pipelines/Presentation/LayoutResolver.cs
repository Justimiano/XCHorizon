using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.HttpRequest;

namespace XCHorizon.Foundation.SitecoreExtensions.Pipelines.Presentation
{
    public class LayoutResolver : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (Context.Item != null && Context.Database != null)
            {
                if (Context.Item.Visualization.Layout == null)
                {
                    Item layoutItem = Context.Database.GetItem(new Sitecore.Data.ID("{ED11F56A-CE2E-439D-8D1A-B7CFF8EB120E}"));
                    if (layoutItem != null && layoutItem.Visualization.Layout != null)
                    {
                        Context.Page.FilePath = layoutItem.Visualization.Layout.FilePath;
                    }
                }
            }
        }
    }
}