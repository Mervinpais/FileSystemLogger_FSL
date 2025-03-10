using System;
using System.IO;
using System.Text;

namespace FileSystemLogger_FSL
{
    class Program
    {
        static void Main(string[] args)
        {
            string targetDirectory = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
            
            if (!Directory.Exists(targetDirectory))
            {
                Console.WriteLine($"Error: Directory '{targetDirectory}' does not exist.");
                return;
            }
            
            string timestamp = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
            string logFileName = $"FSL_log_{timestamp}.txt";
            string logFilePath = Path.Combine(targetDirectory, logFileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, false, Encoding.UTF8))
                {
                    writer.WriteLine($"File System Log for: {targetDirectory}");
                    writer.WriteLine($"Generated on: {DateTime.Now}");
                    writer.WriteLine(new string('-', 50));
                    LogDirectory(writer, targetDirectory, "");
                }

                Console.WriteLine($"Log file created: {logFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing log file: {ex.Message}");
            }
        }

        static void LogDirectory(StreamWriter writer, string directory, string indent)
        {
            try
            {
                writer.WriteLine($"{indent}[DIR] {Path.GetFileName(directory)}");
                indent += "    ";

                foreach (string subDir in Directory.GetDirectories(directory))
                {
                    LogDirectory(writer, subDir, indent);
                }

                foreach (string file in Directory.GetFiles(directory))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    writer.WriteLine($"{indent}- {fileInfo.Name} | Size: {fileInfo.Length} bytes | Created: {fileInfo.CreationTime} | Modified: {fileInfo.LastWriteTime}");
                }
            }
            catch (Exception ex)
            {
                writer.WriteLine($"{indent}Error accessing directory: {ex.Message}");
            }
        }
    }
}
