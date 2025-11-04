using AsyncVsAwaitProject;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

class Program
{
    public static async Task Main(string[] args)
    {
        //Console.WriteLine("===== Running Sync Version =====");
        //RunSync();

        Console.WriteLine("\n===== Running Async Version =====");
        await RunAsync();
    }

    // Sync Method
    private static void RunSync()
    {
        var sw = Stopwatch.StartNew();

        var clothes = SyncronousClass.WashClothes();
        SyncronousClass.DryClothes(clothes);
        SyncronousClass.CleanHome();
        SyncronousClass.CookFood();

        sw.Stop();
        Console.WriteLine($"Sync total time: {sw.ElapsedMilliseconds} ms");
    }

    // Async Method
    private static async Task RunAsync()
    {
        var sw = Stopwatch.StartNew();

        // Run tasks in parallel
        var task1 = WashAndDryClothes();
        var task2 = AsyncronousClass.CleanHomeAsync();
        var task3 = AsyncronousClass.CookFoodAsync();

        await Task.WhenAll(task1, task2, task3);

        sw.Stop();
        Console.WriteLine($"Async total time: {sw.ElapsedMilliseconds} ms");
    }

    private static async Task WashAndDryClothes()
    {
        var clothes = await AsyncronousClass.WashClothesAsync();
        AsyncronousClass.DryClothesAsync(clothes);
    }
}
