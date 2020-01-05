// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TASK_CREATION
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

namespace AsusWin32API
{
  public enum TASK_CREATION
  {
    VALIDATE_ONLY = 1,
    CREATE = 2,
    UPDATE = 4,
    CREATE_OR_UPDATE = 6,
    DISABLE = 8,
    DONT_ADD_PRINCIPAL_ACE = 16, // 0x00000010
    IGNORE_REGISTRATION_TRIGGERS = 32, // 0x00000020
  }
}
