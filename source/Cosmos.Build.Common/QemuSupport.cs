using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Microsoft.Win32;

namespace Cosmos.Build.Common
{
    /// <summary>An helper class that is used from both Cosmos.VS.ProjectSystem and Cosmos.VS.DebugEngine for
    /// Qemu emulator support.</summary>
    public static class QemuSupport
    {
        static QemuSupport()
        {
            FindQemuExe();
        }

        /// <summary>Get a flag that tell whether Qemu is enabled on this system.</summary>
        public static bool QemuEnabled => QemuExe != null && QemuExe.Exists;

        //return false;
        /// <summary>Get a descriptor for the Qemu emulator program. The return value is a null reference if
        /// Qemu is not installed.</summary>
        public static FileInfo QemuExe
        {
            get;
            private set;
        }

        /// <summary>Retrieve installation path for Qemu and initialize the <see cref="QemuExe"/> property.</summary>
        private static void FindQemuExe()
        {
            string qemuEnvironment = Environment.GetEnvironmentVariable("QEMU");
            string qemuPath = Path.GetDirectoryName(qemuEnvironment);
            string qemuExe = Path.GetFileName(qemuEnvironment);

            if (!string.IsNullOrWhiteSpace(qemuExe) && File.Exists(qemuEnvironment))
            {
                QemuExe = new FileInfo(qemuEnvironment);
                return;
            }

            if (!string.IsNullOrWhiteSpace(qemuPath) && Directory.Exists(qemuPath))
            {
                var files = Directory.GetFiles(qemuPath, "*.exe");
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    if (fileName.Equals("qemu.exe", StringComparison.OrdinalIgnoreCase) || fileName.Contains("86"))
                    {
                        QemuExe = new FileInfo(file);
                        return;
                    }
                }
            }
        }
    }
}
