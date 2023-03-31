﻿namespace SonarTest.IntgTest.Comparators
{
    public interface IASNComparator
    {
        bool CompareASNFileHeader(string expectedFileLine, string actualFileLine);
        bool CompareASNFileFooter(string expectedFileLine, string actualFileLine);
        bool CompareDeliveryUnitHeader(string expectedFileLine, string actualFileLine, string du);
        bool CompareLineItems(string expectedFileLine, string actualFileLine, string du);
    }
}