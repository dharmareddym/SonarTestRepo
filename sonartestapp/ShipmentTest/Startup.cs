using Delivery.DESADVAdaptorsParallelRun.IntgTest.AzureUtils;
using SonarTest.IntgTest.Comparators;

namespace SonarTest.IntgTest
{
    public class Startup
    {
        static string depot = "123";
        public static void Main(string[] args)
        {
            Console.WriteLine("Test");
            new FileDownloader().ExtractExpectedFiles();

           new Comparator().CompareFiles(depot);
        }
    }
}
