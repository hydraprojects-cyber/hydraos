namespace HydraOS.Kernel.TerminalCore;

public static class TerminalCore
{
    public static string Dispatch(string cmd, string[] args)
    {
        switch (cmd)
        {
            case "shield":
                return ShieldCommands.Execute(args);

            case "report":
                return ReportCommands.Execute(args);

            case "system":
                return SystemCommands.Execute(args);

            case "ritual":
                return RitualCommands.Execute(args);

            case "portal":
                return PortalCommands.Execute(args);

            default:
                return $"Comando desconhecido: {cmd}";
        }
    }
}
