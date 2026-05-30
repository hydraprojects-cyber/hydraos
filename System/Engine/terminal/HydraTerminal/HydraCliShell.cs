namespace HydraTerminal;

using System;

/// <summary>
/// Permite executar comandos diretamente pela linha de comandos,
/// sem entrar no prompt interativo.
/// Exemplo:
///   hydra.exe system analyze
/// </summary>
public static class HydraCliShell
{
    /// <summary>
    /// Processa argumentos passados ao executável.
    /// </summary>
    public static void ExecuteArgs(string[] args)
    {
        if (args.Length == 0)
            return;

        // Construir comando completo
        string command = string.Join(' ', args);

        HydraLog.System($"CLI: {command}");

        // Enviar para o dispatcher principal
        HydraCommands.Dispatch(command);
    }
}
