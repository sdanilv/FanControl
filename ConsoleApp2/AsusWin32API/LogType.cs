// Decompiled with JetBrains decompiler
// Type: AsusWin32API.LogType
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

namespace AsusWin32API
{
  public class LogType
  {
    public const int ERROR_LOG = 1;
    public const int WARNING_LOG = 2;
    public const int INFO_LOG = 4;
    public const int TRACE_LOG = 8;
    public const int DEBUG_LOG = 16;
    public const int FATAL_LOG = 32;
    public const int ALL_LOG = -1;
  }
}
