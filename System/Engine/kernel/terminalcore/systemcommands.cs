namespace HydraOS.Kernel.TerminalCore;

public static class SystemCommands
{
    public static string Execute(string[] args)
    {
        if (args.Length == 0)
            return Help();

        return args[0] switch
        {
            "info"   => "[HydraSystem] HydraOS Kernel ativo.",
            "paths"  => "[HydraSystem] Paths carregados.",
            "state"  => "[HydraSystem] Estado estável.",
            _        => Help()
        };
    }

    private static string Help() =>
        """
        HydraSystem — Comandos disponíveis:
          system info
          system paths
          system state
        """;
}
