using System;
using System.IO;
using System.Linq;

namespace Delivery.DESADVAdaptorsParallelRun.IntgTest.constants
{
    public static class ApplicationConstants
    {
        public  const string EXPECTED_FILES_CONTAINER = "adaptor-prod";
        public const string Actual_FILES_CONTAINER = "adaptor-prod";
        public const string AZURE_CONNECTION_STRING = "";
        public const  string Actual_FILES_PATH = $"";
        public const  string EXPECTED_FILES_PATH = "";

        public const string BASE_PATH = GetTestFilePath("testdata", "");
        public const string LOCAL_EXPECTED_FILE_PATH = Path.Combine(BASE_PATH, @"expectedoutput/");
        public const string LOCAL_COMPRESSED_EXPECTED_FILE_PATH = Path.Combine(BASE_PATH, @"compressed/");
        public const string LOCAL_UNCOMPRESSED_EXPECTED_FILE_PATH = Path.Combine(BASE_PATH, @"uncompressed/");
        public const string LOCAL_ACTUAL_FILE_PATH = Path.Combine(BASE_PATH, @"actualoutput/");       
        public const readonly string LOG_FILE = Path.Combine(BASE_PATH, $"logs/DesAdvFromLPToLegacyLog_{DateTime.UtcNow.ToString("ddMMyyyyHh")}.txt");
        public const readonly string LOG_FOLDER = Path.Combine(BASE_PATH, "logs/");

        public static string GetTestFilePath(string folderName, string fileName)
        {
            try
            {
                string startupPath = AppDomain.CurrentDomain.BaseDirectory;
                var pathItems = startupPath.Split(Path.DirectorySeparatorChar);
                var pos = pathItems.Reverse().ToList().FindIndex(x => string.Equals("bin", x));
                string projectPath = String.Join(Path.DirectorySeparatorChar.ToString(), pathItems.Take(pathItems.Length - pos - 1));
                string filepath = Path.Combine(projectPath, folderName, fileName);
                Console.WriteLine("Filepath -" + filepath);
                return filepath;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured in getting file path -" + ex.Message);
                throw;
            }
        }

    }
}
