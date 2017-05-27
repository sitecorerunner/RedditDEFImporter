using System;
using Sitecore.DataExchange.Converters.DataAccess.ValueAccessors;
using Sitecore.DataExchange.DataAccess;
using Sitecore.DataExchange.DataAccess.Writers;
using Sitecore.DataExchange.Repositories;
using Sitecore.DEF.RedditImport.Converters.DataAccess.Reader;
using Sitecore.DEF.RedditImport.Models.ItemModels.DataAccess;
using Sitecore.Services.Core.Model;

namespace Sitecore.DEF.RedditImport.Converters.DataAccess.Accessor
{
    public class RedditFeedFieldValueAccessorConverter:ValueAccessorConverter
    {
        private static readonly Guid TemplateId = Guid.Parse("{68BD9AAD-635F-40F3-9ACD-711662C59EEC}");
        public RedditFeedFieldValueAccessorConverter(IItemModelRepository repository) : base(repository)
        {
            this.SupportedTemplateIds.Add(TemplateId);
        }
        public override IValueAccessor Convert(ItemModel source)
        {
            var accessor = base.Convert(source);
            if (accessor == null)
            {
                return null;
            }
            var fieldName = base.GetStringValue(source, RedditFeedFieldValueValueAccessorItemModel.RedditFeedFieldName);
            if (String.IsNullOrEmpty(fieldName))
            {
                return null;
            }
            if (accessor.ValueReader == null)
            {
                accessor.ValueReader = new RedditFeedValueReader(fieldName);
            }
            if (accessor.ValueWriter == null)
            {
                accessor.ValueWriter = new PropertyValueWriter(fieldName);
            }
            return accessor;
        }
    }
}