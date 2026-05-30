using System;

namespace HydraTerminal;

/// <summary>
/// Estado global do HydraOS.
/// Tudo o que o Analyzer deteta, o Ritual usa e o ThemeBuilder aplica.
/// Este ficheiro é o coração do sistema.
/// </summary>
public static class HydraState
{
    // -----------------------------
    // IDENTIDADE DO SISTEMA
    // -----------------------------

    /// <summary>Nome do utilizador atual.</summary>
    public static string User { get; set; } = Environment.UserName;

    /// <summary>Nome da máquina.</summary>
    public static string Host { get; set; } = Environment.MachineName;

    /// <summary>Diretório atual.</summary>
    public static string Path { get; set; } = Environment.CurrentDirectory;



    // -----------------------------
    // HARDWARE DETECTADO (Analyzer)
    // -----------------------------

    /// <summary>Total de RAM em MB.</summary>
    public static long RamMb { get; set; }

    /// <summary>Modelo da CPU detetada.</summary>
    public static string CpuModel { get; set; } = "";

    /// <summary>Modelo da GPU detetada.</summary>
    public static string GpuModel { get; set; } = "";

    /// <summary>Disco raiz do sistema.</summary>
    public static string RootDisk { get; set; } = "";



    // -----------------------------
    // TEMA / APARÊNCIA (ThemeBuilder)
    // -----------------------------

    /// <summary>Tema visual atual (ex: hydra-dark).</summary>
    public static string Theme { get; set; } = "hydra-dark";

    /// <summary>Cor de destaque (accent color).</summary>
    public static string Accent { get; set; } = "#00AEEF";

    /// <summary>Modo visual (dark/light).</summary>
    public static string Mode { get; set; } = "dark";

    /// <summary>Fonte usada no terminal.</summary>
    public static string Font { get; set; } = "default";



    // -----------------------------
    // PERFIL DE HOST (Ritual)
    // -----------------------------

    /// <summary>
    /// HostMode calculado pelo Ritual:
    /// ultra-light, light, balanced, high-performance.
    /// </summary>

    public static string HostMode { get; set; } = "balanced";
    public static bool RitualRan { get; set; } = false;

}
