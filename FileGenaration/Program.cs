using System;
using System.IO;
using Colors.Net;
using Colors.Net.StringColorExtensions;
class Program
{
    static void Main(string[] args)
    {
        ColoredConsole.WriteLine($"{"File Generation\n".Magenta()}");
        string folderPath, fileName, confirm;
        int numFiles;
        DateTime creationDate;
        do
        {
            ColoredConsole.Write($"{"Enter the file location example \"C:\\Users\\saharat.mee\\Downloads\\Test\":".Yellow()} ");
            folderPath = Console.ReadLine();
            ColoredConsole.Write($"{"Enter the file name: ".Yellow()}");
            fileName = Console.ReadLine();
            while (true)
            {
                ColoredConsole.Write($"{"Enter the number of files to create: ".Yellow()}");
                if (int.TryParse(Console.ReadLine(), out numFiles))
                {
                    break;
                }
                ColoredConsole.WriteLine($"{"Please enter a valid integer.".Red()}");
            }
            ColoredConsole.Write($"{"Enter the creation date".Yellow()} {"(DD/MM/YYYY".Blue()} {"or".Yellow()} {"DD MM YYYY): ".Blue()}");
            string dateInput = Console.ReadLine().Replace("/", " ").Replace(" ", "");
            creationDate = DateTime.ParseExact(dateInput, "ddMMyyyy", null);

            ColoredConsole.Write($"{"Are you sure you want to create".Yellow()} {numFiles} {"files with name".Yellow()} {fileName} {"at location".Yellow()} {folderPath} {"with creation date".Yellow()} {creationDate:d}{"?".Yellow()} {"(y/n)".Red()}: ");
            confirm = Console.ReadLine();

            if (confirm.ToLower() == "y")
            {
                for (int i = 1; i <= numFiles; i++)
                {
                    string filePath = Path.Combine(folderPath, $"{fileName}{i}.txt");
                    File.Create(filePath).Dispose();
                    File.SetCreationTime(filePath, creationDate);
                }

                ColoredConsole.WriteLine($"{"Created".Yellow()} {numFiles} {"files with name".Yellow()} {fileName} {"at location".Yellow()} {folderPath} {"with creation date".Yellow()} {creationDate:d}.\n");
            }
            else if (confirm.ToLower() == "n")
            {
                ColoredConsole.WriteLine($"{"Please enter the details again.".Red()}.\n");
            }
            else
            {
                ColoredConsole.WriteLine($"{"Please enter only y or n.".Red()}\n");
            }
        } while (confirm.ToLower() != "y");
    }
}
