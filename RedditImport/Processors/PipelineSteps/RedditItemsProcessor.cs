using System;
using System.Linq;
using RedditSharp;
using Sitecore.DataExchange.Contexts;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Plugins;
using Sitecore.DataExchange.Processors.PipelineSteps;
using Sitecore.DEF.RedditImport.Plugins;

namespace Sitecore.DEF.RedditImport.Processors.PipelineSteps
{
    [Sitecore.DataExchange.Attributes.RequiredEndpointPlugins(typeof(RedditSettings))]
    public class RedditItemsProcessor : BaseReadDataStepProcessor
    {
        protected override void ReadData(Endpoint endpoint, Sitecore.DataExchange.Models.PipelineStep pipelineStep, PipelineContext pipelineContext)
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
                    "Creating Reddit items for: " + redditSettings.BlogPath);
                RedditFeed(pipelineContext, redditSettings.BlogPath);
                    pipelineContext.PipelineBatchContext.Logger.Info(
                    "Done creating Reddit items for: " + redditSettings.BlogPath);
            }
        }
        private void RedditFeed(PipelineContext pipelineContext, string blogpath)
        {
            var reddit = new Reddit();
            var subreddit = reddit.GetSubreddit(blogpath);
            var redditfeedresults = new IterableDataSettings(subreddit.New.Take(25));
            pipelineContext.Plugins.Add(redditfeedresults);
        }
    }
}
