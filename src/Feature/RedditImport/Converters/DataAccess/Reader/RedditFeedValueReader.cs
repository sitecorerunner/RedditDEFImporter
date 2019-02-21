using System;
using Sitecore.DataExchange.DataAccess;

namespace Sitecore.DEF.RedditImport.Converters.DataAccess.Reader
{
    public class RedditFeedValueReader: IValueReader
    {
        public readonly string FieldName;

        public bool UseValueProperty { get; set; }

        public RedditFeedValueReader(string fieldName)
        {
            this.FieldName = fieldName;

        }

        public ReadResult CanRead(object source, DataAccessContext context)
        {
            bool flag = source != null && source is RedditSharp.Things.Post;
            return new ReadResult(DateTime.Now)
            {
                ReadValue = source,
                WasValueRead = flag,

            };
        }

        public ReadResult Read(object source, DataAccessContext context)
        {
            var flag = false;
            object readValue = (object) null;
            var feeditem = source as RedditSharp.Things.Post;
            if (feeditem != null)
            {
                if (FieldName == "Title" && !string.IsNullOrEmpty(feeditem.Title))
                {
                    readValue = feeditem.Title;
                    flag = true;
                }
                else if (FieldName == "AuthorName" && !string.IsNullOrEmpty(feeditem.AuthorName))
                {
                    readValue = feeditem.AuthorName;
                    flag = true;
                }
                else if (FieldName == "SelfText" && !string.IsNullOrEmpty(feeditem.SelfText))
                {
                    readValue = feeditem.SelfText;
                    flag = true;
                }
                else if (FieldName == "Url" && !string.IsNullOrEmpty(feeditem.Url.ToString()))
                {
                    readValue = feeditem.Url;
                    flag = true;
                }
            }
            return new ReadResult(DateTime.Now)
            {
                WasValueRead = flag,
                ReadValue = readValue
            };
        }
    }
}