namespace SonarTest.IntgTest.Comparators
{
    public interface IComparatorHelper
    {
        public Dictionary<string, List<string>> GetCartonAndAssociatedLines(string fileContent, string depotNumber);
    }
}