using System;
using RedditImport.Models.ItemModels.PipelineSteps;
using Sitecore.DataExchange.Converters.PipelineSteps;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Plugins;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;

namespace Sitecore.DEF.RedditImport.Converters.PipelineSteps
{
    public class RedditEndpointConverter : BasePipelineStepConverter
    {
        private static readonly Guid TemplateId = Guid.Parse("{CE67E73A-40DF-4AB7-A7D3-2FD65E166E2E}");
        public RedditEndpointConverter(IItemModelRepository repository) : base(repository)
        {
            this.SupportedTemplateIds.Add(TemplateId);
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
            var settings = new EndpointSettings();
            settings.EndpointFrom = base.ConvertReferenceToModel<Endpoint>(source, RedditReadStepItemModel.EndpointFrom);
            pipelineStep.Plugins.Add(settings);
        }
    }
}
