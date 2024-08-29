
using System;
using System.Diagnostics;

class Program
{
    static async Task Main(string[] args)
    {

        var progress = new Progress<int>(percent =>
        {
            Console.WriteLine($"Progress: {percent}%");
        });

        using (CancellationTokenSource cts = new CancellationTokenSource())
        {
            CancellationToken token = cts.Token;

            var task = Task.Run(() => DoWork(token, progress), token);

            Console.WriteLine("Press 'c' to cancel the operation.");

            if (Console.ReadKey(true).KeyChar == 'c')
            {
                cts.Cancel();
                Console.WriteLine("Cancellation requested.");
            }

            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation was canceled.");
            }
            finally
            {
                cts.Dispose();
            }

        }

        Console.ReadLine();
    }

    static async Task DoWork(CancellationToken token, Progress<int> progress)
    {
        for (int i = 0; i < 10; i++)
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Cancellation requested inside the task.");

                token.ThrowIfCancellationRequested();
            }

            await Task.Delay(1000, token);

            // Report progress
            progress.ProgressChanged += (object? sender, int e) =>
            {
                Console.WriteLine($"Working... {i + 1}/10");
            };
        }
    }
}