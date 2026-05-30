using System;
using System.IO;
using System.Text.Json;

using System.Threading;


namespace HydraTerminal;

/// <summary>
/// Comandos do sistema dentro do HydraTerminal.
/// Aqui ficam operações como analyze, status, info, heal.
/// </summary>
public static class ShellSystemCommands
{
    public static bool Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Uso: system <analyze|status|info|heal>");
            return true;
        }

        switch (args[0].ToLower())
        {
            case "analyze":
                RunAnalyzer();
                return true;

            case "status":
                ShowStatus();
                return true;

            case "info":
                ShowInfo();
                return true;

            case "heal":
                RunHeal();
                return true;

            default:
                Console.WriteLine($"system: comando '{args[0]}' não reconhecido.");
                return true;
        }
    }



    // ---------------------------------------------------------
    // ANALYZER COM PROGRESSBARS HYDRA
    // ---------------------------------------------------------
    private static void RunAnalyzer()
    {
        Console.WriteLine();
        Console.WriteLine("[HYDRA] A executar Internal Analyzer...");
        Console.WriteLine();

        // 10 passos do analyzer
        for (int i = 1; i <= 10; i++)
        {
            DrawGenericBar(i, 10);
            Thread.Sleep(250);
        }

        Console.WriteLine();
        Console.WriteLine("[HYDRA] Analyzer concluído.");
        Console.WriteLine();
    }



    // ---------------------------------------------------------
    // STATUS
    // ---------------------------------------------------------
    private static void ShowStatus()
    {
        Console.WriteLine();
        Console.WriteLine("HydraOS Status:");
        Console.WriteLine($"  CPU : {HydraState.CpuModel}");
        Console.WriteLine($"  GPU : {HydraState.GpuModel}");
        Console.WriteLine($"  RAM : {HydraState.RamMb} MB");
        Console.WriteLine($"  Disk: {HydraState.RootDisk}");
        Console.WriteLine($"  HostMode: {HydraState.HostMode}");
        Console.WriteLine();
    }



    // ---------------------------------------------------------
    // INFO (tema + hardware)
    // ---------------------------------------------------------
    private static void ShowInfo()
    {
        Console.WriteLine();
        Console.WriteLine("HydraOS Info:");
        Console.WriteLine($"  Theme : {HydraState.Theme}");
        Console.WriteLine($"  Accent: {HydraState.Accent}");
        Console.WriteLine($"  Mode  : {HydraState.Mode}");
        Console.WriteLine($"  Font  : {HydraState.Font}");
        Console.WriteLine();
        Console.WriteLine($"  CPU   : {HydraState.CpuModel}");
        Console.WriteLine($"  GPU   : {HydraState.GpuModel}");
        Console.WriteLine($"  RAM   : {HydraState.RamMb} MB");
        Console.WriteLine($"  Disk  : {HydraState.RootDisk}");
        Console.WriteLine();
    }



    // ---------------------------------------------------------
    // HEAL (placeholder)
    // ---------------------------------------------------------
    private static void RunHeal()
    {
        Console.WriteLine("[HYDRA] Heal mode (placeholder).");
        Console.WriteLine("[HYDRA] No issues detetados.");
    }



    // ---------------------------------------------------------
    // PROGRESSBAR HYDRA DARK
    // ---------------------------------------------------------
    private static void DrawGenericBar(int current, int total, int width = 20)
    {
        double p = (double)current / total;
        int filled = (int)(p * width);

        Console.Write("[");
        for (int i = 0; i < width; i++)
            Console.Write(i < filled ? "=" : " ");
        Console.Write("] ");

        int percent = (int)(p * 100);
        Console.Write($"{percent,3}% ");

        Console.Write("█"); // bloco Hydra

        Console.Write("\r");
    }
}
