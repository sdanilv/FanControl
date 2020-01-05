// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TASK_TRIGGER_TYPE2
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

namespace AsusWin32API
{
  public enum TASK_TRIGGER_TYPE2 : uint
  {
    EVENT = 0,
    TIME = 1,
    DAILY = 2,
    WEEKLY = 3,
    MONTHLY = 4,
    MONTHLYDOW = 5,
    IDLE = 6,
    REGISTRATION = 7,
    BOOT = 8,
    LOGON = 9,
    SESSION_STATE_CHANGE = 11, // 0x0000000B
  }
}
