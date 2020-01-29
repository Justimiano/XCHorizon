using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Layouts;
using Sitecore.Pipelines.RenderLayout;

namespace XCHorizon.Foundation.SitecoreExtensions.Pipelines.Presentation
{
    public class InsertRenderings : RenderLayoutProcessor
    {
        public override void Process(RenderLayoutArgs args)
        {
            if (Context.Item != null)
            {
                if (Context.Item.Visualization.Layout == null)
                {
                    Item layoutItem = Context.Database.GetItem(new Sitecore.Data.ID("{ED11F56A-CE2E-439D-8D1A-B7CFF8EB120E}"));
                    if (layoutItem != null)
                    {
                        RenderingReference [] renderingReferences =   layoutItem.Visualization.GetRenderings(Context.Device, true);
                        foreach (var rendering in renderingReferences)
                        {
                            Context.Page.AddRendering(rendering);
                        }
                    }
                }
            }
        }
    }
}