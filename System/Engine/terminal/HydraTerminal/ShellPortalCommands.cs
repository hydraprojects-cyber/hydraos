namespace HydraTerminal;

using System;

/// <summary>
/// Comandos relacionados com o HydraPortal.
/// Neste momento é um módulo placeholder, mas preparado para expansão.
/// </summary>
public static class ShellPortalCommands
{
    public static bool Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Uso: portal <status|info>");
            return true;
        }

        switch (args[0].ToLower())
        {
            case "status":
                ShowStatus();
                return true;

            case "info":
                ShowInfo();
                return true;

            default:
                Console.WriteLine($"portal: comando '{args[0]}' não reconhecido.");
                return true;
        }
    }



    // ---------------------------------------------------------
    // STATUS DO PORTAL
    // ---------------------------------------------------------
    private static void ShowStatus()
    {
        Console.WriteLine();
        Console.WriteLine("HydraPortal Status:");
        Console.WriteLine("  Estado: online");
        Console.WriteLine("  Integração: mínima (placeholder)");
        Console.WriteLine("  Versão: 0.1");
        Console.WriteLine();
    }



    // ---------------------------------------------------------
    // INFO DO PORTAL
    // ---------------------------------------------------------
    private static void ShowInfo()
    {
        Console.WriteLine();
        Console.WriteLine("HydraPortal Info:");
        Console.WriteLine("  Este módulo será expandido no futuro.");
        Console.WriteLine("  Planeado: integração com HydraDesktop, HydraCloud e HydraOS.");
        Console.WriteLine();
    }
}
