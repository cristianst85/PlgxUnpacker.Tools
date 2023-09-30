namespace PlgxUnpacker.Updater
{
    public interface IWebUpdater
    {
        UpdateInfo Check(string updateUrl);
    }
}
