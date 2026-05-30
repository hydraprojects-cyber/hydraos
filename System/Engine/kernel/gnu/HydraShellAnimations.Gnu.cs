namespace HydraOS.Kernel;

public class HydraShellAnimations
{
    public Task FadeIn()
    {
        Console.WriteLine("[fx] fade-in (console)");
        return Task.CompletedTask;
    }

    public Task BlurIn()
    {
        Console.WriteLine("[fx] blur-in (console)");
        return Task.CompletedTask;
    }
}
