using Delivery.DESADVAdaptorsParallelRun.IntgTest.AzureUtils;
using Delivery.DESADVAdaptorsParallelRun.IntgTest.Comparators;
using lsp_delivery_tricepsadaptor_parallelrun.HouseKeep;

namespace lsp_delivery_tricepsadaptor_parallelrun
{
    public class Startup
    {
        static string depot = "0631";
        public static void Main(string[] args)
        {
            Console.WriteLine("Test");
            new TricepsFileDownloader().ExtractExpectedFiles();
            //new HouseKeeper().DeleteFiles();
            //new TricepsFileDownloader().DownloadFiles();
            //var isTestSuccesful = new Comparator().CompareTricepsFiles(depot);
        }
    }
}
