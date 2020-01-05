// Decompiled with JetBrains decompiler
// Type: AsusWin32API.ServiceAccessRights
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

namespace AsusWin32API
{
  public enum ServiceAccessRights
  {
    QueryConfig = 1,
    ChangeConfig = 2,
    QueryStatus = 4,
    EnumerateDependants = 8,
    Start = 16, // 0x00000010
    Stop = 32, // 0x00000020
    PauseContinue = 64, // 0x00000040
    Interrogate = 128, // 0x00000080
    UserDefinedControl = 256, // 0x00000100
    Delete = 65536, // 0x00010000
    StandardRightsRequired = 983040, // 0x000F0000
    AllAccess = 983551, // 0x000F01FF
  }
}
