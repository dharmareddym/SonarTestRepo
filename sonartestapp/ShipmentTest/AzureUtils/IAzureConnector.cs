using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.DESADVAdaptorsParallelRun.IntgTest.AzureUtils
{
    public interface IAzureConnector
    {
        void DeleteFileInAzureBlob(string containerName, string blobPath, string fileName);
        void DownloadFileFromAzureBlob(string containerName, string blobPath, string fileName, string localActualFilePath);
        void DownloadAllFilesFromAzureBlob(string containerName, string blobPath, string localActualFilePath);
        void DownloadParallelrunFilesFromAzureBlob(string containerName, string blobPath, string localActualFilePath, List<string> includeDepots);
        void DownloadAllFilesFromAzureBlobProd(string containerName, string blobPath, string localActualFilePath, List<string> includeDepots);
        bool CheckFileExistInAzureBlob(string containerName, string blobPath, int waitInTimeSecs);
        void DeleteAllFilesFromAzureBlob(string containerName, string blobPath);
        void UploadFileToAzureBlob(string containerName, string blobPath, string fileName, string filepath);
    }
}
