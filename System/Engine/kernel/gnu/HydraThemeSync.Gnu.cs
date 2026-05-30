namespace HydraOS.Kernel;

public class HydraThemeSync
{
    public Task PushThemeToConsole()
    {
        Console.WriteLine("[theme] default (console)");
        return Task.CompletedTask;
    }
}
