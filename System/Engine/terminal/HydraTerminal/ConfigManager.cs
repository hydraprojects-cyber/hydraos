namespace HydraTerminal;

using System;
using System.IO;

/// <summary>
/// Gestor central de configuração do HydraOS.
/// Unifica o acesso ao defaults.cfg e garante que todos os módulos
/// usam o MESMO caminho e o MESMO formato.
/// </summary>
public static class ConfigManager
{
    /// <summary>
    /// Caminho final e oficial do defaults.cfg:
    /// %USERPROFILE%/.hydralocal/config/defaults.cfg
    /// </summary>
    public static readonly string ConfigPath =
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".hydralocal", "config", "defaults.cfg"
        );



    /// <summary>
    /// Garante que o ficheiro defaults.cfg existe.
    /// Se não existir, cria um ficheiro limpo com valores base.
    /// </summary>
    public static void EnsureDefaults()
    {
        var dir = Path.GetDirectoryName(ConfigPath)!;
        Directory.CreateDirectory(dir);

        if (File.Exists(ConfigPath))
            return;

        var lines = new[]
        {
            "# HydraOS defaults (clean)",
            "cpu_model=",
            "gpu_info=",
            "root_disk=",
            "ram_total_mb=0",
            "theme=hydra-dark",
            "accent=#00AEEF",
            "mode=dark",
            "font=default"
        };

        File.WriteAllLines(ConfigPath, lines);
        HydraLog.System("defaults.cfg criado.");
    }



    /// <summary>
    /// Lê o defaults.cfg e devolve todas as linhas válidas.
    /// </summary>
    public static string[] ReadAll()
    {
        EnsureDefaults();
        return File.ReadAllLines(ConfigPath);
    }



    /// <summary>
    /// Guarda o defaults.cfg com as informações atuais do HydraState.
    /// Este método é usado pelo Analyzer.
    /// </summary>
    public static void SaveFromState()
    {
        EnsureDefaults();

        var lines = new[]
        {
            "# HydraOS defaults (generated)",
            $"cpu_model={HydraState.CpuModel}",
            $"gpu_info={HydraState.GpuModel}",
            $"root_disk={HydraState.RootDisk}",
            $"ram_total_mb={HydraState.RamMb}",
            $"theme={HydraState.Theme}",
            $"accent={HydraState.Accent}",
            $"mode={HydraState.Mode}",
            $"font={HydraState.Font}"
        };

        File.WriteAllLines(ConfigPath, lines);
        HydraLog.System("defaults.cfg atualizado a partir do HydraState.");
    }
}
