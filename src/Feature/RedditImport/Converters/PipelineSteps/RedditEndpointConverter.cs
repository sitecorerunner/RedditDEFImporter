using System;
using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters.PipelineSteps;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Plugins;
using Sitecore.DataExchange.Repositories;
using Sitecore.DEF.RedditImport.Models.ItemModels.PipelineSteps;
using Sitecore.Services.Core.Model;

namespace Sitecore.DEF.RedditImport.Converters.PipelineSteps
{
    [SupportedIds("{CE67E73A-40DF-4AB7-A7D3-2FD65E166E2E}")]
    public class RedditEndpointConverter : BasePipelineStepConverter
    {
        public RedditEndpointConverter(IItemModelRepository repository) : base(repository)
        {
        }

        /// <summary>
        /// The add plugins.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="pipelineStep">
        /// The pipeline Step.
        /// </param>
        protected override void AddPlugins(ItemModel source, PipelineStep pipelineStep)
        {
            AddEndpointSettings(source, pipelineStep);
        }
        private void AddEndpointSettings(ItemModel source, PipelineStep pipelineStep)
        {
            var settings = new EndpointSettings
            {
                EndpointFrom = base.ConvertReferenceToModel<Endpoint>(source, RedditReadStepItemModel.EndpointFrom)
            };

            pipelineStep.AddPlugin(settings);
        }

    }
}
