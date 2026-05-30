namespace HydraOS.Kernel;

public class HydraDiagnostics
{
    public Task Log(string message)
    {
        Console.WriteLine($"[diag] {message}");
        return Task.CompletedTask;
    }

    public Task LogObject(object obj)
    {
        Console.WriteLine($"[diag] {obj}");
        return Task.CompletedTask;
    }
}
