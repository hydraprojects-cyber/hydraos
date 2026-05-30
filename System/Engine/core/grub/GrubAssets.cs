using System.IO;

namespace HydraOS.GRUB
{
    public static class GrubAssets
    {
        // Caminhos de origem (onde guardas os assets oficiais)
        private static readonly string SourceBackground =
            "assets/themes/grub/gb.jpg";

        private static readonly string SourceLogo =
            "assets/images/logo/hydra.png";

        // Caminhos de destino (onde o GRUB precisa deles)
        private static readonly string TargetBackground =
            "core/grub/themes/hydra/background.jpg";

        private static readonly string TargetLogo =
            "core/grub/themes/hydra/hydralogo.png";

        /// <summary>
        /// Garante que os assets críticos do GRUB existem e estão corretos.
        /// Executado sempre no arranque da aplicação.
        /// </summary>
        public static void Ensure()
        {
            // Cria diretório se não existir
            Directory.CreateDirectory("core/grub/themes/hydra");

            // Copia sempre — overwrite garante consistência
            File.Copy(SourceBackground, TargetBackground, overwrite: true);
            File.Copy(SourceLogo, TargetLogo, overwrite: true);
        }
    }
}
