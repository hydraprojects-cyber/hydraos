namespace HydraTerminal;

using System;

/// <summary>
/// Prompt interativo principal do HydraTerminal.
/// Responsável por ler comandos, enviar para o dispatcher
/// e manter o loop principal do terminal.
/// </summary>
public static class HydraPrompt
{
    /// <summary>
    /// Inicia o loop interativo do terminal.
    /// </summary>
    public static void StartInteractive()
    {
        HydraLog.System("Prompt iniciado.");

        while (true)
        {
            // ---------------------------------------------------------
            // 1) Mostrar prefixo do prompt
            //    Exemplo: hydra-dark> 
            // ---------------------------------------------------------
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{HydraState.Theme}> ");
            Console.ResetColor();

            // ---------------------------------------------------------
            // 2) Ler input do utilizador
            // ---------------------------------------------------------
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            // ---------------------------------------------------------
            // 3) Comando especial: sair com F12 ou "exit"
            // ---------------------------------------------------------
            if (input.Trim().ToLower() == "exit")
            {
                HydraLog.System("Terminal encerrado pelo utilizador.");
                Console.WriteLine("[HYDRA] Encerrando...");
                break;
            }

            // ---------------------------------------------------------
            // 4) Enviar comando para o dispatcher
            // ---------------------------------------------------------
            HydraCommands.Dispatch(input);
        }
    }
}
