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
           
        QemuExe = new FileInfo(@"C:\qemu\qemu-system-i386.exe");
   
        }
    }
}
