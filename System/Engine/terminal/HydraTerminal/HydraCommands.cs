namespace HydraTerminal;

using System;

/// <summary>
/// Dispatcher principal do HydraTerminal.
/// Recebe o comando bruto do utilizador e encaminha para o módulo correto.
/// </summary>
public static class HydraCommands
{
    /// <summary>
    /// Processa um comando completo (string) vindo do HydraPrompt.
    /// </summary>
    public static void Dispatch(string input)
    {
        HydraLog.System($"Comando recebido: {input}");

        // Separar comando e argumentos
        var parts = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0)
            return;

        string cmd = parts[0].ToLower();
        string[] args = parts.Length > 1 ? parts[1..] : Array.Empty<string>();

        // ---------------------------------------------------------
        // 1) Comandos internos do HydraTerminal
        // ---------------------------------------------------------
        switch (cmd)
        {
            case "system":
                ShellSystemCommands.Execute(args);
                return;

            case "portal":
                ShellPortalCommands.Execute(args);
                return;

            case "ritual":
                ShellRitualCommands.Execute(args);
                return;

            case "help":
                ShowHelp();
                return;

            case "clear":
                Console.Clear();
                return;

            case "theme":
                ShowThemeInfo();
                return;
        }

        // ---------------------------------------------------------
        // 2) Comando não reconhecido
        // ---------------------------------------------------------
        Console.WriteLine($"hydra: comando '{cmd}' não encontrado.");
    }



    // ---------------------------------------------------------
    // HELP
    // ---------------------------------------------------------
    private static void ShowHelp()
    {
        Console.WriteLine();
        Console.WriteLine("Comandos disponíveis:");
        Console.WriteLine("  system <analyze>     - Executa o analyzer interno");
        Console.WriteLine("  ritual <start>       - Executa o ritual Hydra");
        Console.WriteLine("  portal <status>      - Estado do HydraPortal");
        Console.WriteLine("  clear                - Limpa o ecrã");
        Console.WriteLine("  theme                - Mostra o tema atual");
        Console.WriteLine("  help                 - Mostra esta ajuda");
        Console.WriteLine();
    }



    // ---------------------------------------------------------
    // INFO DO TEMA
    // ---------------------------------------------------------
    private static void ShowThemeInfo()
    {
        Console.WriteLine();
        Console.WriteLine("Tema atual:");
        Console.WriteLine($"  Theme : {HydraState.Theme}");
        Console.WriteLine($"  Accent: {HydraState.Accent}");
        Console.WriteLine($"  Mode  : {HydraState.Mode}");
        Console.WriteLine($"  Font  : {HydraState.Font}");
        Console.WriteLine();
    }
}
