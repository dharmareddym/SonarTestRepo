using System.Collections.Generic;

namespace Delivery.DESADVAdaptorsParallelRun.IntgTest.Comparators
{
    public interface IComparatorHelper
    {
        public Dictionary<string, List<string>> GetTricepsCartonAndAssociatedLines(string fileContent, string depotNumber);
    }
}