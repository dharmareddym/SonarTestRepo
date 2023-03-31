using Delivery.DESADVAdaptorsParallelRun.IntgTest.constants;

namespace lsp_delivery_tricepsadaptor_parallelrun.Comparators
{
    public class PurchaseOrderComparator : IPurchaseOrderComparator
    {

        public bool ComparePODetail(string expectedFileLine, string actualFileLine)
        {
            try
            {
                List<string> errorList = new List<string>();

                if (expectedFileLine.Substring(0, 1) != actualFileLine.Substring(0, 1))
                {
                    errorList.Add("File Type MissMatch:  Expected  " + expectedFileLine.Substring(0, 1) + " Actual " + actualFileLine.Substring(0, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(1, 4) != actualFileLine.Substring(1, 4))
                {
                    errorList.Add("Receiving Depot MissMatch:  Expected  " + expectedFileLine.Substring(1, 4) + " Actual " + actualFileLine.Substring(1, 4) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(5, 2) != actualFileLine.Substring(5, 2))
                {
                    errorList.Add("Type MissMatch:  Expected  " + expectedFileLine.Substring(5, 2) + " Actual " + actualFileLine.Substring(5, 2) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(7, 8) != actualFileLine.Substring(7, 8))
                {
                    errorList.Add("PO Number  MissMatch:  Expected  " + expectedFileLine.Substring(7, 8) + " Actual " + actualFileLine.Substring(7, 8) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(15, 8) != actualFileLine.Substring(15, 8))
                {
                    errorList.Add("Item Code/SKU MissMatch:  Expected  " + expectedFileLine.Substring(15, 8) + " Actual " + actualFileLine.Substring(15, 8) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(23, 7) != actualFileLine.Substring(23, 7))
                {
                    errorList.Add("QtyOnOrder MissMatch:  Expected  " + expectedFileLine.Substring(23, 7) + " Actual " + actualFileLine.Substring(23, 7) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(30, 11) != actualFileLine.Substring(30, 11))
                {
                    errorList.Add("UnitCost MissMatch:  Expected  " + expectedFileLine.Substring(30, 11) + " Actual " + actualFileLine.Substring(30, 11) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(41, 3) != actualFileLine.Substring(41, 3))
                {
                    errorList.Add("VendorTie MissMatch:  Expected  " + expectedFileLine.Substring(41, 3) + " Actual " + actualFileLine.Substring(41, 3) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(44, 3) != actualFileLine.Substring(44, 3))
                {
                    errorList.Add("VendorTier MissMatch:  Expected  " + expectedFileLine.Substring(44, 3) + " Actual " + actualFileLine.Substring(44, 3) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(47, 3) != actualFileLine.Substring(47, 3))
                {
                    errorList.Add("ItemSeqNumber MissMatch:  Expected  " + expectedFileLine.Substring(47, 3) + " Actual " + actualFileLine.Substring(47, 3) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(50, 1) != actualFileLine.Substring(50, 1))
                {
                    errorList.Add("PAsnInd MissMatch:  Expected  " + expectedFileLine.Substring(50, 1) + " Actual " + actualFileLine.Substring(50, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(51, 5) != actualFileLine.Substring(51, 5))
                {
                    errorList.Add("ReceiptNumber MissMatch:  Expected  " + expectedFileLine.Substring(51, 5) + " Actual " + actualFileLine.Substring(51, 5) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(56, 264) != actualFileLine.Substring(56, 264))
                {
                    errorList.Add("Filler MissMatch:  Expected  " + expectedFileLine.Substring(56, 264) + " Actual " + actualFileLine.Substring(56, 264) + Environment.NewLine);
                }
                if (errorList.Any())
                {
                    if (errorList.Any())
                    {
                        errorList.Insert(0, "Discripencies Observed in POHeader " + Environment.NewLine);
                    }
                    File.AppendAllText(ApplicationConstants.LOG_FILE, "Discripencies Observed in POHeader " + Environment.NewLine);
                    File.AppendAllText(ApplicationConstants.LOG_FILE, "Expected Value - " + expectedFileLine + Environment.NewLine);
                    File.AppendAllText(ApplicationConstants.LOG_FILE, "Actual Value - " + actualFileLine + Environment.NewLine);
                    File.AppendAllText(ApplicationConstants.LOG_FILE, string.Join(" ", errorList));
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool ComparePOHeader(string expectedFileLine, string actualFileLine)
        {
            try
            {
                List<string> errorList = new List<string>();

                if (expectedFileLine.Substring(0, 1) != actualFileLine.Substring(0, 1))
                {
                    errorList.Add("File Type MissMatch:  Expected  " + expectedFileLine.Substring(0, 1) + " Actual " + actualFileLine.Substring(0, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(1, 4) != actualFileLine.Substring(1, 4))
                {
                    errorList.Add("Receiving Depot MissMatch:  Expected  " + expectedFileLine.Substring(1, 4) + " Actual " + actualFileLine.Substring(1, 4) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(5, 2) != actualFileLine.Substring(5, 2))
                {
                    errorList.Add("Type MissMatch:  Expected  " + expectedFileLine.Substring(5, 2) + " Actual " + actualFileLine.Substring(5, 2) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(7, 8) != actualFileLine.Substring(7, 8))
                {
                    errorList.Add("PO Number  MissMatch:  Expected  " + expectedFileLine.Substring(7, 8) + " Actual " + actualFileLine.Substring(7, 8) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(15, 8) != actualFileLine.Substring(15, 8))
                {
                    errorList.Add("Date Scheduled  MissMatch:  Expected  " + expectedFileLine.Substring(15, 8) + " Actual " + actualFileLine.Substring(15, 8) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(23, 4) != actualFileLine.Substring(23, 4))
                {
                    errorList.Add("Time Scheduled  MissMatch:  Expected  " + expectedFileLine.Substring(23, 4) + " Actual " + actualFileLine.Substring(23, 4) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(27, 1) != actualFileLine.Substring(27, 1))
                {
                    errorList.Add("Transport Type  MissMatch:  Expected  " + expectedFileLine.Substring(27, 1) + " Actual " + actualFileLine.Substring(27, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(28, 1) != actualFileLine.Substring(28, 1))
                {
                    errorList.Add("Load Type  MissMatch:  Expected  " + expectedFileLine.Substring(28, 1) + " Actual " + actualFileLine.Substring(28, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(29, 12) != actualFileLine.Substring(29, 12))
                {
                    errorList.Add("Carrier MissMatch:  Expected  " + expectedFileLine.Substring(29, 12) + " Actual " + actualFileLine.Substring(29, 12) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(41, 6) != actualFileLine.Substring(41, 6))
                {
                    errorList.Add("vendor MissMatch:  Expected  " + expectedFileLine.Substring(41, 6) + " Actual " + actualFileLine.Substring(41, 6) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(47, 1) != actualFileLine.Substring(47, 1))
                {
                    errorList.Add("POkToBackOrder MissMatch:  Expected  " + expectedFileLine.Substring(47, 1) + " Actual " + actualFileLine.Substring(47, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(48, 2) != actualFileLine.Substring(48, 2))
                {
                    errorList.Add("PBuyerNumber MissMatch:  Expected  " + expectedFileLine.Substring(48, 2) + " Actual " + actualFileLine.Substring(48, 2) + Environment.NewLine);

                }
                if (expectedFileLine.Substring(50, 120) != actualFileLine.Substring(50, 120))
                {
                    errorList.Add("Comments MissMatch:  Expected  " + expectedFileLine.Substring(50, 120) + " Actual " + actualFileLine.Substring(50, 120) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(170, 1) != actualFileLine.Substring(170, 1))
                {
                    errorList.Add("PFreightBillFlag MissMatch:  Expected  " + expectedFileLine.Substring(170, 1) + " Actual " + actualFileLine.Substring(170, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(171, 4) != actualFileLine.Substring(171, 4))
                {
                    errorList.Add("PHdrShipToFacWhse MissMatch:  Expected  " + expectedFileLine.Substring(171, 4) + " Actual " + actualFileLine.Substring(171, 4) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(175, 1) != actualFileLine.Substring(175, 1))
                {
                    errorList.Add("PXdocType MissMatch:  Expected  " + expectedFileLine.Substring(175, 1) + " Actual " + actualFileLine.Substring(175, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(176, 2) != actualFileLine.Substring(176, 2))
                {
                    errorList.Add("POType MissMatch:  Expected  " + expectedFileLine.Substring(176, 2) + " Actual " + actualFileLine.Substring(176, 2) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(178, 1) != actualFileLine.Substring(178, 1))
                {
                    errorList.Add("BuyerPriority MissMatch:  Expected  " + expectedFileLine.Substring(178, 1) + " Actual " + actualFileLine.Substring(178, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(179, 6) != actualFileLine.Substring(179, 6))
                {
                    errorList.Add("CalcPriority MissMatch:  Expected  " + expectedFileLine.Substring(179, 6) + " Actual " + actualFileLine.Substring(179, 6) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(185, 1) != actualFileLine.Substring(185, 1))
                {
                    errorList.Add("DeliveryType MissMatch:  Expected  " + expectedFileLine.Substring(185, 1) + " Actual " + actualFileLine.Substring(185, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(186, 134) != actualFileLine.Substring(186, 134))
                {
                    errorList.Add("Filler  MissMatch:  Expected  " + expectedFileLine.Substring(186, 134) + " Actual " + actualFileLine.Substring(186, 134) + Environment.NewLine);
                }

                if (errorList.Any())
                {
                    if (errorList.Any())
                    {
                        errorList.Insert(0, "Discripencies Observed in POHeader " + Environment.NewLine);
                    }
                    File.AppendAllText(ApplicationConstants.LOG_FILE, "Discripencies Observed in POHeader " + Environment.NewLine);
                    File.AppendAllText(ApplicationConstants.LOG_FILE, "Expected Value - " + expectedFileLine + Environment.NewLine);
                    File.AppendAllText(ApplicationConstants.LOG_FILE, "Actual Value - " + actualFileLine + Environment.NewLine);
                    File.AppendAllText(ApplicationConstants.LOG_FILE, string.Join(" ", errorList));
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
