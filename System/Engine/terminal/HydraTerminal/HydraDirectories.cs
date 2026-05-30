namespace HydraTerminal;

using System;
using System.IO;
using System.Threading;

public static class HydraDirectories
{
    public static void CreateStructure()
    {
        Console.WriteLine("[HYDRA] Criando diretórios HydraOS...");

        string[] dirs =
        {
            "HydraOS\\Core",
            "HydraOS\\Modules",
            "HydraOS\\Defaults",
            "HydraOS\\Logs",
            "HydraOS\\Temp"
        };

        int total = dirs.Length;
        int step = 0;

        foreach (var dir in dirs)
        {
            step++;
            DrawGenericBar(step, total);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                Console.WriteLine($"\n[HYDRA] Diretório criado: {dir}");
            }
            else
            {
                Console.WriteLine($"\n[HYDRA] Diretório já existe: {dir}");
            }

            Thread.Sleep(120);
        }

        Console.WriteLine("[HYDRA] Estrutura HydraOS pronta.");
    }

    private static void DrawGenericBar(int current, int total, int width = 20)
    {
        double p = (double)current / total;
        int filled = (int)(p * width);

        Console.Write("[ ");
        Console.Write(new string('█', filled));
        Console.Write(" ");

        int percent = (int)(p * 100);
        Console.Write($"{percent,3}%]");

        Console.Write("\r");
    }
}
