using System;
using Sitecore.DataExchange.Converters.Endpoints;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Repositories;
using Sitecore.DEF.RedditImport.Plugins;
using Sitecore.Services.Core.Model;

namespace Sitecore.DEF.RedditImport.Converters.Endpoints
{
    public class RedditEndPoint: BaseEndpointConverter
    {
        private static readonly Guid TemplateId = Guid.Parse("{844E82BD-816F-4ABA-97F4-F15CC3204590}");
        public RedditEndPoint(IItemModelRepository repository) : base(repository)
        {
            this.SupportedTemplateIds.Add(TemplateId);
        }

        protected override void AddPlugins(ItemModel source, Endpoint endpoint)
        {
            var settings = new RedditSettings();
            settings.BlogPath = base.GetStringValue(source, "Blog Path");

            endpoint.Plugins.Add(settings);
        }
    }
}