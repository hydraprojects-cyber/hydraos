namespace HydraTerminal;

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

public static class HydraAnalyzer
{
    public static void Run()
    {
        HydraLog.System("Analyzer iniciado.");

        int total = 4;
        int step = 0;

        Console.WriteLine("[HYDRA] Detectando CPU...");
        step++; DrawGenericBar(step, total);
        DetectCpu();
        Console.WriteLine();

        Console.WriteLine("[HYDRA] Detectando GPU...");
        step++; DrawGenericBar(step, total);
        DetectGpu();
        Console.WriteLine();

        Console.WriteLine("[HYDRA] Detectando Disco...");
        step++; DrawGenericBar(step, total);
        DetectDisk();
        Console.WriteLine();

        Console.WriteLine("[HYDRA] Detectando RAM...");
        step++; DrawGenericBar(step, total);
        DetectRam();
        Console.WriteLine();

        HydraLog.System("Analyzer: hardware detetado.");
        ConfigManager.SaveFromState();
        HydraLog.System("Analyzer concluído.");
    }

    // -----------------------------
    // Barra inicial do arranque
    // -----------------------------
    public static void RunSteps(string title, int total)
    {
        Console.WriteLine($"[HYDRA] {title}");

        for (int i = 1; i <= total; i++)
        {
            DrawGenericBar(i, total);
            Thread.Sleep(120);
        }

        Console.WriteLine();
    }

    // -----------------------------
    // Analisar host machine
    // -----------------------------
    public static void AnalyzeHost()
    {
        string host = Environment.MachineName;
        string hostType = "Windows Host Machine";

        Console.WriteLine($"[HYDRA] A analisar {host} ({hostType})...");
        RunSteps("A analisar host machine", 5);
    }

    // -----------------------------
    // Progressbar HydraDark
    // -----------------------------
    private static void DrawGenericBar(int current, int total, int width = 20)
    {
        double p = (double)current / total;
        int filled = (int)(p * width);

        Console.Write("\r[ ");
        Console.Write(new string('█', filled));
        Console.Write(" ");

        int percent = (int)(p * 100);
        Console.Write($"{percent,3}%]");
    }

    // -----------------------------
    // CPU
    // -----------------------------
    private static void DetectCpu()
    {
        HydraState.CpuModel = RunPowershell("(Get-CimInstance Win32_Processor).Name").Trim();
    }

    // -----------------------------
    // GPU
    // -----------------------------
    private static void DetectGpu()
    {
        HydraState.GpuModel = RunPowershell("(Get-CimInstance Win32_VideoController).Name").Trim();
    }

    // -----------------------------
    // DISK
    // -----------------------------
    private static void DetectDisk()
    {
        HydraState.RootDisk = RunPowershell(
            "(Get-CimInstance Win32_LogicalDisk | Where-Object {$_.DriveType -eq 3}).DeviceID"
        ).Trim();
    }

    // -----------------------------
    // RAM
    // -----------------------------
    private static void DetectRam()
    {
        var output = RunPowershell("(Get-CimInstance Win32_ComputerSystem).TotalPhysicalMemory").Trim();

        if (long.TryParse(output, out long bytes))
            HydraState.RamMb = bytes / (1024 * 1024);
        else
            HydraState.RamMb = 0;
    }

    // -----------------------------
    // POWERSHELL
    // -----------------------------
    private static string RunPowershell(string cmd)
    {
        try
        {
            var psi = new ProcessStartInfo("powershell", "-NoProfile -Command \"" + cmd + "\"")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var p = Process.Start(psi);
            return p!.StandardOutput.ReadToEnd();
        }
        catch
        {
            return "";
        }
    }
}
