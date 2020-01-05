// Decompiled with JetBrains decompiler
// Type: AsusWin32API.Kernel32
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AsusWin32API
{
  public static class Kernel32
  {
    public static uint GENERIC_READ = 2147483648;
    public static uint GENERIC_WRITE = 1073741824;
    public static uint FILE_SHARE_WRITE = 2;
    public static uint FILE_SHARE_READ = 1;
    public static uint FILE_ATTRIBUTE_NORMAL = 128;
    public static uint STANDARD_RIGHTS_REQUIRED = 983040;
    public static uint SYNCHRONIZE = 1048576;
    public static uint EVENT_ALL_ACCESS = (uint) ((int) Kernel32.STANDARD_RIGHTS_REQUIRED | (int) Kernel32.SYNCHRONIZE | 3);
    public static uint EVENT_MODIFY_STATE = 2;
    public static long ERROR_FILE_NOT_FOUND = 2;
    public static uint WAIT_OBJECT_0 = 0;
    public static uint PACKAGE_FILTER_DIRECT = 32;
    public static uint PACKAGE_FILTER_HEAD = 16;
    public static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

    [DllImport("kernel32.dll")]
    public static extern int GetLastError();

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool SetEvent(IntPtr hEvent);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool ResetEvent(IntPtr hEvent);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

    [DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern IntPtr OpenEvent(uint dwDesiredAccess, bool bInheritHandle, string lpName);

    [DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern uint GetDllDirectory(uint nBufferLength, IntPtr lpBuffer);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetDiskFreeSpaceEx(string lpDirectoryName, out ulong lpFreeBytesAvailable, out ulong lpTotalNumberOfBytes, out ulong lpTotalNumberOfFreeBytes);

    [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool GetSystemPowerStatus(out SystemPowerStatus lpsystemPowerStatus);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr CreateToolhelp32Snapshot(SnapshotFlags dwFlags, uint th32ProcessID);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern uint WTSGetActiveConsoleSessionId();

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern uint WinExec(string lpCmdLine, uint uCmdShow);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool Process32First(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool ProcessIdToSessionId(uint dwProcessId, out uint pSessionId);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool Process32Next(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetCurrentProcess();

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, IntPtr lpInBuffer, int nInBufferSize, IntPtr lpOutBuffer, int nOutBufferSize, ref int lpBytesReturned, IntPtr lpOverlapped);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, ECreationDisposition dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool CloseHandle(IntPtr hObject);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool SetDllDirectory(string PathName);

    [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int GetPrivateProfileSectionNames(byte[] lpszReturnBuffer, int nSize, string lpFileName);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnString, int nSize, string lpFilename);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern uint GetCurrentThreadId();

    [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern IntPtr LoadLibrary(string lpLibName);

    [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

    [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern IntPtr GetProcAddress(IntPtr hModule, IntPtr lpProcName);

    [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool FreeLibrary(IntPtr hModule);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hReservedNull, LoadLibraryFlags dwFlags);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool EnumResourceNames(IntPtr hModule, string lpszType, Kernel32.EnumResNameProcDelegate lpEnumFunc, IntPtr lParam);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool EnumResourceNames(IntPtr hModule, RT dwID, Kernel32.EnumResNameProcDelegate lpEnumFunc, IntPtr lParam);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr FindResource(IntPtr hModule, IntPtr lpName, RT lpType);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern int SizeofResource(IntPtr hModule, IntPtr hResInfo);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResInfo);

    [DllImport("Kernel32.dll", SetLastError = true)]
    public static extern IntPtr LockResource(IntPtr hGlobal);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr UnLockResource(IntPtr hResData);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern uint FindPackagesByPackageFamily(string packageFamilyName, uint packageFilters, ref uint count, IntPtr packageFullnames, ref uint bufferLength, IntPtr buffer, IntPtr packageProperties);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern uint OpenPackageInfoByFullName(string packageFullName, uint reserved, IntPtr packageInfoReference);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern uint GetPackageInfo(IntPtr packageInfoReference, uint flags, ref uint bufferLength, IntPtr buffer, ref uint count);

    public static Delegate GetFunctionAddress(IntPtr dllModule, string functionName, Type t)
    {
      IntPtr procAddress = Kernel32.GetProcAddress(dllModule, functionName);
      if (procAddress == IntPtr.Zero)
        return (Delegate) null;
      return Marshal.GetDelegateForFunctionPointer(procAddress, t);
    }

    public static Delegate GetDelegateFromIntPtr(IntPtr address, Type t)
    {
      if (address == IntPtr.Zero)
        return (Delegate) null;
      return Marshal.GetDelegateForFunctionPointer(address, t);
    }

    public static Delegate GetDelegateFromIntPtr(int address, Type t)
    {
      if (address == 0)
        return (Delegate) null;
      return Marshal.GetDelegateForFunctionPointer(new IntPtr(address), t);
    }

    public delegate bool EnumResNameProcDelegate(IntPtr hModule, RT lpszType, IntPtr lpszName, IntPtr lParam);
  }
}
