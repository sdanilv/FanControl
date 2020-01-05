// Decompiled with JetBrains decompiler
// Type: AsusWin32API.ScmAccessRights
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

namespace AsusWin32API
{
  public enum ScmAccessRights
  {
    Connect = 1,
    CreateService = 2,
    EnumerateService = 4,
    Lock = 8,
    QueryLockStatus = 16, // 0x00000010
    ModifyBootConfig = 32, // 0x00000020
    StandardRightsRequired = 983040, // 0x000F0000
    AllAccess = 983103, // 0x000F003F
  }
}
