namespace HydraOS.Kernel.HydraShield;

public static class ShieldScanner
{
    private static readonly string[] SuspiciousExtensions =
    {
        ".exe", ".dll", ".scr", ".bat", ".cmd", ".ps1", ".sh"
    };

    public static string Run(string? path = null)
    {
        path ??= Directory.GetCurrentDirectory();

        if (!Directory.Exists(path))
            return $"[HydraShield] Diretório inválido: {path}";

        var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

        var suspicious = files
            .Where(f => SuspiciousExtensions.Contains(Path.GetExtension(f).ToLower()))
            .ToList();

        if (suspicious.Count == 0)
            return "[HydraShield] Nenhuma ameaça encontrada.";

        var report = new List<string>
        {
            "[HydraShield] Ameaças potenciais encontradas:",
            "--------------------------------------------"
        };

        foreach (var file in suspicious)
            report.Add($" - {file}");

        return string.Join("\n", report);
    }
}
