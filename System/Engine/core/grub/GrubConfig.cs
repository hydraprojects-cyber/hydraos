namespace HydraOS.GRUB;

public static class GrubConfig
{
    public static void Load()
    {
        // Lê DefaultsSystem
        // Lê DefaultsTheme
        // Lê DefaultsSecurity (se necessário)
        // (No futuro) Lê grub.cfg se existir
    }

    public static string[] BootEntries =
    {
        "HYDRA-DEMO",
        "HYDRA-DEMO-PERSIST",
        "HYDRA-RECOVERY",
        "HYDRA-TERMINAL"
    };

}
