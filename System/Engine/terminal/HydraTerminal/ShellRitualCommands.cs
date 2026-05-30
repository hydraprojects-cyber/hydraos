
namespace HydraTerminal;
/*
 * Comandos relacionados com o Ritual Hydra.
    * Agora com flags: --verbose e --silent.
    Aqui está **o ficheiro completo**, limpo, direto, sem tretas, sem invenções, **exatamente como pediste**:

# 🟩 **ShellRitualCommands.cs com flags (`--verbose`, `--silent`)**

✔ `ritual start` → mostra tudo “cara podre”  
✔ `ritual start --verbose` → mostra progressbars + passos  
✔ `ritual start --silent` → não mostra nada  
✔ sem mexer no resto do terminal  
✔ sem banners forçados  
✔ sem frases obrigatórias  
✔ comportamento técnico, previsível, à tua maneira  

---

# ✅ **FICHEIRO COMPLETO (PRONTO A COLAR)**


    */
using System;
using System.IO;
using System.Linq;
using System.Threading;

/// <summary>
/// Comandos relacionados com o Ritual Hydra.
/// Agora com flags: --verbose e --silent.
/// </summary>
public static class ShellRitualCommands
{
    public static bool Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Uso: ritual <start|status> [--verbose|--silent]");
            return true;
        }

        string command = args[0].ToLower();
        bool verbose = args.Contains("--verbose");
        bool silent = args.Contains("--silent");

        switch (command)
        {
            case "start":
                RunRitual(verbose, silent);
                return true;

            case "status":
                ShowStatus();
                return true;

            default:
                Console.WriteLine($"ritual: comando '{args[0]}' não reconhecido.");
                return true;
        }
    }



    // ---------------------------------------------------------
    // RITUAL PRINCIPAL COM FLAGS
    // ---------------------------------------------------------
    private static void RunRitual(bool verbose, bool silent)
    {
        if (!silent)
        {
            Console.WriteLine();
            Console.WriteLine("[HYDRA] Ritual iniciado...");
            Console.WriteLine();
        }

        // 1) Calcular HostMode
        HydraState.HostMode = CalculateHostMode();

        if (!silent)
        {
            Console.WriteLine($"HostMode definido para: {HydraState.HostMode}");
            Console.WriteLine();
        }

        // 2) Criar HydraLocal (como ontem)
        string hydraLocal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "HydraLocal");
        Directory.CreateDirectory(hydraLocal);

        if (verbose && !silent)
            Console.WriteLine($"[HYDRA] Diretório criado: {hydraLocal}");

        // 3) Etapas com progressbars (apenas em verbose)
        if (verbose)
        {
            string[] steps =
            {
                "Invocando módulos",
                "Aquecendo núcleos",
                "Sincronizando HydraCore",
                "Ajustando fluxo",
                "Selando ambiente"
            };

            foreach (var step in steps)
            {
                Console.WriteLine($"[HYDRA] {step,-30}:");

                for (int i = 1; i <= 20; i++)
                {
                    DrawGenericBar(i, 20);
                    Thread.Sleep(80);
                }

                Console.WriteLine();
            }
        }

        if (!silent)
        {
            Console.WriteLine("[HYDRA] Ritual concluído.");
            Console.WriteLine();
        }

        HydraLog.System($"Ritual concluído. HostMode={HydraState.HostMode}");
    }



    // ---------------------------------------------------------
    // STATUS
    // ---------------------------------------------------------
    private static void ShowStatus()
    {
        Console.WriteLine();
        Console.WriteLine("Hydra Ritual Status:");
        Console.WriteLine($"  HostMode atual: {HydraState.HostMode}");
        Console.WriteLine($"  RAM detetada  : {HydraState.RamMb} MB");
        Console.WriteLine();
    }



    // ---------------------------------------------------------
    // LÓGICA DO HOSTMODE
    // ---------------------------------------------------------
    private static string CalculateHostMode()
    {
        long ram = HydraState.RamMb;

        if (ram <= 4096)
            return "ultra-light";

        if (ram <= 8192)
            return "light";

        if (ram <= 16384)
            return "balanced";

        return "high-performance";
    }



    // ---------------------------------------------------------
    // PROGRESSBAR HYDRA DARK
    // ---------------------------------------------------------
    private static void DrawGenericBar(int current, int total, int width = 20)
    {
        double p = (double)current / total;
        int filled = (int)(p * width);

        Console.Write("[");
        for (int i = 0; i < width; i++)
            Console.Write(i < filled ? "=" : " ");
        Console.Write("] ");

        int percent = (int)(p * 100);
        Console.Write($"{percent,3}% ");

        Console.Write("█"); // bloco Hydra

        Console.Write("\r");
    }
}
