using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Cosmos.Build.Common
{
    public static class CosmosPaths
    {
        public static readonly string UserKit;
        public static readonly string Build;
        public static readonly string Tools;
        public static readonly string GdbClientExe;
        //
        public static readonly string DevKit = null;
        public static readonly string DebugStubSrc;

        static string CheckPath(string aPath1, string aPath2)
        {
            return CheckPath(Path.Combine(aPath1, aPath2));
        }

        static string CheckPath(string aPath)
        {
            if (Directory.Exists(aPath) || File.Exists(aPath))
            {
                return aPath;
            }
            throw new Exception(aPath + " not found.");
        }

        static CosmosPaths()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
                {
                    using (var xReg = baseKey.OpenSubKey(@"Software\Cosmos", false))
                    {
                        if (xReg == null)
                        {
                            throw new Exception(@"HKEY_LOCAL_MACHINE\SOFTWARE\Cosmos was not found.");
                        }
                        UserKit = (string)xReg.GetValue("UserKit");
                        if (null == UserKit)
                        {
                            throw new Exception(@"HKEY_LOCAL_MACHINE\SOFTWARE\Cosmos\@UserKit was not found but UserKit must be installed!");
                        }
                    }
                }
            }
            else
            {
                UserKit = File.ReadAllText("/etc/CosmosUserKit.cfg").Replace("\n","") + "/";
                Console.WriteLine("userkit: " + UserKit);
            }

            Build = CheckPath(UserKit, @"Build");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Tools = CheckPath(UserKit, @"Build/Tools");
            }

            //GdbClientExe = CheckPath(UserKit, @"Build\VSIP\Cosmos.Debug.GDB.exe");
            DebugStubSrc = CheckPath(UserKit, @"XSharp/DebugStub");

            // Not finding this ones is not an issue. We will fallback to already retrieved stub from UserKit
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                using (var xReg = Registry.CurrentUser.OpenSubKey(@"Software/Cosmos", false))
                {
                    if (xReg != null)
                    {
                        DevKit = (string)xReg.GetValue("DevKit");
                        try
                        {
                            DebugStubSrc = CheckPath(DevKit, @"..\IL2CPU\source\Cosmos.Core.DebugStub");
                        }
                        catch
                        {
                        }
                    }
                }
            }
            else
            {
                //TODO
            }
        }

        /// <summary>This method is intentionally empty. It's sole purpose is to be able to trigger
        /// class initialization in a controlled manner so as to intercept initializer thrown
        /// exceptions.</summary>
        public static void Initialize()
        {

        }
    }
}
