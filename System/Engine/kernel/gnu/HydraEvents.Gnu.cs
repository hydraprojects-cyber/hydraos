namespace HydraOS.Kernel;

public class HydraEvents
{
    public Task Push(string evt)
    {
        Console.WriteLine($"[event] {evt}");
        return Task.CompletedTask;
    }
}
