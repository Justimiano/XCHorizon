using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XCHorizon.Foundation.SitecoreExtensions
{
    public class Templates
    {
        public struct WildCard
        {
            public static readonly ID ID = new ID("{BF6C9421-941A-48CE-AE08-0567214A7201}");
            public struct Fields
            {
                public static readonly ID WildCardDatasourceField = new ID("{9DD7B92E-2636-4952-81AA-7F55C155E6B0}");
                public static readonly string ContextItemKey = "wildcard_item";
            }
        }
    }
}