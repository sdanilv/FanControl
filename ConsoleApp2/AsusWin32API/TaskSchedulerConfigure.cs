﻿// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskSchedulerConfigure
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System.Runtime.InteropServices;

namespace AsusWin32API
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  public struct TaskSchedulerConfigure
  {
    public string TaskName;
    public string Parameter;
    public string AuthorName;
    public string TriggerId;
    public string DelayTime;
    public string FullPathOfExeFile;
    public string Builtin;
    public TASK_RUNLEVEL_TYPE runlevel;
  }
}
