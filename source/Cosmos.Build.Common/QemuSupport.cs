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
        public static bool QemuEnabled
        {
            get
            {
                return (null != QemuExe);
                //return false;
            }
        }

        /// <summary>Get a descriptor for the Qemu emulator program. The return value is a null reference if
        /// Qemu is not installed.</summary>
        public static FileInfo QemuExe
        {
            get;
            private set;
        }

        /// <summary>Retrieve installation path for Qemu and initialize the <see cref="QemuExe"/> property.
        /// Search is performed using the registry and rely on the shell command defined for the
        /// QemuConfigFile.</summary>
        private static void FindQemuExe()
        {
            // try
            // {
            //     using (var runCommandRegistryKey =
            //         Registry.ClassesRoot.OpenSubKey(@"QemuConfigFile\shell\Run\command", false))
            //     {
            //         if (null == runCommandRegistryKey)
            //         {
            //             return;
            //         }

            //         string commandLine = (string) runCommandRegistryKey.GetValue(null, null);
            //         if (null != commandLine)
            //         {
            //             commandLine = commandLine.Trim();
            //         }

            //         if (string.IsNullOrEmpty(commandLine))
            //         {
            //             return;
            //         }

            //         // Now perform some parsing on command line to discover full exe path.
            //         string candidateFilePath;
            //         int commandLineLength = commandLine.Length;
            //         if ('"' == commandLine[0])
            //         {
            //             // Seek for a non escaped double quote.
            //             int lastDoubleQuoteIndex = 1;
            //             for (; lastDoubleQuoteIndex < commandLineLength; lastDoubleQuoteIndex++)
            //             {
            //                 if ('"' != commandLine[lastDoubleQuoteIndex])
            //                 {
            //                     continue;
            //                 }

            //                 if ('\\' != commandLine[lastDoubleQuoteIndex - 1])
            //                 {
            //                     break;
            //                 }
            //             }

            //             if (lastDoubleQuoteIndex >= commandLineLength)
            //             {
            //                 return;
            //             }

            //             candidateFilePath = commandLine.Substring(1, lastDoubleQuoteIndex - 1);
            //         }
            //         else
            //         {
            //             // Seek for first separator character.
            //             int firstSeparatorIndex = 0;
            //             for (; firstSeparatorIndex < commandLineLength; firstSeparatorIndex++)
            //             {
            //                 if (char.IsSeparator(commandLine[firstSeparatorIndex]))
            //                 {
            //                     break;
            //                 }
            //             }

            //             if (firstSeparatorIndex >= commandLineLength)
            //             {
            //                 return;
            //             }

            //             candidateFilePath = commandLine.Substring(0, firstSeparatorIndex);
            //         }

            //         if (!File.Exists(candidateFilePath))
            //         {
            //             return;
            //         }

            //         QemuExe = new FileInfo(candidateFilePath);
            //     }
            // }
            // catch
            // {
            // }
        }
    }
}
