using Sitecore.Data.Fields;
using Sitecore.Mvc.Pipelines.Response.GetRenderer;
using System.Linq;

namespace XCHorizon.Foundation.SitecoreExtensions.Pipelines.Mvc.GetRenderer
{
    public class WildCardDataSource : GetRendererProcessor
    {
        public string RenderingName { get; set; }
        public override void Process(GetRendererArgs args)
        {
            if (args.PageContext.Item.Name != "*" || !args.Rendering.RenderingItem.Name.Equals(RenderingName))
            {
                return;
            }
            ReferenceField datasourceReference = args.PageContext.Item.Fields[Templates.WildCard.Fields.WildCardDatasourceField];
            string dataSourcePath = string.Format("{0}/{1}", datasourceReference?.TargetItem?.Paths.FullPath, args.PageContext.RequestContext.HttpContext.Request.Url.LocalPath.Split('/').Last());

            var dataSourceItem = Sitecore.Context.Database.GetItem(dataSourcePath);
            if (dataSourceItem != null)
            {
                args.Rendering.DataSource = dataSourcePath;
            }
            else
            {
                // process 404 page not found
            }
        }
    }
}