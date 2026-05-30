namespace HydraOS.Kernel.HydraShield;

public static class ShieldQuarantine
{
    private static readonly string QuarantinePath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        "HydraLocal/.shield/quarantine");

    public static string Add(string file)
    {
        Directory.CreateDirectory(QuarantinePath);

        if (!File.Exists(file))
            return $"[HydraShield] Ficheiro não encontrado: {file}";

        var id = Guid.NewGuid().ToString("N");
        var name = $"{id}_{Path.GetFileName(file)}";
        var dest = Path.Combine(QuarantinePath, name);

        File.Move(file, dest, true);

        return $"[HydraShield] Ficheiro movido para quarentena: {name}";
    }

    public static string List()
    {
        Directory.CreateDirectory(QuarantinePath);

        var files = Directory.GetFiles(QuarantinePath);

        if (files.Length == 0)
            return "[HydraShield] Quarentena vazia.";

        return string.Join("\n", files.Select(Path.GetFileName));
    }

    public static string Restore(string id)
    {
        Directory.CreateDirectory(QuarantinePath);

        var file = Directory.GetFiles(QuarantinePath)
            .FirstOrDefault(f => Path.GetFileName(f)!.StartsWith(id));

        if (file == null)
            return $"[HydraShield] ID não encontrado: {id}";

        var originalName = string.Join("_", Path.GetFileName(file)!.Split("_").Skip(1));
        var dest = Path.Combine(Directory.GetCurrentDirectory(), originalName);

        File.Move(file, dest, true);

        return $"[HydraShield] Restaurado: {dest}";
    }
}
