// Decompiled with JetBrains decompiler
// Type: AsusWin32API.PACKAGE_INFO
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;

namespace AsusWin32API
{
  public struct PACKAGE_INFO
  {
    public uint reserved;
    public uint flags;
    public IntPtr path;
    public IntPtr packageFullName;
    public IntPtr packageFamilyName;
    public PACKAGE_ID packageId;
  }
}
