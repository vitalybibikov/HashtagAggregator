using System;

namespace MyStudyProject.Core.Cqrs.Converters
{
    public class MessageConverter
    {
        public string ConvertBody(string body, int length)
        {
            if (!String.IsNullOrWhiteSpace(body) && body.Length > length)
            {
                body = body.Substring(0, length);
            }
            return body;
        }
    }
}
