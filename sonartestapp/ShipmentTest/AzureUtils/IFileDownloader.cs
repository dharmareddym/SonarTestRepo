namespace SonarTest.IntgTest.AzureUtils
{
    public interface IFileDownloader
    {

        void DownloadFiles(string depotId = null);
        void ExtractExpectedFiles();
    }
}