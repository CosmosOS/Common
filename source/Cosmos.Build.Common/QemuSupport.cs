using System;
using System.IO;
using Microsoft.Win32;

namespace Cosmos.Build.Common
{
    public static class QemuSupport
    {
        static QemuSupport()
        {
            FindQemuExe();
        }

        public static bool QemuEnabled => QemuExe != null;

        public static FileInfo QemuExe { get; private set; }

        private static void FindQemuExe()
        {
            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (var xReg = baseKey.OpenSubKey(@"Software\QEMU", false))
                {
                    if (xReg == null)
                    {
                        throw new Exception(@"HKEY_LOCAL_MACHINE\SOFTWARE\QEMU was not found.");
                    }

                    string installDir = (string) xReg.GetValue("Install_Dir");
                    if (string.IsNullOrWhiteSpace(installDir))
                    {
                        throw new Exception(@"HKEY_LOCAL_MACHINE\SOFTWARE\QEMU\Install_Dir was not found");
                    }

                    string qemuExe = "qemu-system-i386.exe";
                    string qemuFullPath = Path.Combine(installDir, qemuExe);

                    if (!File.Exists(qemuFullPath))
                    {
                        return;
                    }

                    QemuExe = new FileInfo(qemuFullPath);
                }
            }
        }
    }
}
