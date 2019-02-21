using System;
using Sitecore.DataExchange;
using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters.DataAccess.ValueAccessors;
using Sitecore.DataExchange.DataAccess;
using Sitecore.DataExchange.DataAccess.Readers;
using Sitecore.DataExchange.DataAccess.Writers;
using Sitecore.DataExchange.Repositories;
using Sitecore.DEF.RedditImport.Converters.DataAccess.Reader;
using Sitecore.DEF.RedditImport.Models.ItemModels.DataAccess;
using Sitecore.Services.Core.Model;

namespace Sitecore.DEF.RedditImport.Converters.DataAccess.Accessor
{
    [SupportedIds("{68BD9AAD-635F-40F3-9ACD-711662C59EEC}")]
    public class RedditFeedFieldValueAccessorConverter:ValueAccessorConverter
    {
        //private static readonly Guid TemplateId = Guid.Parse("{68BD9AAD-635F-40F3-9ACD-711662C59EEC}");
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
        //Begin STACK EXCHANGE
        //public RedditFeedFieldValueAccessorConverter(IItemModelRepository repository) : base(repository)
        //{
        //}
        //protected override IValueReader GetValueReader(ItemModel source)
        //{
        //    IValueReader valueReader = base.GetValueReader(source);
        //    if (valueReader != null)
        //    {
        //        return valueReader;
        //    }

        //    var fieldName = base.GetStringValue(source, RedditFeedFieldValueValueAccessorItemModel.RedditFeedFieldName);
        //    if (string.IsNullOrEmpty(fieldName))
        //    {
        //        return null;
        //    }

        //    return new RedditFeedValueReader(fieldName);
        //}

        //protected override IValueWriter GetValueWriter(ItemModel source)
        //{
        //    IValueWriter valueWriter = base.GetValueWriter(source);
        //    if (valueWriter != null)
        //    {
        //        return valueWriter;
        //    }

        //    var fieldName = base.GetStringValue(source, RedditFeedFieldValueValueAccessorItemModel.RedditFeedFieldName);
        //    if (string.IsNullOrEmpty(fieldName))
        //    {
        //        return null;
        //    }

        //    return new PropertyValueWriter(fieldName);
        //}
        //End STACK EXCHANGE

        //public RedditFeedFieldValueAccessorConverter(IItemModelRepository repository) : base(repository)
        //{

        //}

        //protected override IValueReader GetValueReader(ItemModel source)
        //{
        //    IValueReader valueReader = base.GetValueReader(source);
        //    if (valueReader != null)
        //    {
        //        return valueReader;
        //    }

        //    var fieldName = base.GetStringValue(source, RedditFeedFieldValueValueAccessorItemModel.RedditFeedFieldName);
        //    if (string.IsNullOrEmpty(fieldName))
        //    {
        //        return null;
        //    }
        //    var elementName = base.GetStringValue(source,
        //                                        RedditFeedFieldValueValueAccessorItemModel.RedditFeedFieldName);
        //    if (string.IsNullOrWhiteSpace(elementName))
        //    {
        //        return null;
        //    }
        //    return new RedditFeedValueReader(fieldName);
        //}
        //protected override IValueWriter GetValueWriter(ItemModel source)
        //{
        //    IValueWriter valueWriter = base.GetValueWriter(source);
        //    if (valueWriter != null)
        //    {
        //        return valueWriter;
        //    }

        //    var fieldName = base.GetStringValue(source, RedditFeedFieldValueValueAccessorItemModel.RedditFeedFieldName);
        //    if (string.IsNullOrEmpty(fieldName))
        //    {
        //        return null;
        //    }

        //    return new RedditFeedValueReader(fieldName);
        //}
        //protected override ConvertResult<IValueAccessor> ConvertSupportedItem(ItemModel source)
        //{
        //    //ConvertResult<IValueAccessor> result = base.ConvertSupportedItem(source);
        //    var accessor = base.ConvertSupportedItem(source);
        //    if (accessor == null)
        //    {
        //        return null;
        //    }

        //    var fieldName = base.GetStringValue(source, RedditFeedFieldValueValueAccessorItemModel.RedditFeedFieldName);
        //    if (string.IsNullOrEmpty(fieldName))
        //    {
        //        return null;
        //    }

        //    ValueWriter = this.GetValueWriter(source);
        //    // ValueReader= this.GetValueReader(source) ?? new RedditFeedValueReader(fieldName);
        //    if (accessor.ValueReader == null)
        //    {
        //        accessor.ValueReader = new RedditFeedValueReader(fieldName);
        //    }

        //    if (ValueWriter == null)
        //    {
        //        ValueWriter = new PropertyValueWriter(fieldName);
        //    }
        //    return this.PositiveResult((IValueAccessor)new ValueAccessor());
        //}

        //protected override IValueAccessor ConvertResult(ItemModel source)
        //{
        //    var accessor = base.Convert(source);
        //    if (accessor == null)
        //    {
        //        return null;
        //    }
        //    var fieldName = base.GetStringValue(source, RedditFeedFieldValueValueAccessorItemModel.RedditFeedFieldName);
        //    if (String.IsNullOrEmpty(fieldName))
        //    {
        //        return null;
        //    }
        //    if (accessor.ValueReader == null)
        //    {
        //        accessor.ValueReader = new RedditFeedValueReader(fieldName);
        //    }
        //    if (accessor.ValueWriter == null)
        //    {
        //        accessor.ValueWriter = new PropertyValueWriter(fieldName);
        //    }
        //    return accessor;
        //}
    }
}