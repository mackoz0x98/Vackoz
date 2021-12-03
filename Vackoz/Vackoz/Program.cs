// VACKOZ? Valorant Log Cleaner by Mackoz#5905


using System;
using System.IO;
using System.Threading;

namespace Vackoz
{
    internal class Program
    {
        public static string Local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static int DeletedFilesCount = 0;

        private static void Main(string[] args)
        {
            Console.Title = "VACKOZ";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Environment.NewLine + "  [VACKOZ - LOG TEMIZLEYICI (coded by Mackozitrone(Mackoz#5905)]");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Program.DeleteFilesAndFoldersRecursively(Program.Local + "\\Riot Games");
            Console.WriteLine("  Riot Games, silindi!");
            Program.DeleteFilesAndFoldersRecursively(Program.Local + "\\VALORANT");
            Console.WriteLine("  Valorant Logs, silindi!");
            Program.DeleteAllFilesOnDirectory("C:\\Program Files\\Riot Vanguard\\Logs");
            Program.DeleteAllFilesOnDirectory("C:\\ProgramData\\Riot Games\\Metadata\\valorant.live");
            if ((uint)Program.DeletedFilesCount > 0U)
                Console.WriteLine(Environment.NewLine + "  " + Program.DeletedFilesCount.ToString() + ", LOGs Silindi!");
            else
                Console.WriteLine("  " + Program.DeletedFilesCount.ToString() + ", Dosyalar silindi!");
            Thread.Sleep(5000);
            Environment.Exit(0);
        }

        public static void DeleteFilesAndFoldersRecursively(string target_dir)
        {
            try
            {
                foreach (string file in Directory.GetFiles(target_dir))
                    File.Delete(file);
                foreach (string directory in Directory.GetDirectories(target_dir))
                    Program.DeleteFilesAndFoldersRecursively(directory);
                Thread.Sleep(1);
                Directory.Delete(target_dir);
            }
            catch
            {
            }
        }

        public static void DeleteAllFilesOnDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                    return;
                foreach (FileInfo file in new DirectoryInfo(path).GetFiles())
                {
                    ++Program.DeletedFilesCount;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("  " + file.Name + " | silindi");
                    file.Delete();
                }
            }
            catch
            {
            }
        }
    }
}
