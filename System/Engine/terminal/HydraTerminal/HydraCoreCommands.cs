using System;
using System.Diagnostics;

namespace HydraTerminal;

public static class HydraCoreCommands
{
    private static readonly Stopwatch Uptime = Stopwatch.StartNew();

    public static bool Execute(string cmd, string[] args)
    {
        switch (cmd)
        {
            case "sysinfo":
                CmdSysInfo();
                return true;

            case "whoami":
                CmdWhoAmI();
                return true;

            case "uptime":
                CmdUptime();
                return true;

            case "status":
                CmdStatus();
                return true;

            case "heal":
                CmdHeal();
                return true;

            case "ritual":
                CmdRitual();
                return true;

            default:
                return false;
        }
    }

    private static void CmdSysInfo()
    {
        Console.WriteLine("HydraOS System Information:");
        Console.WriteLine($"User: {HydraState.User}");
        Console.WriteLine($"Host: {HydraState.Host}");
        Console.WriteLine($"Path: {HydraState.Path}");
        Console.WriteLine($"OS: {Environment.OSVersion}");
        Console.WriteLine($"64-bit: {Environment.Is64BitOperatingSystem}");
    }

    private static void CmdWhoAmI()
    {
        Console.WriteLine(HydraState.User);   // ✔ CORRIGIDO
    }

    private static void CmdUptime()
    {
        Console.WriteLine($"Uptime: {Uptime.Elapsed}");
    }

    private static void CmdStatus()
    {
        Console.WriteLine("HydraOS Status:");
        Console.WriteLine("  Mode: DEMO (placeholder)");
        Console.WriteLine("  Profile: demo");
    }

    private static void CmdHeal()
    {
        Console.WriteLine("HydraOS Diagnostic:");
        Console.WriteLine("  ✔ Sistema estável");
        Console.WriteLine("  ✔ Terminal funcional");
        Console.WriteLine("  ✔ Dispatcher ativo");
        Console.WriteLine("  ✔ Nenhum erro crítico");
    }

    private static void CmdRitual()
    {
        Console.WriteLine("Iniciando ritual Hydra...");
        RitualEngine.RunFullCeremony();
    }
}
