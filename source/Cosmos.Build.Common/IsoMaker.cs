using System.IO;

namespace Cosmos.Build.Common
{
    public static class IsoMaker
    {
        public static string Generate(string imageFile, string isoFilename)
        {
            var destinationDirectory = Path.GetDirectoryName(imageFile);

            string isoDirectory = Path.Combine(destinationDirectory, "iso");

            if (Directory.Exists(isoDirectory))
            {
                Directory.Delete(isoDirectory, true);
            }

            Directory.CreateDirectory(isoDirectory);

            var buildISO = Path.Combine(CosmosPaths.Build, "ISO");

            Copy(buildISO + "/boot/", isoDirectory + "/boot/");
            File.Copy(imageFile, Path.Combine(isoDirectory + "/boot/", "Cosmos.bin"));

            string arg =
                "-as mkisofs " +
                "-relaxed-filenames" +
                " -J -R" +
                " -o " + Quote(isoFilename) +
                " -b boot/limine/limine-cd.bin " +
                " -no-emul-boot" +
                " -boot-load-size 4" +
                " -boot-info-table " +
                Quote(isoDirectory.Substring(Directory.GetCurrentDirectory().Length));

            var output = ProcessExtension.LaunchApplication(
                Path.Combine(Path.Combine(CosmosPaths.Tools, "xorriso"), "xorriso.exe"),
                arg,
                true
            );


            return output;
        }

        private static void Copy(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));
            }

            foreach (var directory in Directory.GetDirectories(sourceDir))
            {
                Copy(directory, Path.Combine(targetDir, Path.GetFileName(directory)));
            }
        }

        private static string Quote(string location)
        {
            return '"' + location + '"';
        }
    }
}
