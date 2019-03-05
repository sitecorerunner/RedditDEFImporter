using System;
using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters.Endpoints;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Repositories;
using Sitecore.DEF.RedditImport.Plugins;
using Sitecore.Services.Core.Model;

namespace Sitecore.DEF.RedditImport.Converters.Endpoints
{
    [SupportedIds("{844E82BD-816F-4ABA-97F4-F15CC3204590}")]
    public class RedditEndPoint: BaseEndpointConverter
    {
        public RedditEndPoint(IItemModelRepository repository) : base(repository)
        {
        }

        protected override void AddPlugins(ItemModel source, Endpoint endpoint)
        {
            var settings = new RedditSettings {BlogPath = base.GetStringValue(source, "Blog Path")};

            endpoint.AddPlugin(settings);
        }
    }
}