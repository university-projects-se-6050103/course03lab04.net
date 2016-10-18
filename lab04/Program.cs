using System;
using System.IO;

namespace lab04
{
    class Program
    {
        static void Main()
        {
            var filePath = FileUtil.GetFilePath();
            FileUtil.PrintDirectoryName(filePath);
            FileUtil.PrintFileExtension(filePath);
            FileUtil.PrintFileNameWithoutExtension(filePath);

            var filePathSecret = FileUtil.RenameExtension(filePath, "secret");
            var encryptionChoice = CLIUtils.GetEncryptionChoice();
            var fileSizeOriginal = FileUtil.GetFileSizeBytes(filePath);
            long fileSizeTransformed;
            var startTime = DateTime.Now;
            DateTime endTime;

            if (encryptionChoice == 1)
            {
                // TODO Encrypt file extension
                var encyptedFile = Encryption.Encrypt(File.ReadAllBytes(filePath));
                fileSizeTransformed = encyptedFile.Length;
                File.WriteAllBytes(filePathSecret, encyptedFile);
                endTime = DateTime.Now;
            }
            else if (encryptionChoice == 2)
            {
                // TODO Encrypt file extension
                var encyptedFile = Encryption.Encrypt(File.ReadAllLines(filePath));
                fileSizeTransformed = encyptedFile.Length;
                File.WriteAllText(filePathSecret, encyptedFile);
                endTime = DateTime.Now;
            }
            else if (encryptionChoice == 3)
            {
                // TODO Decrypt file extension
                var decryptedFile = Encryption.Decrypt(File.ReadAllBytes(filePathSecret));
                fileSizeTransformed = decryptedFile.Length;
                File.WriteAllBytes(filePathSecret, decryptedFile);
                endTime = DateTime.Now;
            }
            else
            {
                // TODO Decrypt file extension
                var decryptedFile = Encryption.Decrypt(File.ReadAllLines(filePathSecret));
                fileSizeTransformed = decryptedFile.Length;
                File.WriteAllText(filePathSecret, decryptedFile);
                endTime = DateTime.Now;
            }

            Console.WriteLine(
                $"Розмір файлу: до - {FileUtil.HumanizeBytesSize(fileSizeOriginal)} після - {FileUtil.HumanizeBytesSize(fileSizeTransformed)}");
            Console.WriteLine($"К-ть байтів до: - {fileSizeOriginal} після - {fileSizeTransformed}");
            Console.WriteLine($"Час на шифрування: {endTime - startTime}");

            CLIUtils.PreservePromptClose();
        }
    }
}