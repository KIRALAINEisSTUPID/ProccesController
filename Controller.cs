using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        while (true) 
        {
            Console.Clear();
            Console.WriteLine("1. Start Process");
            Console.WriteLine("2. Kill Process");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            char choice = Console.ReadKey().KeyChar;

            switch (choice)
            {
                case '1': 
                    Console.Clear();
                    Console.Write("Enter process name (without .exe): ");
                    string processName = Console.ReadLine();

                    try
                    {
                        Process.Start("cmd.exe", $"/c start {processName}");
                        Console.WriteLine($"Process {processName} started successfully.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                    break;

                case '2':
                    Console.Clear();
                    Console.Write("Enter process name to kill (without .exe): ");
                    string processToKill = Console.ReadLine();

                    try
                    {
                        foreach (var process in Process.GetProcessesByName(processToKill))
                        {
                            process.Kill();
                            Console.WriteLine($"Process {processToKill} has been killed.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                    break;

                case '3': 
                    return;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input! Restarting in 5 seconds...");
                    for (int i = 5; i > 0; i--)
                    {
                        Console.WriteLine(i);
                        Thread.Sleep(1000);
                    }
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
