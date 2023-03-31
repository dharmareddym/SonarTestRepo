namespace SonarTest.IntgTest.Comparators
{
    public interface IPurchaseOrderComparator
    {
        public bool ComparePOHeader(string expectedFileLine, string actualFileLine);
        public bool ComparePODetail(string expectedFileLine, string actualFileLine);
    }
}