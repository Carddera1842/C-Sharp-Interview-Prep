using Xunit;
using System.IO.Abstractions.TestingHelpers;
using DataProcesser;
using System.Text;

namespace DataProcessor.Tests;

public class CsvFileProcessorShould
{
    [Fact]
    public void OutputProcessedOrderCsvData()
    {
        const string inputDir = @"c:\root\in";
        const string inputFileName = "myFile.csv";
        var inputFilePath = Path.Combine(inputDir, inputFileName);

        const string outputDir = @"c:\root\out";
        const string outputFileName = "myFile.csv";
        var outputFilePath = Path.Combine(outputDir, outputFileName);

        var csvLines = new StringBuilder();
        csvLines.AppendLine("OrderNumer, CustomerNumber, Description, Quantity");
        csvLines.AppendLine("42, 100001, Shirt, II");
        csvLines.AppendLine("43, 200002, Shorts, I");
        csvLines.AppendLine("@this is a comment");
        csvLines.AppendLine("");
        csvLines.AppendLine("44, 300003, Cap, V");

        var mockInputFile = new MockFileData(csvLines.ToString());

        var mockFileSystem = new MockFileSystem();
        mockFileSystem.AddFile(inputFilePath, mockInputFile);
        mockFileSystem.AddDirectory(outputDir);

        var sut = new CsvFileProcessor(inputFilePath,
                                        outputFilePath, 
                                        mockFileSystem);

        sut.Process();

        Assert.True(mockFileSystem.FileExists(outputFilePath));

        MockFileData processedFile = mockFileSystem.GetFile(outputFilePath);

        var lines = processedFile.TextContents.Split(Environment.NewLine);

        Assert.Equal("OrderNumber, Customer, Amount", lines[0]);
        Assert.Equal("42, 100001, 2", lines[1]);
        Assert.Equal("43, 200002, 1", lines[2]);
        Assert.Equal("44, 300003, 5", lines[3]);
    } 
}