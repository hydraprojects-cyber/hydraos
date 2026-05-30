using System;
using System.IO;
using System.Runtime.InteropServices;

namespace HydraOS.Kernel;

public static class HydraLocalManager
{
    public static string LocalPath =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? @"C:\HydraLocal"
            : Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "HydraLocal");

    public static void EnsureLocalEnvironment()
    {
        if (!Directory.Exists(LocalPath))
            Directory.CreateDirectory(LocalPath);

        EnsureScript("HydraCeremony.sh");
        EnsureScript("HydraCeremony.ps1");
        EnsureFolder("HydraSounds");
        CopySounds();
    }

    private static void EnsureScript(string scriptName)
    {
        string localScript = Path.Combine(LocalPath, scriptName);
        string templateScript = Path.Combine("templates", scriptName);

        if (!File.Exists(templateScript))
            return;

        if (!File.Exists(localScript))
            File.Copy(templateScript, localScript, overwrite: false);
    }

    private static void EnsureFolder(string folderName)
    {
        string path = Path.Combine(LocalPath, folderName);
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }

    private static void CopySounds()
    {
        string source = Path.Combine("templates", "HydraSounds");
        string dest = Path.Combine(LocalPath, "HydraSounds");

        if (!Directory.Exists(source))
            return;

        foreach (var file in Directory.GetFiles(source))
        {
            string name = Path.GetFileName(file);
            string target = Path.Combine(dest, name);

            if (!File.Exists(target))
                File.Copy(file, target, overwrite: false);
        }
    }
}
