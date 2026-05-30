namespace HydraOS.Defaults;

public static class DefaultsSecurity
{
    public static string HashAlgorithm => "SHA256";
    public static int MinPasswordLength => 8;
    public static bool RequireSymbols => true;
}
