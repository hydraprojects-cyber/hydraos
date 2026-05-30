namespace HydraTerminal;

using System;

/// <summary>
/// Ecrã inicial do HydraTerminal.
/// Mostra o banner ASCII e mensagens de arranque.
/// Agora usa o tema carregado no HydraState.
/// </summary>
public static class SplashBanner
{
    public static void Show()
    {
        Console.Clear();

        // ---------------------------------------------------------
        // 1) FIGLET estilo Ubuntu + olhos
        // ---------------------------------------------------------
        Console.WriteLine("  _   _           _           ");
        Console.WriteLine(" | | | | ___  ___| |__   __ _ ");
        Console.WriteLine(" | |_| |/ _ \\/ __| '_ \\ / _` |");
        Console.WriteLine(" |  _  |  __/\\__ \\ | | | (_| |");
        Console.WriteLine(" |_| |_|\\___||___/_| |_|\\__,_|");
        Console.WriteLine("            (•_•)");
        Console.WriteLine();


        // ---------------------------------------------------------
        // 2) FRASE DO LAVOISIER
        // ---------------------------------------------------------
        Console.WriteLine("\"Nada se perde, nada se cria, tudo se transforma.\"");
        Console.WriteLine("                — Lavoisier");
        Console.WriteLine();


        // ---------------------------------------------------------
        // 3) MENSAGENS DE ARRANQUE
        // ---------------------------------------------------------
        Console.WriteLine("[HYDRA] Ambiente visual carregado.");
        Console.WriteLine($"[HYDRA] Tema ativo: {HydraState.Theme}");
        Console.WriteLine("[HYDRA] HydraTerminal pronto.");
        Console.WriteLine();
    }
}
