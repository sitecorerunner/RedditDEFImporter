using System;
using System.Linq;
using RedditSharp;
using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Contexts;
using Sitecore.DataExchange.Extensions;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Plugins;
using Sitecore.DataExchange.Processors.PipelineSteps;
using Sitecore.DEF.RedditImport.Plugins;
using Sitecore.Services.Core.Diagnostics;

namespace Sitecore.DEF.RedditImport.Processors.PipelineSteps
{
    [RequiredEndpointPlugins(typeof(RedditSettings))]
    public class RedditItemsProcessor : BaseReadDataStepProcessor
    {
        public RedditItemsProcessor()
        {
            
        }
        protected override void ProcessPipelineStep(PipelineStep pipelineStep, PipelineContext pipelineContext, ILogger logger)
        {
            EndpointSettings endpointSettings = pipelineStep.GetEndpointSettings();
            if (endpointSettings == null)
            {
                logger.Error("Pipeline step processing will abort because the pipeline step is missing a plugin. (pipeline step: {0}, plugin: {1})", pipelineStep.Name,
                    typeof(EndpointSettings).FullName);
            }
            else
            {
                Endpoint endpointFrom = endpointSettings.EndpointFrom;
                ReadData(endpointFrom, pipelineStep, pipelineContext, logger);
                
            }
        }
        //protected override void ReadData(Endpoint endpoint, PipelineStep pipelineStep, PipelineContext pipelineContext, ILogger logger)
        //{
        //    if (endpoint == null)
        //    {
        //        throw new ArgumentNullException(nameof(endpoint));
        //    }
        //    if (pipelineStep == null)
        //    {
        //        throw new ArgumentNullException(nameof(pipelineStep));
        //    }
        //    if (pipelineContext == null)
        //    {
        //        throw new ArgumentNullException(nameof(pipelineContext));
        //    }

        //    var redditSettings = endpoint.GetPlugin<RedditSettings>();
        //    if (redditSettings != null)
        //    {
        //        pipelineContext.PipelineBatchContext.Logger.Info(
        //            "Creating Reddit Items for:" + redditSettings.BlogPath);
        //        RedditFeed(pipelineContext, redditSettings.BlogPath);
        //        pipelineContext.PipelineBatchContext.Logger.Info(
        //           "Done Creating Reddit Items for:" + redditSettings.BlogPath);
        //    }
        //}
        //private void RedditFeed(PipelineContext pipelineContext, string blogpath)
        //{
        //    var reddit = new Reddit();
        //    var subreddit = reddit.GetSubreddit(blogpath);
        //    var dataSettings = new IterableDataSettings(subreddit.New.Take(25));
        //    pipelineContext.AddPlugin(dataSettings);
        //}

        protected override void ReadData(Endpoint endpoint, PipelineStep pipelineStep, PipelineContext pipelineContext, ILogger logger)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (pipelineStep == null)
            {
                throw new ArgumentNullException(nameof(pipelineStep));
            }
            if (pipelineContext == null)
            {
                throw new ArgumentNullException(nameof(pipelineContext));
            }

            var redditSettings = endpoint.GetPlugin<RedditSettings>();
            if (redditSettings != null)
            {
                pipelineContext.PipelineBatchContext.Logger.Info(
                    "Creating Reddit Items for:" + redditSettings.BlogPath);
                RedditFeed(pipelineContext, redditSettings.BlogPath);
                pipelineContext.PipelineBatchContext.Logger.Info(
                   "Done Creating Reddit Items for:" + redditSettings.BlogPath);
            }
        }
        private void RedditFeed(PipelineContext pipelineContext, string blogpath)
        {
            var reddit = new Reddit();
            //var subreddit = reddit.(blogpath);
            var subreddit = reddit.GetSubreddit(blogpath);
            var dataSettings = new IterableDataSettings(subreddit.New.Take(25));
            pipelineContext.AddPlugin(dataSettings);
        }

       
    }
}
