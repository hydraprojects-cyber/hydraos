using System;
using System.Threading.Tasks;

namespace HydraOS.Kernel;

public class HydraBridge
{
    public Task InitAsync()
    {
        // No WebView2 bridge on GNU/Linux
        Console.WriteLine("[bridge] GNU mode: no UI bridge required.");
        return Task.CompletedTask;
    }

    public Task SendAsync(string channel, string payload)
    {
        // Simulação de envio de mensagens para UI
        Console.WriteLine($"[bridge:{channel}] {payload}");
        return Task.CompletedTask;
    }
}
