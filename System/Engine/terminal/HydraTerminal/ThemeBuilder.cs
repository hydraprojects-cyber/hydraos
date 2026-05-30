namespace HydraTerminal;

using System;

/// <summary>
/// Carrega o tema visual do HydraTerminal a partir do defaults.cfg.
/// Este módulo apenas lê valores e atualiza o HydraState.
/// </summary>
public static class ThemeBuilder
{
    /// <summary>
    /// Carrega o tema a partir do defaults.cfg usando o ConfigManager.
    /// </summary>
    public static void Load()
    {
        HydraLog.System("ThemeBuilder: carregando tema...");

        var lines = ConfigManager.ReadAll();

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                continue;

            var parts = line.Split('=', 2);
            if (parts.Length != 2)
                continue;

            var key = parts[0].Trim().ToLower();
            var value = parts[1].Trim();

            switch (key)
            {
                case "theme":
                    HydraState.Theme = value;
                    break;

                case "accent":
                    HydraState.Accent = value;
                    break;

                case "mode":
                    HydraState.Mode = value;
                    break;

                case "font":
                    HydraState.Font = value;
                    break;
            }
        }

        HydraLog.System($"ThemeBuilder: tema carregado ({HydraState.Theme}).");
    }
}
