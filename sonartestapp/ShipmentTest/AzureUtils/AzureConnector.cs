using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Delivery.DESADVAdaptorsParallelRun.IntgTest.constants;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace Delivery.DESADVAdaptorsParallelRun.IntgTest.AzureUtils
{
    public class AzureConnector: IAzureConnector
    {
        //List<string> includeDepots = new List<string>() { "003", "021", "011", "009", "026", "039", "075", "008", "016", "006", "037", "038", "070", "012" };
        //List<string> includeDepots = new List<string>() { "016"};
        public void DeleteFileInAzureBlob(string containerName, string blobPath, string fileName)
        {
            try
            {
                BlobContainerClient container = new BlobContainerClient(ApplicationConstants.AZURE_CONNECTION_STRING, containerName + "/" + blobPath);
                BlobClient blobClient = container.GetBlobClient(fileName);
                blobClient.DeleteIfExists();

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

        public void DownloadFileFromAzureBlob(string containerName, string blobPath, string fileName, string localActualFilePath)
        {
            string responseBody = "";
            try
            {
                BlobContainerClient container = new BlobContainerClient(ApplicationConstants.AZURE_CONNECTION_STRING, containerName + "/" + blobPath);

                BlobClient blobClient = container.GetBlobClient(fileName);
                BlobDownloadInfo res = blobClient.Download();
                Stream responseStream = res.Content;
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    responseBody = reader.ReadToEnd();
                }
                responseBody.Replace(@"\n", Environment.NewLine);
                File.WriteAllText(localActualFilePath + "/" + fileName, responseBody);
                Console.WriteLine("Received file from Azure Container ");
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

        //To be completed Venkat
        public void DownloadAllFilesFromAzureBlob(string containerName, string blobPath, string localActualFilePath)
        {
            string responseBody = string.Empty;
            BlobContainerClient container = new BlobContainerClient(ApplicationConstants.AZURE_CONNECTION_STRING, containerName);
            int count = 0;
            try
            {
                foreach (BlobItem blob in container.GetBlobs(prefix: blobPath))
                {
                    count++;
                    string[] strKeys = blob.Name.Split("/");
                    var lastIndex = strKeys.Length - 1;
                    BlobClient blobClient = container.GetBlobClient(blob.Name);
                    BlobDownloadInfo res = blobClient.Download();
                    Stream responseStream = res.Content;
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                    File.WriteAllText(localActualFilePath + strKeys[lastIndex], responseBody);
                    Console.WriteLine($"{DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture)} - Downloaded File {count.ToString()}:{strKeys[lastIndex]}");
                }
                Console.WriteLine($"{DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture)} - Total {count.ToString()} files are downloadded");
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

        public void DownloadParallelrunFilesFromAzureBlob(string containerName, string blobPath, string localActualFilePath, List<string> includeDepots)
        {
            string responseBody = string.Empty;
            foreach (string depot in includeDepots)
            {
                string newPrefix = blobPath.Replace("***", depot);
                BlobContainerClient container = new BlobContainerClient(ApplicationConstants.AZURE_CONNECTION_STRING, containerName);
                int count = 0;
                try
                {
                    foreach (BlobItem blob in container.GetBlobs(prefix: newPrefix))
                    {
                        count++;
                        string[] strKeys = blob.Name.Split("/");
                        var lastIndex = strKeys.Length - 1;
                        BlobClient blobClient = container.GetBlobClient(blob.Name);
                        BlobDownloadInfo res = blobClient.Download();
                        Stream responseStream = res.Content;
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            responseBody = reader.ReadToEnd();
                        }
                        File.WriteAllText(localActualFilePath + strKeys[lastIndex], responseBody);
                        Console.WriteLine($"{DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture)} - Downloaded File {count.ToString()}:{strKeys[lastIndex]}");
                    }
                    Console.WriteLine($"{DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture)} - Total {count.ToString()} files are downloadded");
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
        public void DownloadAllFilesFromAzureBlobProd(string containerName, string blobPath, string localActualFilePath, List<string> includeDepots)
        {
            string responseBody = string.Empty;
            foreach (string depot in includeDepots)
            {
                string newPrefix = blobPath.Replace("***", depot);

                BlobContainerClient container = new BlobContainerClient(ApplicationConstants.AZURE_CONNECTION_STRING, containerName);
                int count = 0;
                try
                {
                    foreach (BlobItem blob in container.GetBlobs(prefix: newPrefix))
                    {
                        //if (blob.Properties.CreatedOn >= DateTime.Now.AddHours(-30) && blob.Properties.CreatedOn <= DateTime.Now.AddMinutes(-30))
                        //{
                        count++;
                        string[] strKeys = blob.Name.Split("/");
                        var lastIndex = strKeys.Length - 1;
                        BlobClient blobClient = container.GetBlobClient(blob.Name);
                        BlobDownloadInfo res = blobClient.Download();
                        Stream responseStream = res.Content;
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            responseBody = reader.ReadToEnd();
                        }
                        File.WriteAllText(localActualFilePath + strKeys[lastIndex], responseBody);
                        Console.WriteLine($"{DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture)} - Downloaded File {count.ToString()}:{strKeys[lastIndex]}");
                        //}
                    }
                    Console.WriteLine($"{DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture)} - Total {count.ToString()} files are downloadded");
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

        public bool CheckFileExistInAzureBlob(string containerName, string blobPath, int waitInTimeSecs)
        {
            try
            {
                BlobContainerClient container = new BlobContainerClient(ApplicationConstants.AZURE_CONNECTION_STRING, containerName);
                bool isFileExists = false;
                var watch = Stopwatch.StartNew();
                int elapsedSeconds = 0;
                Console.WriteLine("Checking for blobs...");
                while (!isFileExists && elapsedSeconds <= waitInTimeSecs)
                {
                    var blobList = container.GetBlobs(prefix: blobPath);

                    // Print out all the blob names
                    foreach (BlobItem blob in container.GetBlobs(prefix: blobPath))
                    {
                        isFileExists = true;
                        Console.WriteLine("Blob exists with name-" + blob.Name);
                        //container.DeleteBlob(blob.Name);
                    }
                    elapsedSeconds = Convert.ToInt16(watch.Elapsed.TotalSeconds);
                }
                return isFileExists;
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

        public void DeleteAllFilesFromAzureBlob(string containerName, string blobPath)//BlobPath should be the full location of file for ex:IDT/IDTFromRPToPLT/Input/
        {
            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(ApplicationConstants.AZURE_CONNECTION_STRING, containerName);
            container.CreateIfNotExists();
            // Upload a few blobs so we have something to list
            try
            {
                // Print out all the blob names
                foreach (BlobItem blob in container.GetBlobs(prefix: blobPath))
                {
                    Console.WriteLine("Deleting Blob-" + blob.Name);
                    container.DeleteBlob(blob.Name);
                }

                Console.WriteLine("Deleted All Files");

            }
            catch (Exception e)
            {
                Console.WriteLine(
                    "Unknown encountered on server. Message:'{0}' when deleting an object", e.Message);
                Console.WriteLine(
                    "Unknown encountered on server. Message:'{0}' when deleting an object", e.StackTrace);
                throw e;
            }
        }

        public void UploadFileToAzureBlob(string containerName, string blobPath, string fileName, string filepath)
        {
            try
            {
                // Get a reference to a container named "sample-container" and then create it
                BlobContainerClient container = new BlobContainerClient(ApplicationConstants.AZURE_CONNECTION_STRING, containerName);
                container.CreateIfNotExists();


                using (FileStream fs = File.OpenRead(filepath))
                {
                    container.UploadBlob(blobPath + fileName, fs);
                }

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
