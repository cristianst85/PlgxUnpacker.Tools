using PlgxUnpacker.Extensions;
using System;
using System.IO;
using System.Net;

namespace PlgxUnpacker.Updater
{
    public abstract class WebUpdater : IWebUpdater
    {
        public virtual UpdateInfo Check(string updateUrl)
        {
            if (updateUrl.IsNullOrEmpty())
            {
                throw new ArgumentException("Update URL cannot be a null or an empty string.");
            }

            return Parse(RetrieveContentFromUrl(updateUrl));
        }

        protected abstract UpdateInfo Parse(string fileContent);

        protected virtual string RetrieveContentFromUrl(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = Configuration.Settings.UserAgent;

            string content = string.Empty;

            using (var response = request.GetResponse())
            {
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    content = streamReader.ReadToEnd();
                }
            }

            return content;
        }
    }
}
