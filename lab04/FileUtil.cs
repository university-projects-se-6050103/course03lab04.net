using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace lab04
{
    public class FileUtil
    {
        public static string GetFilePath()
        {
            Console.WriteLine("Please enter path to file");
            var input = Console.ReadLine();

            if (File.Exists(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Requested file doesn't exist. Please try again");
                return GetFilePath();
            }
        }

        public static void PrintDirectoryName(string path)
        {
            Console.WriteLine("Directory name: " + Path.GetDirectoryName(path));
        }

        public static void PrintFileExtension(string path)
        {
            Console.WriteLine("File extension: " + Path.GetExtension(path));
        }

        public static void PrintFileNameWithoutExtension(string path)
        {
            Console.WriteLine("Filename w/o extension: " + Path.GetFileNameWithoutExtension(path));
        }

        public static long GetFileSizeBytes(string path)
        {
            return new FileInfo(path).Length;
        }

        public static string RenameExtension(string path, string newExtension)
        {
            return Regex.Replace(path, "([^\\.]+)$", newExtension);
        }

        public static void SaveLogs(string logs)
        {
            var streamWriter = new StreamWriter(File.Open("./logs.txt", FileMode.Create), Encoding.UTF8);
            Console.Write(Environment.NewLine + logs);
            Console.SetOut(streamWriter);
            Console.Write(logs);
        }

        public static string HumanizeBytesSize(long fileSize)
        {
            if (fileSize >= 1024 * 1024)
            {
                return Math.Floor((double) (fileSize / (1024 * 1024))) + " Mb";
            }

            if (fileSize >= 1024)
            {
                return Math.Floor((double) (fileSize / 1024)) + " Kb";
            }

            return fileSize + " b";
        }
    }
}