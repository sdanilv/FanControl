// Decompiled with JetBrains decompiler
// Type: AsusWin32API.DIFxAPI
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.InteropServices;

namespace AsusWin32API
{
  public static class DIFxAPI
  {
    public static int DRIVER_PACKAGE_REPAIR = 1;
    public static int DRIVER_PACKAGE_SILENT = 2;
    public static int DRIVER_PACKAGE_FORCE = 4;
    public static int DRIVER_PACKAGE_ONLY_IF_DEVICE_PRESENT = 8;
    public static int DRIVER_PACKAGE_LEGACY_MODE = 16;
    public static int DRIVER_PACKAGE_DELETE_FILES = 32;

    [DllImport("DIFxAPI.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int DriverPackageUninstall(string DriverPackageInfPath, int Flags, IntPtr pInstallerInfo, out bool pNeedReboot);

    [DllImport("DIFxAPI.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int DriverPackageInstall(string DriverPackageInfPath, int Flags, IntPtr pInstallerInfo, out bool pNeedReboot);

    [DllImport("DIFxAPI.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int DriverPackageInstall(ref string DriverPackageInfPath, int Flags, IntPtr pInstallerInfo, out bool pNeedReboot);

    [DllImport("DIFxAPI.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int DriverPackagePreinstall(string DriverPackageInfPath, int Flags);
  }
}
