using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Envoirnment_Core
{
  public class Program
  {
    //  static void Main(string[] args)
    //  {
    //    int deviceCount = 0;
    //    IntPtr deviceList = IntPtr.Zero;
    //    // GUID for processor classid
    //    Guid processorGuid = new Guid("{50127dc3-0f36-415e-a6cc-4cb3be910b65}");

    //    try
    //    {
    //      // get a list of all processor devices
    //      deviceList = SetupDiGetClassDevs(ref processorGuid, "ACPI", IntPtr.Zero, (int)DIGCF.PRESENT);
    //      // attempt to process each item in the list
    //      for (int deviceNumber = 0; ; deviceNumber++)
    //      {
    //        SP_DEVINFO_DATA deviceInfo = new SP_DEVINFO_DATA();
    //        deviceInfo.cbSize = Marshal.SizeOf(deviceInfo);

    //        // attempt to read the device info from the list, if this fails, we're at the end of the list
    //        if (!SetupDiEnumDeviceInfo(deviceList, deviceNumber, ref deviceInfo))
    //        {
    //          deviceCount = deviceNumber - 1;
    //          break;
    //        }
    //      }
    //    }
    //    finally
    //    {
    //      if (deviceList != IntPtr.Zero) { SetupDiDestroyDeviceInfoList(deviceList); }
    //    }
    //    Console.WriteLine("Number of cores: {0}", deviceCount);
    //  }

    //  [DllImport("setupapi.dll", SetLastError = true)]
    //  private static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid,
    //      [MarshalAs(UnmanagedType.LPStr)]String enumerator,
    //      IntPtr hwndParent,
    //      Int32 Flags);

    //  [DllImport("setupapi.dll", SetLastError = true)]
    //  private static extern Int32 SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

    //  [DllImport("setupapi.dll", SetLastError = true)]
    //  private static extern bool SetupDiEnumDeviceInfo(IntPtr DeviceInfoSet,
    //      Int32 MemberIndex,
    //      ref SP_DEVINFO_DATA DeviceInterfaceData);

    //  [StructLayout(LayoutKind.Sequential)]
    //  private struct SP_DEVINFO_DATA
    //  {
    //    public int cbSize;
    //    public Guid ClassGuid;
    //    public uint DevInst;
    //    public IntPtr Reserved;
    //  }

    //  private enum DIGCF
    //  {
    //    DEFAULT = 0x1,
    //    PRESENT = 0x2,
    //    ALLCLASSES = 0x4,
    //    PROFILE = 0x8,
    //    DEVICEINTERFACE = 0x10,
    //  }
    //}
    public static void Main()
    {
      foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
      {
        Console.WriteLine("Number Of Physical Processors: {0} ", item["NumberOfProcessors"]);
      }

      int coreCount = 0;
      foreach (var item in new System.Management.ManagementObjectSearcher("Select NumberOfCores from Win32_Processor").Get())
      {
        coreCount += int.Parse(item["NumberOfCores"].ToString());
      }
      Console.WriteLine("Number Of Cores: {0}", coreCount);

      Console.WriteLine("Number Of Logical Processors: {0}", Environment.ProcessorCount);
    }
  }
}
