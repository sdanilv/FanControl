// Decompiled with JetBrains decompiler
// Type: AsusWin32API.ServiceControl
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

namespace AsusWin32API
{
  public enum ServiceControl
  {
    Stop = 1,
    Pause = 2,
    Continue = 3,
    Interrogate = 4,
    Shutdown = 5,
    ParamChange = 6,
    NetBindAdd = 7,
    NetBindRemove = 8,
    NetBindEnable = 9,
    NetBindDisable = 10, // 0x0000000A
  }
}
