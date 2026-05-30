namespace HydraOS.Kernel;

public class HydraNotifications
{
    public Task Push(string title, string message, string type = "info")
    {
        Console.WriteLine($"[notify:{type}] {title} :: {message}");
        return Task.CompletedTask;
    }
}
