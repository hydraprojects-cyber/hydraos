using HydraOS.Kernel.HydraShield;

namespace HydraOS.Kernel.TerminalCore;

public static class ShieldCommands
{
    public static string Execute(string[] args)
    {
        if (args.Length == 0)
            return Help();

        return args[0] switch
        {
            "scan"       => Shield.Scan(),
            "quarantine" => args.Length > 1 ? Shield.Quarantine(args[1]) : "Falta o ficheiro.",
            "list"       => ShieldQuarantine.List(),
            "restore"    => args.Length > 1 ? ShieldQuarantine.Restore(args[1]) : "Falta o ID.",
            "rules"      => Shield.Rules(),
            "integrity"  => Shield.CheckIntegrity(),
            _            => Help()
        };
    }

    private static string Help() =>
        """
        HydraShield — Comandos disponíveis:
          shield scan
          shield quarantine <ficheiro>
          shield list
          shield restore <id>
          shield rules
          shield integrity
        """;
}
