// Decompiled with JetBrains decompiler
// Type: AsusWin32API.SnapshotFlags
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

namespace AsusWin32API
{
  public enum SnapshotFlags : uint
  {
    HeapList = 1,
    Process = 2,
    Thread = 4,
    Module = 8,
    All = 15, // 0x0000000F
    Module32 = 16, // 0x00000010
    NoHeaps = 1073741824, // 0x40000000
    Inherit = 2147483648, // 0x80000000
  }
}
