using SonarTest.constants;
using SonarTest.IntgTest.constants;


namespace SonarTest.IntgTest.Comparators
{
    public class Comparator : IComparator
    {
        private readonly IComparatorHelper _comparatorHelper;
        private readonly IASNComparator _asnComparator;
        private readonly IPurchaseOrderComparator _purchaseOrderComparator;
        public Comparator()
        {
            _comparatorHelper = new ComparatorHelper();
            _asnComparator = new ASNComparator();
            _purchaseOrderComparator = new PurchaseOrderComparator();
        }

        public bool CompareFiles(string depotNumber)
        {
            try
            {
                int comparisonCount = 0;
                File.AppendAllText(ApplicationConstants.LOG_FILE, $"Triceps Adaptor Results" + Environment.NewLine);


                var expectedDir = new DirectoryInfo(ApplicationConstants.LOCAL_EXPECTED_FILE_PATH);
                var actualDir = new DirectoryInfo(ApplicationConstants.LOCAL_ACTUAL_FILE_PATH);

                //var expectedDir = new DirectoryInfo(@"C:\Triceps\expected\");
                //var actualDir = new DirectoryInfo(@"C:\Triceps\actual\");

                var expectedFiles = expectedDir.GetFiles("*.*", SearchOption.AllDirectories);
                var actualFiles = actualDir.GetFiles("*.*", SearchOption.AllDirectories);
                //var expectedFiles = expectedDir.GetFiles("*" + partialName + "*.*", SearchOption.AllDirectories);
                //var actualFiles = actualDir.GetFiles("*" + partialName + "*.*", SearchOption.AllDirectories);
                File.AppendAllText(ApplicationConstants.LOG_FILE, $"Expected files found for depots : {depotNumber} are {expectedFiles.Count()}{Environment.NewLine}");
                File.AppendAllText(ApplicationConstants.LOG_FILE, $"Actual files found for depots : {depotNumber} are {actualFiles.Count()}{Environment.NewLine}");
                //A custom file comparer defined below  
                FileCompare myFileCompare = new FileCompare();


                bool areIdentical = expectedFiles.SequenceEqual(actualFiles, myFileCompare);

                if (areIdentical == true)
                {
                    Console.WriteLine("the two folders are the same");
                    File.AppendAllText(ApplicationConstants.LOG_FILE, $"the two folders are the same for depot : " + depotNumber + Environment.NewLine);
                }
                else
                {
                    Console.WriteLine("The two folders are not the same");
                    File.AppendAllText(ApplicationConstants.LOG_FILE, $"the two folders are not the same" + Environment.NewLine);
                }

                // Find the common files. It produces a sequence and doesn't
                // execute until the foreach statement.  
                var queryCommonFiles = expectedFiles.Intersect(actualFiles, myFileCompare);
                List<bool> result = new List<bool>();
                bool compareResult = false;
                if (queryCommonFiles.Any())
                {
                    Console.WriteLine("The following files are in both folders:");
                    File.AppendAllText(ApplicationConstants.LOG_FILE, $"The number of common files in both folders are: " + queryCommonFiles.Count() + Environment.NewLine);

                    foreach (var v in queryCommonFiles)
                    {
                        comparisonCount++;
                        Console.WriteLine(v.FullName);
                        bool retValue;

                        //string actualPath = @"C:\Triceps\actual\";
                        string actualPath = ApplicationConstants.LOCAL_ACTUAL_FILE_PATH;
                        if (Path.GetFileName(v.FullName).StartsWith("IWS"))
                        {
                            retValue = CompareASNFiles(v.FullName, actualPath + v.Name, ApplicationConstants.LOG_FILE, depotNumber);

                        }
                        else
                        {
                            retValue = ComparePOFiles(v.FullName, actualPath + v.Name, ApplicationConstants.LOG_FILE, depotNumber);
                        }
                        result.Add(retValue);
                        //}
                    }
                    if (result.Contains(false))
                        compareResult = false;
                    else
                    {
                        File.AppendAllText(ApplicationConstants.LOG_FILE, new string('-', 100) + Environment.NewLine + $"No issues found" + Environment.NewLine + new string('-', 100) + Environment.NewLine);
                        compareResult = true;
                    }
                }
                else
                {
                    Console.WriteLine("There are no common files in the two folders.");
                    File.AppendAllText(ApplicationConstants.LOG_FILE, $"There are no common files in the two folders." + Environment.NewLine);
                }

                // Find the set difference between the two folders.  
                // For this example we only check one way.  
                var queryList1Only = (from file in expectedFiles
                                      select file).Except(actualFiles, myFileCompare);

                Console.WriteLine("The following files are in expectedlist(Legacy WMS) but not actuallist(New WMS):");
                File.AppendAllText(ApplicationConstants.LOG_FILE, $"The following files are in expectedlist(Legacy WMS) but not actuallist(New WMS):" + Environment.NewLine);
                File.AppendAllText(ApplicationConstants.LOG_FILE, new string('=', 100) + Environment.NewLine);
                foreach (var v in queryList1Only)
                {
                    Console.WriteLine(v.Name);
                    File.AppendAllText(ApplicationConstants.LOG_FILE, v.Name + Environment.NewLine);
                }

                // Find the set difference between the two folders.  
                // For this example we only check one way.  
                var queryList2Only = (from file in actualFiles
                                      select file).Except(expectedFiles, myFileCompare);

                Console.WriteLine("The following files are in actuallist(New WMS) but not expectedlist(Legacy WMS):");
                File.AppendAllText(ApplicationConstants.LOG_FILE, $"The following files are in actuallist(New WMS) but not expectedlist(Legacy WMS):" + Environment.NewLine);
                File.AppendAllText(ApplicationConstants.LOG_FILE, new string('=', 100) + Environment.NewLine);
                foreach (var v in queryList2Only)
                {
                    Console.WriteLine(v.Name);
                    File.AppendAllText(ApplicationConstants.LOG_FILE, v.Name + Environment.NewLine);
                }
                return compareResult;
            }
            catch (Exception) { throw; }
        }

        private bool CompareASNFiles(string file1, string file2, string logFile, string depotNumber)
        {
            try
            {
                List<bool> results = new List<bool>();

                string fileHeaderFooterPrefix = "F" + depotNumber + "AA";
                string[] expectedFileLines = File.ReadAllLines(file1);
                string[] actualFileLines = File.ReadAllLines(file2);

                string expectedFileContent = File.ReadAllText(file1);
                string actualFileContent = File.ReadAllText(file2);


                File.AppendAllText(ApplicationConstants.LOG_FILE, $"Comparison starting with expected-{Path.GetFileName(file1)} and actual-{Path.GetFileName(file2)} files" + Environment.NewLine);

                if (expectedFileLines.Length != actualFileLines.Length)
                {
                    File.AppendAllText(logFile, "Number of lines is different in both files" + Environment.NewLine);
                    File.AppendAllText(logFile, "Expected File Lines : " + expectedFileLines.Length + Environment.NewLine + "Actual File Lines : " + actualFileLines.Length + Environment.NewLine);
                }

                results.Add(CompareTricepsRecords(expectedFileLines[0], actualFileLines[0], string.Empty, RecordType.FILEHEADER));
                results.Add(CompareTricepsRecords(expectedFileLines[expectedFileLines.Length - 1], actualFileLines[actualFileLines.Length - 1], string.Empty, RecordType.FILEFOOTER));

                Dictionary<string, List<string>> expectedDeliveryUnits = _comparatorHelper.GetTricepsCartonAndAssociatedLines(expectedFileContent, depotNumber);
                Dictionary<string, List<string>> actualDeliveryUnits = _comparatorHelper.GetTricepsCartonAndAssociatedLines(actualFileContent, depotNumber);

                string[] expectedDus = expectedDeliveryUnits.Keys.ToList().ToArray();
                for (int i = 0; i < expectedDus.Length; i++)
                {
                    string cartonNumber = expectedDus[i];
                    List<string> expectedLines = expectedDeliveryUnits[cartonNumber];
                    List<string> actualLines = actualDeliveryUnits[cartonNumber];
                    if (expectedLines.Count() == actualLines.Count())
                    {
                        for (int j = 0; j < expectedLines.Count; j++)
                        {
                            string actualLine = string.Empty;
                            string expectedLine = string.Empty;
                            if (j != 0)
                            {
                                expectedLine = expectedLines[j];
                                actualLine = actualLines[j];
                                if (!string.IsNullOrEmpty(expectedLine))
                                {
                                    //string itemPrefix = expectedLine.Substring(0, 50);
                                    // actualLine = actualLines.FirstOrDefault(x => x.StartsWith(itemPrefix));
                                    if (!string.IsNullOrEmpty(expectedLine.Trim()) && !string.IsNullOrEmpty(actualLine.Trim()) && !actualLine.StartsWith(fileHeaderFooterPrefix) && !expectedLine.StartsWith(fileHeaderFooterPrefix))
                                    {
                                        results.Add(CompareTricepsRecords(expectedLine, actualLine, cartonNumber, RecordType.DETAIL));
                                    }
                                }
                            }
                            else
                            {
                                results.Add(CompareTricepsRecords(expectedLines[0], actualLines[0], cartonNumber, RecordType.DUHEADER));
                            }
                        }
                    }
                    else
                    {

                        File.AppendAllText(ApplicationConstants.LOG_FILE, " ******** Number of line items in DU " + cartonNumber + " is not Matching. ****** " + Environment.NewLine);
                    }
                }
                return results.Contains(false) ? false : true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ComparePOFiles(string file1, string file2, string logFile, string depotNumber)
        {
            try
            {
                string[] expectedFileLines = File.ReadAllLines(file1);
                string[] actualFileLines = File.ReadAllLines(file2);

                string expectedFileContent = File.ReadAllText(file1);
                string actualFileContent = File.ReadAllText(file2);

                bool retvalue = false;
                File.AppendAllText(ApplicationConstants.LOG_FILE, $"Comparison starting with expected-{Path.GetFileName(file1)} and actual-{Path.GetFileName(file2)} files" + Environment.NewLine);

                if (expectedFileLines.Length == actualFileLines.Length)
                {
                    CompareTricepsRecords(expectedFileLines[0], actualFileLines[0], "", RecordType.POHEADER);
                    List<string> expectedrecordsList = expectedFileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList().GetRange(1, expectedFileLines.Length - 1);
                    List<string> ActualrecordsList = expectedFileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList().GetRange(1, expectedFileLines.Length - 1);
                    var poLines = expectedrecordsList.GroupBy(s => new { POSKU = s.Substring(0, 24) });
                    foreach (var group in poLines)
                    {
                        foreach (var rec in group)
                        {
                            string actualLine = ActualrecordsList.FirstOrDefault(x => x.StartsWith(group.Key.POSKU));
                            string expectedLine = rec;
                            CompareTricepsRecords(expectedLine, actualLine, string.Empty, RecordType.PODETAIL);
                        }
                    }
                }
                else
                {
                    File.AppendAllText(logFile, "Number of lines is different in both files" + Environment.NewLine);
                    File.AppendAllText(logFile, "Expected File Lines : " + expectedFileLines.Length + Environment.NewLine
                        + "Actual File Lines : " + actualFileLines.Length + Environment.NewLine);
                    retvalue = false;
                }
                //}
                return retvalue;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool CompareTricepsRecords(string expectedFileLine, string actualFileLine, string du, RecordType recordType)
        {
            try
            {
                switch (recordType)
                {
                    case RecordType.POHEADER:
                        return _purchaseOrderComparator.ComparePOHeader(expectedFileLine, actualFileLine);
                    case RecordType.PODETAIL:
                        return _purchaseOrderComparator.ComparePODetail(expectedFileLine, actualFileLine);
                    case RecordType.FILEHEADER:
                        return _asnComparator.CompareASNFileHeader(expectedFileLine, actualFileLine);
                    case RecordType.DUHEADER:
                        return _asnComparator.CompareDeliveryUnitHeader(expectedFileLine, actualFileLine, du);

                    case RecordType.DETAIL:
                        return _asnComparator.CompareLineItems(expectedFileLine, actualFileLine, du);

                    case RecordType.FILEFOOTER:
                        return _asnComparator.CompareASNFileFooter(expectedFileLine, actualFileLine);
                    default:
                        return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
