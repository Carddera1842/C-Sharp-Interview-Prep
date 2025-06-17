using System.Net.Http.Headers;
using System.Security;
using static System.Console;

namespace DataProcesser;

internal class FileProcesser
{
    private const string BackupDirectoryName = "backup";
    private const string InProgressDirectoryName = "processing";
    private const string CompletedDirectoryName = "complete";

    public string InputFilePath { get; }

    public FileProcesser(string filepath) => InputFilePath = filepath;

    public void Process()
    {
        WriteLine($"Begin process of {InputFilePath}");

        //Check if file exists

        if (!File.Exists(InputFilePath))
        {
            WriteLine($"ERROR: filr {InputFilePath} does not exist.");
            return;
        }

        string? rootDirectoryPath
            = new DirectoryInfo(InputFilePath).Parent?.Parent?.FullName;
        if (rootDirectoryPath == null)
        {
            throw new InvalidOperationException
                ($"Cannot determine root directory path");
        }


        WriteLine($"Root data path is {rootDirectoryPath}");

        //Check if backup directory exists
        string backupDirectoryPath
            = Path.Combine(rootDirectoryPath, BackupDirectoryName);

        if (!Directory.Exists(backupDirectoryPath))
        {
            WriteLine($"Creating {backupDirectoryPath}");
            Directory.CreateDirectory(backupDirectoryPath);
        }

        //Copy file to backup directory
        string inputFileName = Path.GetFileName(InputFilePath);
        string backupFilePath
            = Path.Combine(backupDirectoryPath, inputFileName);
        WriteLine($"Copying {inputFileName} to {backupFilePath}");
        File.Copy(InputFilePath, backupFilePath, true);

        //Move to in progress directory
        Directory.CreateDirectory
            (Path.Combine(rootDirectoryPath, InProgressDirectoryName));
        string inProgressFilePath
            = Path.Combine(rootDirectoryPath, InProgressDirectoryName, inputFileName);

        if (File.Exists(inProgressFilePath))
        {
            WriteLine($"ERROR: a file with the name {inProgressFilePath} is already exists");
            return;
        }

        WriteLine($"Moving {InputFilePath} to {inProgressFilePath}");
        File.Move(InputFilePath, inProgressFilePath);

        //Determine type of file
        string extention = Path.GetExtension(InputFilePath);

        string completedDirectoryPath
           = Path.Combine(rootDirectoryPath, CompletedDirectoryName);
        Directory.CreateDirectory(completedDirectoryPath);

        string fileNameWithCompletedExtention
            = Path.ChangeExtension(inputFileName, ".complete");
        string completedFileName
            = $"{Guid.NewGuid()}_{fileNameWithCompletedExtention}";

        string completedFilePath
            = Path.Combine(completedDirectoryPath, completedFileName);

        switch (extention)
        {
            case ".txt":
                var textProcessor
                    = new TextFileProcessor(inProgressFilePath, completedFilePath);
                textProcessor.Process();
                break;

            case ".data":
                var binaryProcessor = new BinaryFileProcessor(inProgressFilePath, completedFilePath);
                binaryProcessor.Process(); 
                break;

            case ".csv":
                var csvProcessor = new CsvFileProcessor(inProgressFilePath, completedFilePath);
                csvProcessor.Process();
                break;

            default:
                WriteLine($"{extention} is an unsupported file type.");
                break;
                
        }

        WriteLine($"Completed processing of {inProgressFilePath}");

        WriteLine($"Deleting {inProgressFilePath}");
        File.Delete(inProgressFilePath);
        
    }

   
}
