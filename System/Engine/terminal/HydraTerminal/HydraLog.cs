namespace HydraTerminal;

using System;
using System.IO;

/// <summary>
/// Sistema central de logging do HydraTerminal.
/// Todos os módulos usam este logger para registar eventos internos.
/// </summary>
public static class HydraLog
{
    /// <summary>
    /// Caminho base onde os logs são guardados:
    /// %USERPROFILE%/.hydralocal/logs/terminal/
    /// </summary>
    private static readonly string BaseDir =
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".hydralocal", "logs", "terminal"
        );

    /// <summary>
    /// Caminho completo do ficheiro de log principal.
    /// </summary>
    private static readonly string LogPath =
        Path.Combine(BaseDir, "hydra_terminal.log");



    /// <summary>
    /// Regista uma linha no log interno do HydraTerminal.
    /// </summary>
    public static void Write(string message)
    {
        try
        {
            Directory.CreateDirectory(BaseDir);

            File.AppendAllText(
                LogPath,
                $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}\n"
            );
        }
        catch
        {
            // Nunca deixar o terminal crashar por causa de logs.
        }
    }



    /// <summary>
    /// Atalho para mensagens de arranque.
    /// </summary>
    public static void Boot(string message)
        => Write("[BOOT] " + message);

    /// <summary>
    /// Atalho para mensagens de sistema.
    /// </summary>
    public static void System(string message)
        => Write("[SYSTEM] " + message);

    /// <summary>
    /// Atalho para mensagens de erro.
    /// </summary>
    public static void Error(string message)
        => Write("[ERROR] " + message);
}
