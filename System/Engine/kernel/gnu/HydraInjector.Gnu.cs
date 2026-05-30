using System;
using System.Threading.Tasks;

namespace HydraOS.Kernel;

public class HydraInjector
{
    public Task InjectAsync()
    {
        // No WebView2, no UI injection on GNU/Linux
        Console.WriteLine("[injector] GNU mode: no UI injection required.");
        return Task.CompletedTask;
    }
}
