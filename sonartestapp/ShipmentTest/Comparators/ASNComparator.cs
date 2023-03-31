using Delivery.DESADVAdaptorsParallelRun.IntgTest.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lsp_delivery_tricepsadaptor_parallelrun.Comparators
{
    public class ASNComparator : IASNComparator
    {

        public bool CompareASNFileHeader(string expectedFileLine, string actualFileLine)
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
                    errorList.Add("Type  MissMatch:  Expected  " + expectedFileLine.Substring(5, 2) + " Actual " + actualFileLine.Substring(5, 2) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(7, 15) != actualFileLine.Substring(7, 15))
                {
                    errorList.Add("ASN MissMatch: Expected  " + expectedFileLine.Substring(7, 15) + " Actual " + actualFileLine.Substring(7, 15) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(22, 2) != actualFileLine.Substring(22, 2))
                {
                    errorList.Add("FBuyerNumber MissMatch  Expected  " + expectedFileLine.Substring(22, 2) + " Actual " + actualFileLine.Substring(22, 2) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(24, 8) != actualFileLine.Substring(24, 8))
                {
                    errorList.Add("FDateScheduled MissMatch  Expected  " + expectedFileLine.Substring(24, 8) + " Actual " + actualFileLine.Substring(24, 8) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(32, 4) != actualFileLine.Substring(32, 4))
                {
                    errorList.Add("FTimeScheduled MissMatch  Expected  " + expectedFileLine.Substring(32, 4) + " Actual " + actualFileLine.Substring(32, 4) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(36, 7) != actualFileLine.Substring(36, 7))
                {
                    errorList.Add("FDoorScheduled  MissMatch  Expected  " + expectedFileLine.Substring(36, 7) + " Actual " + actualFileLine.Substring(36, 7) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(43, 6) != actualFileLine.Substring(43, 6))
                {
                    errorList.Add("FSource  MissMatch  Expected  " + expectedFileLine.Substring(43, 6) + " Actual " + actualFileLine.Substring(43, 6) + Environment.NewLine);
                }

                if (expectedFileLine.Substring(49, 1) != actualFileLine.Substring(49, 1))
                {
                    errorList.Add("FSourceType  MissMatch  Expected  " + expectedFileLine.Substring(49, 1) + " Actual " + actualFileLine.Substring(49, 1) + Environment.NewLine);
                }

                if (expectedFileLine.Substring(50, 2) != actualFileLine.Substring(50, 2))
                {
                    errorList.Add("FShipToWharehouse   MissMatch  Expected  " + expectedFileLine.Substring(50, 2) + " Actual " + actualFileLine.Substring(50, 2) + Environment.NewLine);
                }

                if (expectedFileLine.Substring(52, 6) != actualFileLine.Substring(52, 6))
                {
                    errorList.Add("FDestination   MissMatch  Expected  " + expectedFileLine.Substring(36, 7) + " Actual " + actualFileLine.Substring(52, 6) + Environment.NewLine);
                }

                if (expectedFileLine.Substring(58, 1) != actualFileLine.Substring(58, 1))
                {
                    errorList.Add("FDestinationType   MissMatch  Expected  " + expectedFileLine.Substring(58, 1) + " Actual " + actualFileLine.Substring(58, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(59, 8) != actualFileLine.Substring(59, 8))
                {
                    errorList.Add("FDestinationType   MissMatch  Expected  " + expectedFileLine.Substring(59, 8) + " Actual " + actualFileLine.Substring(59, 8) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(67, 4) != actualFileLine.Substring(67, 4))
                {
                    errorList.Add("FDestinationType   MissMatch  Expected  " + expectedFileLine.Substring(67, 4) + " Actual " + actualFileLine.Substring(67, 4) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(71, 1) != actualFileLine.Substring(71, 1))
                {
                    errorList.Add("FDestinationType   MissMatch  Expected  " + expectedFileLine.Substring(71, 1) + " Actual " + actualFileLine.Substring(71, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(71, 1) != actualFileLine.Substring(71, 1))
                {
                    errorList.Add("FTransportType   MissMatch  Expected  " + expectedFileLine.Substring(71, 1) + " Actual " + actualFileLine.Substring(71, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(72, 1) != actualFileLine.Substring(72, 1))
                {
                    errorList.Add("FLoadType   MissMatch  Expected  " + expectedFileLine.Substring(72, 1) + " Actual " + actualFileLine.Substring(72, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(73, 6) != actualFileLine.Substring(73, 6))
                {
                    errorList.Add("Carrier   MissMatch  Expected  " + expectedFileLine.Substring(73, 6) + " Actual " + actualFileLine.Substring(73, 6) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(79, 7) != actualFileLine.Substring(79, 7))
                {
                    errorList.Add("TotalUnits   MissMatch  Expected  " + expectedFileLine.Substring(79, 7) + " Actual " + actualFileLine.Substring(79, 7) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(86, 11) != actualFileLine.Substring(86, 11))
                {
                    errorList.Add("TotalWeight   MissMatch  Expected  " + expectedFileLine.Substring(86, 11) + " Actual " + actualFileLine.Substring(86, 11) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(97, 9) != actualFileLine.Substring(97, 9))
                {
                    errorList.Add("TotalCube   MissMatch  Expected  " + expectedFileLine.Substring(97, 9) + " Actual " + actualFileLine.Substring(97, 9) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(106, 7) != actualFileLine.Substring(106, 7))
                {
                    errorList.Add("TotalBoxes   MissMatch  Expected  " + expectedFileLine.Substring(106, 7) + " Actual " + actualFileLine.Substring(106, 7) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(113, 7) != actualFileLine.Substring(113, 7))
                {
                    errorList.Add("TotalSets   MissMatch  Expected  " + expectedFileLine.Substring(113, 7) + " Actual " + actualFileLine.Substring(113, 7) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(120, 30) != actualFileLine.Substring(120, 30))
                {
                    errorList.Add("Comments   MissMatch  Expected  " + expectedFileLine.Substring(120, 30) + " Actual " + actualFileLine.Substring(120, 30) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(151, 1) != actualFileLine.Substring(151, 1))
                {
                    errorList.Add("FTrailerClass   MissMatch  Expected  " + expectedFileLine.Substring(151, 1) + " Actual " + actualFileLine.Substring(151, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(152, 168) != actualFileLine.Substring(152, 168))
                {
                    errorList.Add("Filler   MissMatch  Expected  " + expectedFileLine.Substring(152, 168) + " Actual " + actualFileLine.Substring(152, 168) + Environment.NewLine);
                }
                if (errorList.Any())
                {
                    if (errorList.Any())
                    {
                        errorList.Insert(0, "Discripencies Observed in File Header " + Environment.NewLine);
                    }
                    File.AppendAllText(ApplicationConstants.LOG_FILE, "Discripencies Observed in File Header " + Environment.NewLine);
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
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool CompareASNFileFooter(string expectedFileLine, string actualFileLine)
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
                    errorList.Add("Type  MissMatch:  Expected  " + expectedFileLine.Substring(5, 2) + " Actual " + actualFileLine.Substring(5, 2) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(7, 15) != actualFileLine.Substring(7, 15))
                {
                    errorList.Add("ASN MissMatch: Expected  " + expectedFileLine.Substring(7, 15) + " Actual " + actualFileLine.Substring(7, 15) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(22, 2) != actualFileLine.Substring(22, 2))
                {
                    errorList.Add("Buyer MissMatch: Expected  " + expectedFileLine.Substring(22, 2) + " Actual " + actualFileLine.Substring(22, 2) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(24, 8) != actualFileLine.Substring(24, 8))
                {
                    errorList.Add("Date Scheduled MissMatch: Expected  " + expectedFileLine.Substring(24, 8) + " Actual " + actualFileLine.Substring(24, 8) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(32, 4) != actualFileLine.Substring(32, 4))
                {
                    errorList.Add("Time Scheduled MissMatch: Expected  " + expectedFileLine.Substring(32, 4) + " Actual " + actualFileLine.Substring(32, 4) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(36, 7) != actualFileLine.Substring(36, 7))
                {
                    errorList.Add("Door Scheduled MissMatch: Expected  " + expectedFileLine.Substring(36, 7) + " Actual " + actualFileLine.Substring(36, 7) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(43, 6) != actualFileLine.Substring(43, 6))
                {
                    errorList.Add("Source MissMatch: Expected  " + expectedFileLine.Substring(43, 6) + " Actual " + actualFileLine.Substring(43, 6) + Environment.NewLine);

                }
                if (expectedFileLine.Substring(49, 1) != actualFileLine.Substring(49, 1))
                {
                    errorList.Add("Source-Type MissMatch: Expected  " + expectedFileLine.Substring(49, 1) + " Actual " + actualFileLine.Substring(49, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(50, 2) != actualFileLine.Substring(50, 2))
                {
                    errorList.Add("ShipTo/WHSE  MissMatch: Expected  " + expectedFileLine.Substring(50, 2) + " Actual " + actualFileLine.Substring(50, 2) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(52, 6) != actualFileLine.Substring(52, 6))
                {
                    errorList.Add("DESTINATION  MissMatch: Expected  " + expectedFileLine.Substring(52, 6) + " Actual " + actualFileLine.Substring(52, 6) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(58, 1) != actualFileLine.Substring(58, 1))
                {
                    errorList.Add("DESTINATION-Type  MissMatch: Expected  " + expectedFileLine.Substring(58, 1) + " Actual " + actualFileLine.Substring(58, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(59, 8) != actualFileLine.Substring(59, 8))
                {
                    errorList.Add("DATE-CREATED  MissMatch: Expected  " + expectedFileLine.Substring(59, 8) + " Actual " + actualFileLine.Substring(59, 8) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(67, 4) != actualFileLine.Substring(67, 4))
                {
                    errorList.Add("TIME-CREATED  MissMatch: Expected  " + expectedFileLine.Substring(67, 4) + " Actual " + actualFileLine.Substring(67, 4) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(71, 1) != actualFileLine.Substring(71, 1))
                {
                    errorList.Add("TRANSPORT-TYPE  MissMatch: Expected  " + expectedFileLine.Substring(71, 1) + " Actual " + actualFileLine.Substring(71, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(72, 1) != actualFileLine.Substring(72, 1))
                {
                    errorList.Add("LOAD-TYPE  MissMatch: Expected  " + expectedFileLine.Substring(72, 1) + " Actual " + actualFileLine.Substring(72, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(73, 6) != actualFileLine.Substring(73, 6))
                {
                    errorList.Add("CARRIER  MissMatch: Expected  " + expectedFileLine.Substring(73, 6) + " Actual " + actualFileLine.Substring(73, 6) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(79, 7) != actualFileLine.Substring(79, 7))
                {
                    errorList.Add("TotalUnits  MissMatch: Expected  " + expectedFileLine.Substring(79, 7) + " Actual " + actualFileLine.Substring(79, 7) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(86, 11) != actualFileLine.Substring(86, 11))
                {
                    errorList.Add("TotalWeight  MissMatch: Expected  " + expectedFileLine.Substring(86, 11) + " Actual " + actualFileLine.Substring(86, 11) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(97, 9) != actualFileLine.Substring(97, 9))
                {
                    errorList.Add("TotalCube  MissMatch: Expected  " + expectedFileLine.Substring(97, 9) + " Actual " + actualFileLine.Substring(97, 9) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(106, 7) != actualFileLine.Substring(106, 7))
                {
                    errorList.Add("TotalBoxes  MissMatch: Expected  " + expectedFileLine.Substring(106, 7) + " Actual " + actualFileLine.Substring(106, 7) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(113, 7) != actualFileLine.Substring(113, 7))
                {
                    errorList.Add("TotalSets  MissMatch: Expected  " + expectedFileLine.Substring(113, 7) + " Actual " + actualFileLine.Substring(113, 7) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(120, 30) != actualFileLine.Substring(120, 30))
                {
                    errorList.Add("Comments   MissMatch: Expected  " + expectedFileLine.Substring(120, 30) + " Actual " + actualFileLine.Substring(120, 30) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(150, 1) != actualFileLine.Substring(150, 1))
                {
                    errorList.Add("TrailerClass   MissMatch: Expected  " + expectedFileLine.Substring(150, 1) + " Actual " + actualFileLine.Substring(150, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(151, 1) != actualFileLine.Substring(151, 1))
                {
                    errorList.Add("PickSource   MissMatch: Expected  " + expectedFileLine.Substring(151, 1) + " Actual " + actualFileLine.Substring(151, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(152, 168) != actualFileLine.Substring(152, 168))
                {
                    errorList.Add("Filler   MissMatch: Expected  " + expectedFileLine.Substring(152, 168) + " Actual " + actualFileLine.Substring(152, 168) + Environment.NewLine);
                }

                //TODO
                if (errorList.Any())
                {
                    if (errorList.Any())
                    {
                        errorList.Insert(0, "Discripencies Observed in File Footer " + Environment.NewLine);
                    }
                    File.AppendAllText(ApplicationConstants.LOG_FILE, "Discripencies Observed in File Footer " + Environment.NewLine);
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
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool CompareDeliveryUnitHeader(string expectedFileLine, string actualFileLine, string du)
        {
            try
            {
                List<string> errorList = new List<string>();

                if (expectedFileLine.Substring(0, 1) != actualFileLine.Substring(0, 1))
                {
                    errorList.Add("File Type MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(0, 1) + " Actual " + actualFileLine.Substring(0, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(1, 4) != actualFileLine.Substring(1, 4))
                {
                    errorList.Add("Receiving Depot MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(1, 4) + " Actual " + actualFileLine.Substring(1, 4) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(5, 2) != actualFileLine.Substring(5, 2))
                {
                    errorList.Add("Type  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(5, 2) + " Actual " + actualFileLine.Substring(5, 2) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(7, 15) != actualFileLine.Substring(7, 15))
                {
                    errorList.Add("ASN MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(7, 15) + " Actual " + actualFileLine.Substring(7, 15) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(22, 20) != actualFileLine.Substring(22, 20))
                {
                    errorList.Add("Delivery Unit Number  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(22, 20) + " Actual " + actualFileLine.Substring(22, 20) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(42, 20) != actualFileLine.Substring(42, 20))
                {
                    errorList.Add("Parent Delivery Unit Number  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(42, 20) + " Actual " + actualFileLine.Substring(42, 20) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(62, 1) != actualFileLine.Substring(62, 1))
                {
                    errorList.Add("FLevel  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(62, 1) + " Actual " + actualFileLine.Substring(62, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(63, 6) != actualFileLine.Substring(63, 6))
                {
                    errorList.Add("ShipFrom/Initial Source  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(63, 6) + " Actual " + actualFileLine.Substring(63, 6) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(69, 1) != actualFileLine.Substring(69, 1))
                {
                    errorList.Add("ShipFrom/ Source Type  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(69, 1) + " Actual " + actualFileLine.Substring(69, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(70, 6) != actualFileLine.Substring(70, 6))
                {
                    errorList.Add("ShipTo/ Final Location  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(70, 6) + " Actual " + actualFileLine.Substring(70, 6) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(76, 1) != actualFileLine.Substring(76, 1))
                {
                    errorList.Add("FinalLocation Type  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(76, 76) + " Actual " + actualFileLine.Substring(76, 76) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(77, 6) != actualFileLine.Substring(77, 6))
                {
                    errorList.Add("Next Destination  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(77, 6) + " Actual " + actualFileLine.Substring(77, 6) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(83, 1) != actualFileLine.Substring(83, 1))
                {
                    errorList.Add("Next Destination Type  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(83, 1) + " Actual " + actualFileLine.Substring(83, 831) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(84, 7) != actualFileLine.Substring(84, 7))
                {
                    errorList.Add("CasesDue/Total Qty  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(84, 7) + " Actual " + actualFileLine.Substring(84, 7) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(91, 3) != actualFileLine.Substring(91, 3))
                {
                    errorList.Add("Tie  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(91, 3) + " Actual " + actualFileLine.Substring(91, 3) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(94, 3) != actualFileLine.Substring(94, 3))
                {
                    errorList.Add("Tier  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(94, 3) + " Actual " + actualFileLine.Substring(94, 3) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(97, 5) != actualFileLine.Substring(97, 5))
                {
                    errorList.Add("InchesHigh  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(97, 5) + " Actual " + actualFileLine.Substring(97, 5) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(102, 5) != actualFileLine.Substring(102, 5))
                {
                    errorList.Add("InchesWide  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(102, 5) + " Actual " + actualFileLine.Substring(102, 5) + Environment.NewLine);
                }

                if (expectedFileLine.Substring(107, 5) != actualFileLine.Substring(107, 5))
                {
                    errorList.Add("InchesLong  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(107, 5) + " Actual " + actualFileLine.Substring(107, 5) + Environment.NewLine);
                }

                if (expectedFileLine.Substring(112, 7) != actualFileLine.Substring(112, 7))
                {
                    errorList.Add("Wieght  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(112, 7) + " Actual " + actualFileLine.Substring(112, 7) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(119, 30) != actualFileLine.Substring(119, 30))
                {
                    errorList.Add("DuhComments  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(119, 30) + " Actual " + actualFileLine.Substring(119, 30) + Environment.NewLine);
                }

                if (expectedFileLine.Substring(149, 1) != actualFileLine.Substring(149, 1))
                {
                    errorList.Add("ContainerType  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(149, 1) + " Actual " + actualFileLine.Substring(149, 1) + Environment.NewLine);
                }

                if (expectedFileLine.Substring(150, 1) != actualFileLine.Substring(150, 1))
                {
                    errorList.Add("ReceiptType  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(150, 1) + " Actual " + actualFileLine.Substring(150, 1) + Environment.NewLine);
                }

                if (expectedFileLine.Substring(151, 1) != actualFileLine.Substring(151, 1))
                {
                    errorList.Add("FQCRequired  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(151, 1) + " Actual " + actualFileLine.Substring(151, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(152, 1) != actualFileLine.Substring(152, 1))
                {
                    errorList.Add("FQCSource  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(152, 1) + " Actual " + actualFileLine.Substring(152, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(153, 10) != actualFileLine.Substring(153, 10))
                {
                    errorList.Add("FQCFlags  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(153, 10) + " Actual " + actualFileLine.Substring(153, 10) + Environment.NewLine);
                }
                /*
                if (expectedFileLine.Substring(163, 157) != actualFileLine.Substring(163, 157))
                {
                    errorList.Add("Filler  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(163, 319) + " Actual " + actualFileLine.Substring(163, 319) + Environment.NewLine);
                }
                */
                if (errorList.Any())
                {
                    if (errorList.Any())
                    {
                        errorList.Insert(0, "Discripencies Observed in DU  Header DU Number: " + du + Environment.NewLine);
                    }
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

            catch (Exception ex)
            {
                File.AppendAllText(ApplicationConstants.LOG_FILE, $"{ex.Message}{ex.InnerException}");
                throw ex;
            }
        }
        public bool CompareLineItems(string expectedFileLine, string actualFileLine, string du)
        {
            try
            {
                List<string> errorList = new List<string>();
                if (expectedFileLine.Substring(0, 1) != actualFileLine.Substring(0, 1))
                {
                    errorList.Add("File Type MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(0, 1) + " Actual " + actualFileLine.Substring(0, 1) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(1, 4) != actualFileLine.Substring(1, 4))
                {
                    errorList.Add("Receiving Depot MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(1, 4) + " Actual " + actualFileLine.Substring(1, 4) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(5, 2) != actualFileLine.Substring(5, 2))
                {
                    errorList.Add("Receiving Depot MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(5, 2) + " Actual " + actualFileLine.Substring(5, 2) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(7, 15) != actualFileLine.Substring(7, 15))
                {
                    errorList.Add("ASN MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(7, 15) + " Actual " + actualFileLine.Substring(7, 15) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(22, 20) != actualFileLine.Substring(22, 20))
                {
                    errorList.Add("Delivery Unit Number  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(22, 20) + " Actual " + actualFileLine.Substring(22, 20) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(42, 8) != actualFileLine.Substring(42, 8))
                {
                    errorList.Add("Item Code/SKU  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(42, 8) + " Actual " + actualFileLine.Substring(42, 8) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(50, 65) != actualFileLine.Substring(50, 65))
                {
                    errorList.Add("Filler   MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(50, 65) + " Actual " + actualFileLine.Substring(50, 65) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(115, 7) != actualFileLine.Substring(115, 7))
                {
                    errorList.Add("Quantity  Ordered   MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(115, 7) + " Actual " + actualFileLine.Substring(115, 7) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(122, 7) != actualFileLine.Substring(122, 7))
                {
                    errorList.Add("Quantity Delivered   MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(122, 7) + " Actual " + actualFileLine.Substring(122, 7) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(129, 7) != actualFileLine.Substring(129, 7))
                {
                    errorList.Add("QtyAllocated   MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(129, 7) + " Actual " + actualFileLine.Substring(129, 7) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(136, 9) != actualFileLine.Substring(136, 9))
                {
                    errorList.Add("F Cost   MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(136, 9) + " Actual " + actualFileLine.Substring(136, 9) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(145, 9) != actualFileLine.Substring(145, 9))
                {
                    errorList.Add("F Retail Prc Expd  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(145, 9) + " Actual " + actualFileLine.Substring(145, 9) + Environment.NewLine);
                }
                if (expectedFileLine.Substring(154, 4) != actualFileLine.Substring(154, 4))
                {
                    errorList.Add("FCaseQtyExpd  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(154, 4) + " Actual " + actualFileLine.Substring(154, 4) + Environment.NewLine);
                }

                //TODO
                /*
                if (expectedFileLine.Substring(158, 321) != actualFileLine.Substring(158, 321))
                {
                    errorList.Add("Filler  MissMatch: DU " + du + " Expected  " + expectedFileLine.Substring(158, 321) + " Actual " + actualFileLine.Substring(158, 321) + Environment.NewLine);
                }
                */

                if (errorList.Any())
                {
                    File.AppendAllText(ApplicationConstants.LOG_FILE, "Discripencies Found in Line For  DU Number- " + du + Environment.NewLine);
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
            catch (Exception ex)
            {
                File.AppendAllText(ApplicationConstants.LOG_FILE, $"{ex.Message}{ex.InnerException}");
                throw ex;
            }
        }

    }
}
