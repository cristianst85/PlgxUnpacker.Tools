using Newtonsoft.Json;
using PlgxUnpacker.Helpers;
using PlgxUnpacker.Updater.GitHubApi;
using System;
using System.IO;

namespace PlgxUnpacker.Updater
{
    public class GitHubWebUpdater : WebUpdater
    {
        public GitHubWebUpdater() : base()
        {
        }

        public override UpdateInfo Check(string updateUrl)
        {
            SetSecurityProtocol();

            return base.Check(updateUrl);
        }

        protected override UpdateInfo Parse(string fileContent)
        {
            var release = JsonConvert.DeserializeObject<Release>(fileContent);

            var updateInfo = new UpdateInfo()
            {
                Version = new Version(release.TagName.TrimStart('v').Trim()),
                DownloadPage = release.HtmlUrl
            };

            foreach (var asset in release.Assets)
            {
                if (asset.Name.StartsWith(Configuration.Settings.ApplicationName) && Path.GetExtension(asset.Name).Equals(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    updateInfo.DownloadUrl = asset.BrowserDownloadUrl;
                    break;
                }
            }

            if (updateInfo.DownloadUrl == null)
            {
                throw new Exception("Release asset was not found.");
            }

            return updateInfo;
        }

        private void SetSecurityProtocol()
        {
            // As of February 22, 2018 GitHub API no longer supports TLSv1 / TLSv1.1 requests.
            // See: https://githubengineering.com/crypto-removal-notice/
            ServicePointManagerHelper.SetSecurityProtocolToTls12();
        }
    }
}
