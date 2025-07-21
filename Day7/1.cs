using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks; 
public class FileProcessor
{
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(3); // Allow max 3 files at a time
 
    public async Task ProcessFilesAsync(List<string> files)
    {
        List<Task> tasks = new List<Task>();
 
        foreach (var file in files)
        {
            tasks.Add(ProcessFileWithSemaphoreAsync(file));
        }
 
        await Task.WhenAll(tasks);
    } 
    private async Task ProcessFileWithSemaphoreAsync(string file)
    {
        await _semaphore.WaitAsync(); // Wait for available slot
 
        try
        {
            Console.WriteLine($"Starting processing: {file}");
 
            await ProcessFileAsync(file);
 
            Console.WriteLine($"Completed processing: {file}");
        }
        finally
        {
            _semaphore.Release(); // Release slot for next file
        }
    } 
    private async Task ProcessFileAsync(string file)
    {
        // Simulate file processing (2 seconds delay)
        await Task.Delay(2000);
    }
}
class Program
{
    static async Task Main(string[] args)
    {
        var files = new List<string> { "file1.txt", "file2.txt", "file3.txt", "file4.txt"};
 
        var processor = new FileProcessor();
 
        await processor.ProcessFilesAsync(files);
    }
}
 