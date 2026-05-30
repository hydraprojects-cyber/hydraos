namespace HydraOS.BIOS;

public static class BiosState
{
    public static bool DefaultsLoaded { get; set; } = false;
    public static bool DiagnosticsPassed { get; set; } = false;
    public static bool ReadyForGrub => DefaultsLoaded && DiagnosticsPassed;
}
