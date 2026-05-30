namespace HydraOS.Kernel;

public class HydraSystemMonitor
{
    public Task PushCpuToConsole()
    {
        Console.WriteLine("[cpu] 12% (simulated)");
        return Task.CompletedTask;
    }
}
