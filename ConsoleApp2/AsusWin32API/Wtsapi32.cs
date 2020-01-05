// Decompiled with JetBrains decompiler
// Type: AsusWin32API.Wtsapi32
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.InteropServices;

namespace AsusWin32API
{
  public static class Wtsapi32
  {
    public const int WTS_CURRENT_SESSION = -1;
    public const int NOTIFY_FOR_THIS_SESSION = 0;
    public const int NOTIFY_FOR_ALL_SESSIONS = 1;
    public const int WM_WTSSESSION_CHANGE = 689;
    public const int WTS_CONSOLE_CONNECT = 1;
    public const int WTS_CONSOLE_DISCONNECT = 2;
    public const int WTS_SESSION_LOGON = 5;
    public const int WTS_SESSION_LOGOFF = 6;
    public const int WTS_SESSION_LOCK = 7;
    public const int WTS_SESSION_UNLOCK = 8;

    [DllImport("wtsapi32.dll", SetLastError = true)]
    public static extern bool WTSRegisterSessionNotification(IntPtr hWnd, [MarshalAs(UnmanagedType.U4)] int dwFlags);

    [DllImport("Wtsapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool WTSQuerySessionInformation(IntPtr hServer, int sessionId, WTS_INFO_CLASS wtsInfoClass, out IntPtr ppBuffer, out int pBytesReturned);

    [DllImport("Wtsapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern void WTSFreeMemory(IntPtr pointer);

    [DllImport("wtsapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool WTSQueryUserToken(uint sessionId, out IntPtr Token);

    [DllImport("Wtsapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool WTSQuerySessionInformation(IntPtr hServer, int sessionId, WTS_INFO_CLASS wtsInfoClass, out IntPtr ppBuffer, out uint pBytesReturned);

    [DllImport("wtsapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int WTSEnumerateSessions(IntPtr hServer, [MarshalAs(UnmanagedType.U4)] int Reserved, [MarshalAs(UnmanagedType.U4)] int Version, ref IntPtr ppSessionInfo, [MarshalAs(UnmanagedType.U4)] ref int pCount);

    [DllImport("wtsapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr WTSOpenServer([MarshalAs(UnmanagedType.LPStr)] string pServerName);

    [DllImport("wtsapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern void WTSCloseServer(IntPtr hServer);
  }
}
