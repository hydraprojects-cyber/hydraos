using System;
using System.Threading;

namespace HydraTerminal;

public static class RitualEngine
{
    private const int Delay = 250;

    public static void RunFullCeremony()
    {
        Console.WriteLine("[HYDRA] Ritual iniciado...");
        Console.WriteLine();

        RunStep("[HYDRA] Invocando módulos...", 8);
        RunStep("[HYDRA] Aquecendo núcleos...", 8);
        RunStep("[HYDRA] Sincronizando HydraCore...", 10);
        RunStep("[HYDRA] Ajustando fluxo...", 6);
        RunStep("[HYDRA] Selando ambiente...", 8);

        HydraState.HostMode = "balanced";
        HydraState.RitualRan = true;

        Console.WriteLine();
        Console.WriteLine($"HostMode definido para: {HydraState.HostMode}");
        Console.WriteLine("[HYDRA] Ritual concluído.");
        Console.WriteLine();
    }

    private static void RunStep(string label, int steps)
    {
        Console.WriteLine(label);

        for (int i = 1; i <= steps; i++)
        {
            DrawGenericBar(i, steps, 20);
            Thread.Sleep(Delay);
        }

        DrawGenericBar(steps, steps, 20);
        Console.WriteLine();
        Console.WriteLine();
    }

  private static void DrawGenericBar(int current, int total, int width = 20)
    {
        double p = (double)current / total;
    int filled = (int)(p * width);

    Console.Write("[ ");

    // barra real HydraDark
    Console.Write(new string('█', filled));

    Console.Write(" ");

    int percent = (int)(p * 100);
    Console.Write($"{percent,3}%]");

    Console.Write("\r");
    }

}
