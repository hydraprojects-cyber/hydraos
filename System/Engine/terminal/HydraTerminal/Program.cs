using System;
using System.IO;

namespace HydraTerminal;

internal class Program
{
    static void Main(string[] args)
    {
        // 0) Criar pastas base HydraLocal e .hydralocal
        Initialize();

        // 0.1) Validar ícone HydraTerminal
        ValidateHydraIcon();

        // 0) Mensagem inicial
        Console.WriteLine("[HYDRA] A executar Internal Analyzer...");

        // 1) Barra nova inicial (RunSteps)
        HydraAnalyzer.RunSteps("Inicializando ambiente HydraOS", 5);

        // 2) Analyzer real (detecção + defaults)
        HydraAnalyzer.Run();

        // 3) Criar diretórios HydraOS
        HydraDirectories.CreateStructure();

        // 4) Garantir defaults.cfg existe
        ConfigManager.EnsureDefaults();

        // 5) Carregar tema
        ThemeBuilder.Load();

        // 6) Ritual / Splash
        SplashBanner.Show();

        // 7) CLI ou prompt
        if (args.Length > 0)
        {
            HydraCliShell.ExecuteArgs(args);
            return;
        }

        HydraPrompt.StartInteractive();
    }

    private static void Initialize()
    {
        string user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        string hydraInternal = Path.Combine(user, ".hydralocal");
        string hydraLocal = Path.Combine(user, "HydraLocal");

        Directory.CreateDirectory(hydraInternal);
        File.SetAttributes(hydraInternal, FileAttributes.Hidden);

        Directory.CreateDirectory(hydraLocal);

        Directory.CreateDirectory(Path.Combine(hydraInternal, "config"));
        Directory.CreateDirectory(Path.Combine(hydraInternal, "logs"));
        Directory.CreateDirectory(Path.Combine(hydraInternal, "state"));

        Directory.CreateDirectory(Path.Combine(hydraLocal, "Desktop"));
        Directory.CreateDirectory(Path.Combine(hydraLocal, "Documents"));
        Directory.CreateDirectory(Path.Combine(hydraLocal, "Downloads"));
        Directory.CreateDirectory(Path.Combine(hydraLocal, "Music"));
        Directory.CreateDirectory(Path.Combine(hydraLocal, "Pictures"));

        string source = Path.Combine(hydraLocal, "source");
        string logs = Path.Combine(hydraLocal, "logs");
        string temp = Path.Combine(hydraLocal, "temp");

        Directory.CreateDirectory(source);
        Directory.CreateDirectory(logs);
        Directory.CreateDirectory(temp);

        File.SetAttributes(source, FileAttributes.Hidden);
        File.SetAttributes(logs, FileAttributes.Hidden);
        File.SetAttributes(temp, FileAttributes.Hidden);
    }

    private static void ValidateHydraIcon()
    {
        string iconPath = Path.Combine("assets", "images", "icons", "hydra-terminal.ico");

        if (File.Exists(iconPath))
        {
            Console.WriteLine("[HYDRA] Ícone HydraTerminal OK.");
        }
        else
        {
            Console.WriteLine("[HYDRA] Aviso: Ícone hydra-terminal.ico não encontrado.");
            Console.WriteLine("[HYDRA] Procurado em: " + Path.GetFullPath(iconPath));
        }
    }
}
