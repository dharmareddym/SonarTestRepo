using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Ebixio.LZW;
using SonarTest.IntgTest.AzureUtils;
using SonarTest.IntgTest.constants;
using System.Globalization;

namespace Delivery.DESADVAdaptorsParallelRun.IntgTest.AzureUtils
{
    public class FileDownloader : IFileDownloader
    {

        DateTimeOffset dateStart = DateTimeOffset.Now.Date.AddDays(-2);
        DateTimeOffset dateEnd = DateTimeOffset.Now.Date.AddDays(-1);

        public FileDownloader()
        {
        }
        public void DownloadFiles(string depotId = null)
        {
            DownloadFilesFromAzureBlob(ApplicationConstants.Actual_FILES_CONTAINER, ApplicationConstants.Actual_FILES_PATH, "actual", string.Empty);
            DownloadFilesFromAzureBlob(ApplicationConstants.EXPECTED_FILES_CONTAINER, ApplicationConstants.EXPECTED_FILES_PATH, "expected", string.Empty);
        }

        public void ExtractExpectedFiles()
        {

            try
            {

                List<string> compressedFilelist = Directory.GetFiles(ApplicationConstants.LOCAL_COMPRESSED_EXPECTED_FILE_PATH).ToList();

                foreach (var comptressedFilePath in compressedFilelist)
                {

                    string expectedFilePath = ApplicationConstants.LOCAL_UNCOMPRESSED_EXPECTED_FILE_PATH + "\\" + Path.GetFileName(comptressedFilePath).Split(".")[0];

                    using (Stream inStream = new LzwInputStream(File.OpenRead(ApplicationConstants.LOCAL_COMPRESSED_EXPECTED_FILE_PATH + "/" + Path.GetFileName(comptressedFilePath))))
                    using (FileStream outStream = File.Create(expectedFilePath))
                    {
                        int read;
                        byte[] data = new byte[4096];
                        while ((read = inStream.Read(data, 0, data.Length)) > 0)
                        {
                            outStream.Write(data, 0, read);
                        }
                    }
                    string[] lines = File.ReadAllLines(expectedFilePath);
                    var receivingDepot = lines[0].Substring(2, 3);// Receiving Depot
                    var fileName = $"{receivingDepot}_{lines[0].Substring(13, 9)}";
                    string folder = ApplicationConstants.LOCAL_EXPECTED_FILE_PATH;
                    string localPath = folder + "\\" + fileName;

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    File.AppendAllText(localPath, File.ReadAllText(expectedFilePath));

                    //File.Delete(expectedFilePath);
                    //File.Delete(comptressedFilePath);
                }
            }
            catch (Exception exp)
            {

            }
        }
        private void DownloadFilesFromAzureBlob(string containerName, string blobPath, string localMachinePath, string depotPrefix = null)
        {
            string continuationToken = null;
            string responseBody = string.Empty;
            BlobContainerClient container = new BlobContainerClient(ApplicationConstants.AZURE_CONNECTION_STRING, containerName);
            int count = 0;
            try
            {
                do
                {
                    var resultSegment = container.GetBlobs(prefix: blobPath)
                        .AsPages(continuationToken, 2000);

                    foreach (Azure.Page<BlobItem> blobPage in resultSegment)
                    {
                        foreach (BlobItem blob in blobPage.Values)
                        {
                            bool flag = false;
                            if (localMachinePath == "actual")
                            {
                                flag = blob.Properties.CreatedOn >= dateStart.UtcDateTime && blob.Properties.CreatedOn <= dateEnd.UtcDateTime;
                            }
                            else
                            {
                                flag = true;
                            }
                            // if (blob.Properties.CreatedOn >= dateStart.UtcDateTime && blob.Properties.CreatedOn <= dateEnd.UtcDateTime)
                            if (true)
                            {
                                string[] strKeys = null;
                                int lastIndex;

                                if (localMachinePath == "actual")
                                {
                                    count++;
                                    strKeys = blob.Name.Split("/");
                                    lastIndex = strKeys.Length - 1;
                                    BlobClient blobClient = container.GetBlobClient(blob.Name);
                                    BlobDownloadInfo res = blobClient.Download();
                                    Stream responseStream = res.Content;
                                    using (StreamReader reader = new StreamReader(responseStream))
                                    {
                                        responseBody = reader.ReadToEnd();
                                    }
                                }

                                string[] lines = responseBody.Split('\n');
                                var receivingDepot = lines[0].Substring(2, 3);// Receiving Depot
                                var fileName = $"{receivingDepot}_{lines[0].Substring(13, 9)}";
                                string folder = ApplicationConstants.LOCAL_ACTUAL_FILE_PATH;
                                string localPath = folder + "\\" + fileName;

                                if (!Directory.Exists(folder))
                                {
                                    Directory.CreateDirectory(folder);
                                }
                                File.AppendAllText(localPath, responseBody);
                                //Console.WriteLine($"{DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture)} - Downloaded File {count.ToString()}:{strKeys[lastIndex]}, Renamed File: {fileName}");

                            }
                        }
                        // Get the continuation token and loop until it is empty.
                        continuationToken = blobPage.ContinuationToken;

                    }

                } while (continuationToken != "");
                Console.WriteLine($"{DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture)} - Total {count.ToString()} files are downloadded");
                File.AppendAllText(ApplicationConstants.LOG_FILE, $"Total Number of files archived for given date range : " + count.ToString() + "\n");
                File.AppendAllText(ApplicationConstants.LOG_FOLDER, new string('-', 120) + "\n");
            }

            catch (Exception e)
            {
                Console.WriteLine(
                    "Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
                Console.WriteLine(
                    "Unknown encountered on server. Message:'{0}' when writing an object", e.StackTrace);
                throw e;
            }
        }
    }


}
