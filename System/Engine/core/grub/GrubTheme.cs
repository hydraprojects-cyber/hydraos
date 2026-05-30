namespace HydraOS.GRUB;

public static class GrubTheme
{
    
    public static string BackgroundPath { get; private set; } = "core/grub/themes/hydra/background.jpg";

    public static string LogoPath { get; private set; } = "core/grub/themes/hydra/hydralogo.png";
    public static string Layout => "center"; // agora fica no centro
    public static string Font { get; private set; } = "Inter";
    public static string Mode { get; private set; } = "dark";

    public static void ApplyDefaults()
    {
        // No futuro: ler do GrubConfig
        // Por agora: usar valores base
    }
}
