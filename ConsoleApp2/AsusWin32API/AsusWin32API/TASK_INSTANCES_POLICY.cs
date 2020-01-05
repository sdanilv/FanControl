// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TASK_INSTANCES_POLICY
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

namespace AsusWin32API
{
  public enum TASK_INSTANCES_POLICY : uint
  {
    TASK_INSTANCES_PARALLEL,
    TASK_INSTANCES_QUEUE,
    TASK_INSTANCES_IGNORE_NEW,
    TASK_INSTANCES_STOP_EXISTING,
  }
}
