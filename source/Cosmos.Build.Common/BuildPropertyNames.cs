using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmos.Build.Common
{
    public static class BuildPropertyNames
    {
        public const string StackCorruptionDetectionEnabledString = "StackCorruptionDetectionEnabled";
        public const string StackCorruptionDetectionLevelString = "StackCorruptionDetectionLevel";
        public const string ProfileString = "Profile";
        public const string NameString = "Name";
        public const string DescriptionString = "Description";
        public const string DeploymentString = "Deployment";
        public const string LaunchString = "Launch";
        public const string ShowLaunchConsoleString = "ShowLaunchConsole";
        public const string DebugEnabledString = "DebugEnabled";
        public const string DebugModeString = "DebugMode";
        public const string IgnoreDebugStubAttributeString = "IgnoreDebugStubAttribute";
        public const string CosmosDebugPortString = "CosmosDebugPort";
        public const string VisualStudioDebugPortString = "VisualStudioDebugPort";
        public const string PxeInterfaceString = "PxeInterface";
        public const string SlavePortString = "SlavePort";
        public const string VMwareEditionString = "VMwareEdition";
        public const string FrameworkString = "Framework";
        public const string UseInternalAssemblerString = "UseInternalAssembler";
        public const string TraceAssembliesString = "TraceAssemblies";
        public const string EnableGDBString = "EnableGDB";
        public const string StartCosmosGDBString = "StartCosmosGDB";
        public const string EnableBochsDebugString = "EnableBochsDebug";
        public const string StartBochsDebugGui = "StartBochsDebugGui";
        public const string BinFormatString = "BinFormat";
        public const string IsoFileString = "ISOFile";
        public const string CompileVBEMultiboot = "CompileVBEMultiboot";
        public const string VBEResolution = "VBEResolution";
        public const string QemuLocation = "QemuLocationParameters";
        public const string QemuCustomArguments = "QemuCustomParameters";
        public const string QemuUseCustom = "QemuUseCustomParameters";
        public const string QemuSerial = "QemuUseSerial";
        public const string QemuAudioDriver = "QemuAudioDriver";
        public const string QemuVideoDriver = "QemuVideoDriver";
        public const string QemuUSBMouse = "QemuUSBMouse";
        public const string QemuUSBKeyboard = "QemuUSBKeyboard";
        public const string QemuNetworkDevice = "QemuNetworkDevice";
        public const string QemuMemory = "QemuMemory";
        public const string QemuHWAccel = "QemuHWAccel";
    }
}
