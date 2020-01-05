// Decompiled with JetBrains decompiler
// Type: AsusWin32API.Advapi32
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AsusWin32API
{
  public static class Advapi32
  {
    public static uint KEY_WRITE = 131078;
    public static uint KEY_QUERY_VALUE = 1;
    public static uint KEY_NOTIFY = 16;
    public static readonly IntPtr HKEY_CURRENT_USER = new IntPtr(-2147483647);
    public static readonly IntPtr HKEY_LOCAL_MACHINE = new IntPtr(-2147483646);
    public static int SERVICE_WIN32_OWN_PROCESS = 16;
    public static int SERVICE_KERNEL_DRIVER = 1;
    public static int NO_ERROR = 0;
    public static int ERROR_INSUFFICIENT_BUFFER = 122;
    public static int ERROR_INVALID_FLAGS = 1004;
    public static int ANYSIZE_ARRAY = 1;
    public static string SE_RESTORE_NAME = "SeRestorePrivilege";
    public static string SE_BACKUP_NAME = "SeBackupPrivilege";
    public const int GENERIC_ALL_ACCESS = 268435456;
    public const int STARTF_USESHOWWINDOW = 1;
    public const int STARTF_FORCEONFEEDBACK = 64;
    public const uint CREATE_UNICODE_ENVIRONMENT = 1024;
    public const uint SE_PRIVILEGE_ENABLED_BY_DEFAULT = 1;
    public const uint SE_PRIVILEGE_ENABLED = 2;
    public const uint SE_PRIVILEGE_REMOVED = 4;
    public const uint SE_PRIVILEGE_USED_FOR_ACCESS = 2147483648;
    public const uint STANDARD_RIGHTS_REQUIRED = 983040;
    public const uint STANDARD_RIGHTS_READ = 131072;
    public const uint TOKEN_ASSIGN_PRIMARY = 1;
    public const uint TOKEN_DUPLICATE = 2;
    public const uint TOKEN_IMPERSONATE = 4;
    public const uint TOKEN_QUERY = 8;
    public const uint TOKEN_QUERY_SOURCE = 16;
    public const uint TOKEN_ADJUST_PRIVILEGES = 32;
    public const uint TOKEN_ADJUST_GROUPS = 64;
    public const uint TOKEN_ADJUST_DEFAULT = 128;
    public const uint TOKEN_ADJUST_SESSIONID = 256;
    public const uint TOKEN_READ = 131080;
    public const uint TOKEN_ALL_ACCESS = 983551;
    public const uint READ_CONTROL = 131072;
    public const uint STANDARD_RIGHTS_WRITE = 131072;
    public const uint TOKEN_WRITE = 131296;
    public const int SERVICE_CONFIG_DESCRIPTION = 1;
    public const int SERVICE_CONFIG_FAILURE_ACTIONS = 2;
    public const int SERVICE_NO_CHANGE = -1;
    public const int ERROR_ACCESS_DENIED = 5;
    public const int SERVICE_CONTROL_STOP = 1;
    public const int SERVICE_CONTROL_DEVICEEVENT = 11;
    public const int SERVICE_CONTROL_SHUTDOWN = 5;
    public const int SERVICE_CONTROL_PAUSE = 2;
    public const int SERVICE_CONTROL_CONTINUE = 3;
    public const int SERVICE_CONTROL_POWEREVENT = 13;
    public const int SERVICE_CONTROL_SESSIONCHANGE = 14;

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool ChangeServiceConfig(IntPtr hService, uint nServiceType, uint nStartType, uint nErrorControl, string lpBinaryPathName, string lpLoadOrderGroup, IntPtr lpdwTagId, string lpDependencies, string lpServiceStartName, string lpPassword, string lpDisplayName);

    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool ChangeServiceConfig2(IntPtr hService, int dwInfoLevel, IntPtr lpInfo);

    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool GetUserName(StringBuilder sb, ref int length);

    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool DuplicateTokenEx(IntPtr hExistingToken, ACCESS_MASK dwDesiredAccess, ref SECURITY_ATTRIBUTES lpTokenAttributes, SECURITY_IMPERSONATION_LEVEL ImpersonationLevel, TOKEN_TYPE TokenType, out IntPtr phNewToken);

    [DllImport("advapi32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool ImpersonateLoggedOnUser(IntPtr hToken);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool CreateProcessAsUser(IntPtr hToken, string lpApplicationName, string lpCommandLine, ref SECURITY_ATTRIBUTES lpProcessAttributes, ref SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandles, CreateProcessFlags dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, ref PROCESS_INFORMATION lpProcessInformation);

    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool CreateProcessWithToken(IntPtr hToken, uint dwLogonFlags, string lpApplicationName, string lpCommandLine, uint dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, ref PROCESS_INFORMATION lpProcessInformation);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool CreateProcessAsUser(IntPtr hToken, string lpApplicationName, string lpCommandLine, ref IntPtr lpProcessAttributes, ref IntPtr lpThreadAttributes, bool bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, ref PROCESS_INFORMATION lpProcessInformation);

    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool RevertToSelf();

    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccess, out IntPtr TokenHandle);

    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool SetTokenInformation(IntPtr TokenHandle, TOKEN_INFORMATION_CLASS TokenInformationClass, ref uint TokenInformation, uint TokenInformationLength);

    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, out LUID lpLuid);

    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool LookupAccountSid(IntPtr lpSystemName, IntPtr Sid, StringBuilder lpName, ref uint cchName, StringBuilder ReferencedDomainName, ref uint cchReferencedDomainName, out SID_NAME_USE peUse);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool AdjustTokenPrivileges(IntPtr htok, bool disableAllPrivileges, ref TokPriv1Luid newState, int len, IntPtr prev, IntPtr relen);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int RegLoadKey(HKEY hKey, string lpSubKey, string lpFile);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int RegUnLoadKey(HKEY hKey, string lpSubKey);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int RegOpenKey(HKEY hKey, string lpSubKey, IntPtr phkResult);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool LookupAccountName(string lpSystemName, string lpAccountName, [MarshalAs(UnmanagedType.LPArray)] byte[] Sid, ref uint cbSid, StringBuilder ReferencedDomainName, ref uint cchReferencedDomainName, out SID_NAME_USE peUse);

    [DllImport("advapi32.dll")]
    public static extern IntPtr LockServiceDatabase(IntPtr hSCManager);

    [DllImport("advapi32.dll")]
    public static extern bool UnlockServiceDatabase(IntPtr hSCManager);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern IntPtr OpenSCManager(string machineName, string databaseName, ScmAccessRights dwDesiredAccess);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, ServiceAccessRights dwDesiredAccess);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern IntPtr CreateService(IntPtr hSCManager, string lpServiceName, string lpDisplayName, ServiceAccessRights dwDesiredAccess, int dwServiceType, ServiceBootFlag dwStartType, ServiceError dwErrorControl, string lpBinaryPathName, string lpLoadOrderGroup, IntPtr lpdwTagId, string lpDependencies, string lp, string lpPassword);

    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool CloseServiceHandle(IntPtr hSCObject);

    [DllImport("advapi32.dll")]
    public static extern int QueryServiceStatus(IntPtr hService, SERVICE_STATUS lpServiceStatus);

    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool DeleteService(IntPtr hService);

    [DllImport("advapi32.dll")]
    public static extern int ControlService(IntPtr hService, ServiceControl dwControl, SERVICE_STATUS lpServiceStatus);

    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern int StartService(IntPtr hService, int dwNumServiceArgs, int lpServiceArgVectors);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int RegOpenKeyEx(IntPtr hKey, string subKey, uint options, uint samDesired, out IntPtr phkResult);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int RegNotifyChangeKeyValue(IntPtr hKey, bool bWatchSubtree, int dwNotifyFilter, SafeWaitHandle hEvent, bool fAsynchronous);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int RegCloseKey(IntPtr hKey);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern IntPtr FreeSid(IntPtr pSid);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool CheckTokenMembership(IntPtr TokenHandle, IntPtr SidToCheck, out bool IsMember);

    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool AllocateAndInitializeSid(ref SidIdentifierAuthority pIdentifierAuthority, byte nSubAuthorityCount, int dwSubAuthority0, int dwSubAuthority1, int dwSubAuthority2, int dwSubAuthority3, int dwSubAuthority4, int dwSubAuthority5, int dwSubAuthority6, int dwSubAuthority7, out IntPtr pSid);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int RegCreateKeyEx(IntPtr hKey, string subKey, uint Reserved, string lpClass, uint options, uint samDesired, uint lpSecurityAttributes, ref IntPtr phkResult, ref uint lpdwDisposition);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int RegSetValueEx(IntPtr hKey, string lpValueName, int Reserved, RegistryValueKind dwType, IntPtr lpData, int cbData);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int RegQueryValueEx(IntPtr hKey, string lpValueName, int Reserved, out RegistryValueKind dwType, IntPtr lpData, ref int cbData);

    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern IntPtr RegisterServiceCtrlHandlerEx(string lpServiceName, Advapi32.ServiceControlHandlerEx cbex, IntPtr context);

    public delegate int ServiceControlHandlerEx(int control, int eventType, IntPtr eventData, IntPtr context);
  }
}
