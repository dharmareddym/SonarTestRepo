namespace SonarTest.IntgTest.Comparators
{
    public class ComparatorHelper : IComparatorHelper
    {

        public Dictionary<string, List<string>> GetCartonAndAssociatedLines(string fileContent, string depotNumber)
        {
            string headerPrefix = "F" + depotNumber + "AH";
            List<string> recordsList = fileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
            Dictionary<string, List<string>> deliveryUnits = new Dictionary<string, List<string>>();
            List<string> duLines = recordsList.Where(x => x.StartsWith(headerPrefix)).ToList();
            for (int i = 0; i < duLines.Count; i++)
            {
                List<string> lst = null;
                int indexofDu = recordsList.IndexOf(duLines[i]);
                if ((i + 1) < duLines.Count)
                {
                    int indexofNextDu = recordsList.IndexOf(duLines[i + 1]);
                    int itemCount = (indexofNextDu - indexofDu) - 1;
                    lst = recordsList.GetRange(indexofDu, itemCount + 1);
                }
                else
                {
                    int totalLinecount = recordsList.Count();
                    int lastDuLineitemCount = (totalLinecount - recordsList.IndexOf(duLines[i])) - 1;
                    lst = recordsList.GetRange(indexofDu, lastDuLineitemCount + 1);
                }
                // string cartonNumber = duLines[i].Split("|")[1];
                string cartonNumber = duLines[i].Substring(22, 20).Trim();

                if (!deliveryUnits.ContainsKey(cartonNumber))
                {
                    deliveryUnits.Add(cartonNumber, lst);
                }
                else
                {
                    List<string> lines = deliveryUnits[cartonNumber];
                    lines.AddRange(lst);
                }
            }
            return deliveryUnits;
        }
    }
}
