// Decompiled with JetBrains decompiler
// Type: AsusWin32API.VT
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

namespace AsusWin32API
{
  public enum VT : ushort
  {
    EMPTY = 0,
    NULL = 1,
    I2 = 2,
    I4 = 3,
    R4 = 4,
    R8 = 5,
    CY = 6,
    DATE = 7,
    BSTR = 8,
    DISPATCH = 9,
    ERROR = 10, // 0x000A
    BOOL = 11, // 0x000B
    VARIANT = 12, // 0x000C
    UNKNOWN = 13, // 0x000D
    UI1 = 17, // 0x0011
  }
}
