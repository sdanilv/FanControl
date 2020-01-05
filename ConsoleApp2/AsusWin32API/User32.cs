// Decompiled with JetBrains decompiler
// Type: AsusWin32API.User32
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AsusWin32API
{
  public static class User32
  {
    public static uint SW_HIDE = 0;
    public static uint SW_SHOW = 5;
    public static int GWL_EXSTYLE = -20;
    public static int WS_EX_TOOLWINDOW = 128;
    public static int WS_EX_APPWINDOW = 262144;
    public static short SWP_NOMOVE = 2;
    public static short SWP_NOSIZE = 1;
    public static short SWP_NOZORDER = 4;
    public static int SWP_SHOWWINDOW = 64;
    public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
    public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
    public static readonly IntPtr HWND_TOP = new IntPtr(0);
    public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
    public static int WM_DEVICECHANGE = 537;
    public static int DBT_DEVICEARRIVAL = 32768;
    public static int DBT_DEVICEREMOVECOMPLETE = 32772;
    public static int DBT_DEVTYP_DEVICEINTERFACE = 5;
    public static int DEVICE_NOTIFY_WINDOW_HANDLE = 0;
    public static int DBT_DEVICEREMOVEPENDING = 32771;
    public static Guid GUID_ACDC_POWER_SOURCE = new Guid(1564383833U, (ushort) 59861, (ushort) 19200, (byte) 166, (byte) 189, byte.MaxValue, (byte) 52, byte.MaxValue, (byte) 81, (byte) 101, (byte) 72);
    public static Guid GUID_BATTERY_PERCENTAGE_REMAINING = new Guid(2813165633U, (ushort) 46170, (ushort) 19630, (byte) 135, (byte) 163, (byte) 238, (byte) 203, (byte) 180, (byte) 104, (byte) 169, (byte) 225);
    public static Guid GUID_POWERSCHEME_PERSONALITY = new Guid(610108737, (short) 14659, (short) 17442, (byte) 176, (byte) 37, (byte) 19, (byte) 167, (byte) 132, (byte) 246, (byte) 121, (byte) 183);
    public static Guid GUID_VIDEO_ADAPTIVE_DISPLAY_BRIGHTNESS = new Guid(4225346150U, (ushort) 38227, (ushort) 16535, (byte) 186, (byte) 68, (byte) 237, (byte) 110, (byte) 157, (byte) 101, (byte) 234, (byte) 184);
    public const int WS_SHOWNORMAL = 1;
    public const int WM_COPYDATA = 74;
    public const int DEVICE_NOTIFY_SERVICE_HANDLE = 1;
    public const int DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 4;
    public const int DBT_DEVTYP_HANDLE = 6;
    public const int DBT_DEVICEQUERYREMOVE = 32769;
    public const int WM_KEYUP = 257;
    public const int WM_KEYDOWN = 256;
    public const int WM_SYSKEYDOWN = 260;
    public const int WM_SYSKEYUP = 261;
    public const int WH_KEYBOARD_LL = 13;
    public const int VK_RETURN = 13;
    public const int VK_LEFT = 37;
    public const int VK_RIGHT = 39;
    public const int WM_POWERBROADCAST = 536;
    public const int PBT_POWERSETTINGCHANGE = 32787;
    public const int PBT_APMRESUMEAUTOMATIC = 18;
    public const int PBT_APMRESUMECRITICAL = 6;
    public const int PBT_APMRESUMESUSPEND = 7;
    public const int PBT_APMQUERYSUSPEND = 0;
    public const int PBT_APMSUSPEND = 4;

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);

    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern uint RegisterWindowMessage(string lpString);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder str, int maxCount);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr UnregisterDeviceNotification(IntPtr hRecipient, IntPtr NotificationFilter, int Flags);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, IntPtr NotificationFilter, int Flags);

    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, ref CopyDataStruct lParam);

    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, ref CopyDataStruct lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SendMessageTimeout(IntPtr windowHandle, int Msg, IntPtr wParam, ref CopyDataStruct lParam, SendMessageTimeoutFlags flags, uint timeout, out IntPtr result);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr FindWindow(IntPtr lpClassName, string lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowLong(IntPtr hwnd, int nIndex);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool InSendMessage();

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool ReplyMessage(IntPtr nRelust);

    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool DestroyIcon(IntPtr IconHandle);

    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool ChangeWindowMessageFilterEx(IntPtr hWnd, uint msg, ChangeWindowMessageFilterExAction action, ref CHANGEFILTERSTRUCT changeInfo);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool BringWindowToTop(IntPtr hWnd);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool BringWindowToTop(HandleRef hWnd);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SetFocus(IntPtr hwnd);

    [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

    [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int processId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern uint UnregisterDeviceNotification(IntPtr hHandle);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool UnregisterPowerSettingNotification(IntPtr Handle);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int SetWindowsHookEx(int idHook, User32.HookProc lpfn, IntPtr hInstance, int threadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool UnhookWindowsHookEx(int idHook);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr RegisterPowerSettingNotification(IntPtr hRecipient, ref Guid PowerSettingGuid, int Flags);

    public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
  }
}
