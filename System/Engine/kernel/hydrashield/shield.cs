namespace HydraOS.Kernel.HydraShield;

public static class Shield
{
    public static string Scan() => ShieldScanner.Run();
    public static string CheckIntegrity() => ShieldIntegrity.Verify();
    public static string Quarantine(string file) => ShieldQuarantine.Add(file);
    public static string Rules() => ShieldRules.List();
}
