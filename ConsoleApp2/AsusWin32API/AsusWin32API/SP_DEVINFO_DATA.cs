// Decompiled with JetBrains decompiler
// Type: AsusWin32API.SP_DEVINFO_DATA
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;

namespace AsusWin32API
{
  public struct SP_DEVINFO_DATA
  {
    public uint cbSize;
    public Guid classGuid;
    public uint devInst;
    public IntPtr reserved;
  }
}
