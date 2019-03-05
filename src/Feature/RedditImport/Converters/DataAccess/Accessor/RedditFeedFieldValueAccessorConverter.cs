using System;
using Sitecore.DataExchange;
using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters.DataAccess.ValueAccessors;
using Sitecore.DataExchange.DataAccess;
using Sitecore.DataExchange.DataAccess.Readers;
using Sitecore.DataExchange.DataAccess.Writers;
using Sitecore.DataExchange.Repositories;
using Sitecore.DEF.RedditImport.Models.ItemModels.DataAccess;
using Sitecore.Services.Core.Model;

namespace Sitecore.DEF.RedditImport.Converters.DataAccess.Accessor
{
    [SupportedIds("{68BD9AAD-635F-40F3-9ACD-711662C59EEC}")]
    public class RedditFeedFieldValueAccessorConverter:ValueAccessorConverter
    {
        public RedditFeedFieldValueAccessorConverter(IItemModelRepository repository) : base(repository)
        {
        }

        private IValueReader ValueReader { get; set; }
        private IValueWriter ValueWriter { get; set; }
        protected override ConvertResult<IValueAccessor> ConvertSupportedItem(ItemModel source)
        {
            ConvertResult<IValueAccessor> convertResult = base.ConvertSupportedItem(source);
            if (!convertResult.WasConverted)
                return convertResult;
            string stringValue = this.GetStringValue(source, RedditFeedFieldValueValueAccessorItemModel.RedditFeedFieldName);
            if (string.IsNullOrWhiteSpace(stringValue))
                return this.NegativeResult(source, "The property name field must have a value specified.", string.Format("field: {0}", (object)RedditFeedFieldValueValueAccessorItemModel.RedditFeedFieldName));
            IValueAccessor convertedValue = convertResult.ConvertedValue;
            if (convertedValue == null)
                return this.NegativeResult(source, "A null value accessor was returned by the converter.", Array.Empty<string>());
            if (convertedValue.ValueReader == null)
            {
                PropertyValueReader propertyValueReader = new PropertyValueReader(stringValue);
                convertedValue.ValueReader = (IValueReader)propertyValueReader;
            }
            if (convertedValue.ValueWriter == null)
            {
                PropertyValueWriter propertyValueWriter = new PropertyValueWriter(stringValue);
                convertedValue.ValueWriter = (IValueWriter)propertyValueWriter;
            }
            return this.PositiveResult(convertedValue);
        }
    }
}