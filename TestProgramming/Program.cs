using System;
using System.IO;
using System.Reflection;
using Colors.Net;
using Colors.Net.StringColorExtensions;

namespace FileDeleteProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            //string folderPath = @"C:\Users\saharat.mee\Downloads\fileTest";
            ColoredConsole.WriteLine($"{"Please enter the path to the file you want to".Yellow()} {"delete".Red()}.");
            ColoredConsole.WriteLine($"{"Example:".Yellow()} C:\\Users\\saharat.mee\\Downloads");
            string folderPath = Console.ReadLine();
            string[] filePaths = Directory.GetFiles(folderPath);

            ColoredConsole.WriteLine($"{ "Files older than 40 days:".Yellow()}");
            Console.WriteLine("{0,-5} {1,-35} {2,-27} {3,-15} {4,-14} {5,-14} {6,-15}", "No.", "File Name", "Creation Time", "Years", "Months", "Days", "Total Days");
            int count = 1;
            foreach (string filePath in filePaths)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                TimeSpan diff = DateTime.Now - fileInfo.CreationTime;
                int years = diff.Days / 365;
                int months = (diff.Days % 365) / 30;
                int days = diff.Days % 30;
                double totalDays = diff.Days;
                if (diff.TotalDays >= 40)
                {
                    Console.WriteLine("{0,-5} {1,-35} {2,-28} {3,-15} {4,-14} {5,-15} {6,-15}", count, fileInfo.Name, fileInfo.CreationTime, years, months, days, totalDays);
                    count++;
                }
            }
            ColoredConsole.WriteLine($"{"Do you want to delete all files?".Red()} {"(y/n)".Yellow()}");
            string confirm = Console.ReadLine();
            if (confirm == "y")
            {
                ColoredConsole.WriteLine($"{"Are you sure? you want to delete all files?".Red()} {"(y/n)".Yellow()}");
                ColoredConsole.WriteLine($"{"There are".Yellow()} {count - 1} {"files that you will".Yellow()} {"delete".Yellow()}.");
                string response = Console.ReadLine();
                if (response == "y")
                {
                    foreach (string filePath in filePaths)
                    {
                        FileInfo fileInfo = new FileInfo(filePath);
                        TimeSpan diff = DateTime.Now - fileInfo.CreationTime;
                        if (diff.TotalDays >= 40)
                        {
                            fileInfo.Delete();
                            ColoredConsole.WriteLine($"{"File deleted successfully".Green()}: " + filePath.Yellow());
                        }
                    }
                    ColoredConsole.WriteLine($"{"All eligible files have been deleted.".Green()}");
                }
                else if (response == "n")
                {
                    ColoredConsole.WriteLine($"{"Enter the number of the file you want to delete or type".Blue()} {"'exit'".Red()} {"to".Blue()} {"quit".Red()}:");
                    response = Console.ReadLine();
                    while (response != "exit")
                    {
                        int fileNumber;
                        if (Int32.TryParse(response, out fileNumber) && fileNumber > 0 && fileNumber <= count - 1)
                        {
                            string filePath = filePaths[fileNumber - 1];
                            FileInfo fileInfo = new FileInfo(filePath);
                            fileInfo.Delete();
                            ColoredConsole.WriteLine($"{"File deleted successfully".Green()}: " + filePath.Yellow());
                        }
                        else
                        {
                            ColoredConsole.WriteLine($"{"Invalid input.".Red()} {"Please enter a valid file number or type".Yellow()} {"'exit'".Red()} {"to".Yellow()} {"quit".Red()}.");
                        }
                        response = Console.ReadLine();
                    }
                }
            }            
            else
            {
                while (confirm != "y" && confirm != "n")
                {
                    ColoredConsole.WriteLine($"{"Invalid input.".Red()} {"Please type".Yellow()} {"'y'".Magenta()} {"or".Yellow()} {"'n'".Magenta()}.");
                    confirm = Console.ReadLine();
                }

                if (confirm == "y")
                {
                    foreach (string filePath in filePaths)
                    {
                        FileInfo fileInfo = new FileInfo(filePath);

                        TimeSpan diff = DateTime.Now - fileInfo.CreationTime;
                        if (diff.TotalDays >= 40)
                        {
                            fileInfo.Delete();
                            ColoredConsole.WriteLine($"{"File deleted successfully".Green()}: " + filePath.Yellow());
                        }
                    }
                    ColoredConsole.WriteLine($"{"All eligible files have been deleted.".Green()}");
                }
                else if (confirm == "n")
                {
                    ColoredConsole.WriteLine($"{"Enter the".Yellow()} {"number".Blue()} {"of the file".Yellow()} {"you want to delete".Blue()} {"or type".Yellow()} {"'exit'".Red()} {"to".Yellow()} {"quit".Red()}:");
                    confirm = Console.ReadLine();
                    while (confirm != "exit")
                    {
                        int fileNumber;
                        if (Int32.TryParse(confirm, out fileNumber) && fileNumber > 0 && fileNumber <= count - 1)
                        {
                            string filePath = filePaths[fileNumber - 1];
                            FileInfo fileInfo = new FileInfo(filePath);
                            fileInfo.Delete();
                            ColoredConsole.WriteLine($"{"File deleted successfully".Green()}: " + filePath.Yellow());
                        }
                        else
                        {
                            ColoredConsole.WriteLine($"{"Invalid input.".Red()} {"Please enter a valid file number or type".Yellow()} {"'exit'".Red()} {"to".Yellow()} {"quit".Red()}.");
                        }
                        confirm = Console.ReadLine();
                    }
                }
            }


            ColoredConsole.WriteLine($"{"Program has finishedexecuting.".Green()}{"Press any key to ".Yellow()}{"exit.".Red()}");
            Console.ReadKey();
        }
    }
}

