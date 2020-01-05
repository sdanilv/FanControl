// Decompiled with JetBrains decompiler
// Type: AsusWin32API.AGFN_BUFFER
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System.Runtime.InteropServices;

namespace AsusWin32API
{
  [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
  public struct AGFN_BUFFER
  {
    public AGFN_HDR Header;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4083)]
    public byte[] Reserved;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
    public byte[] ErrorCode;
  }
}
