namespace Delivery.DESADVAdaptorsParallelRun.IntgTest.AzureUtils
{
    public interface ITricepsFileDownloader
    {
       
        void DownloadFiles(string depotId=null);
        void ExtractExpectedFiles();
    }
}