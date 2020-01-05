// Decompiled with JetBrains decompiler
// Type: AsusWin32API.SERVICE_FAILURE_ACTIONS
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.InteropServices;

namespace AsusWin32API
{
  public struct SERVICE_FAILURE_ACTIONS
  {
    public uint dwResetPeriod;
    [MarshalAs(UnmanagedType.LPTStr)]
    public string lpRebootMsg;
    [MarshalAs(UnmanagedType.LPTStr)]
    public string lpCommand;
    public int cActions;
    public IntPtr lpsaActions;
  }
}
