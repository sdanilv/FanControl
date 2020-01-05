// Decompiled with JetBrains decompiler
// Type: AsusWin32API.DiGetClassFlags
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;

namespace AsusWin32API
{
  [Flags]
  public enum DiGetClassFlags : uint
  {
    DIGCF_DEFAULT = 1,
    DIGCF_PRESENT = 2,
    DIGCF_ALLCLASSES = 4,
    DIGCF_PROFILE = 8,
    DIGCF_DEVICEINTERFACE = 16, // 0x00000010
  }
}
