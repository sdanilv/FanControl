// Decompiled with JetBrains decompiler
// Type: AsusWin32API.LogWriter`1
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

namespace AsusWin32API
{
  public static class LogWriter<T> where T : class
  {
    private static string name_ = typeof (T).Name;

    public static void log_error(string _desc, int _errorCode, string _funcname)
    {
      Logger.log_error(_desc, _errorCode, LogWriter<T>.name_, _funcname);
    }

    public static void log_info(string _desc, string _funcname)
    {
      Logger.log_info(_desc, LogWriter<T>.name_, _funcname);
    }

    public static void log_debug(string _desc, int _errorCode, string _funcname)
    {
      Logger.log_debug(_desc, _errorCode, LogWriter<T>.name_, _funcname);
    }

    public static void log_fatal(string _desc, int _errorCode, string _funcname)
    {
      Logger.log_fatal(_desc, _errorCode, LogWriter<T>.name_, _funcname);
    }

    public static void log_trace(string _desc, string _funcname)
    {
      Logger.log_trace(_desc, LogWriter<T>.name_, _funcname);
    }

    public static void log_warning(string _desc, string _funcname)
    {
      Logger.log_warning(_desc, LogWriter<T>.name_, _funcname);
    }
  }
}
