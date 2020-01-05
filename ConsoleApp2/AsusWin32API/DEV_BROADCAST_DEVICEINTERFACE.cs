// Decompiled with JetBrains decompiler
// Type: AsusWin32API.DEV_BROADCAST_DEVICEINTERFACE
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System.Runtime.InteropServices;

namespace AsusWin32API
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  public struct DEV_BROADCAST_DEVICEINTERFACE
  {
    public int dbcc_size;
    public int dbcc_devicetype;
    public int dbcc_reserved;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.U1)]
    public byte[] dbcc_classguid;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
    public char[] dbcc_name;
  }
}
