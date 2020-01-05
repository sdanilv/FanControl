// Decompiled with JetBrains decompiler
// Type: AsusWin32API.Logger
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

namespace AsusWin32API
{
  public static class Logger
  {
    public static int init(string _moduleName, string _logDir)
    {
      return Logger.init(_moduleName, _logDir, 10, 5);
    }

    public static int init(string _moduleName, string _logDir, int _maxFileSizeInMB, int _maxLogFileNum)
    {
      return LoggerObject.init(_moduleName, _logDir, _maxFileSizeInMB, _maxLogFileNum);
    }

    public static void log_error(string _desc, int _errCode, string _className, string _funcName)
    {
      LoggerObject.log(1, _desc, _errCode, _className, _funcName);
    }

    public static void log_debug(string _desc, int _errCode, string _className, string _funcName)
    {
      LoggerObject.log(16, _desc, _errCode, _className, _funcName);
    }

    public static void log_fatal(string _desc, int _errCode, string _className, string _funcName)
    {
      LoggerObject.log(32, _desc, _errCode, _className, _funcName);
    }

    public static void log_info(string _desc, string _className, string _funcName)
    {
      LoggerObject.log(4, _desc, 0, _className, _funcName);
    }

    public static void log_warning(string _desc, string _className, string _funcName)
    {
      LoggerObject.log(2, _desc, 0, _className, _funcName);
    }

    public static void log_trace(string _desc, string _className, string _funcName)
    {
      LoggerObject.log(8, _desc, 0, _className, _funcName);
    }

    public static void close()
    {
      LoggerObject.close();
    }

    public static void enable(int _logType)
    {
      LoggerObject.enable(_logType);
    }

    public static void disable(int _logType)
    {
      LoggerObject.disable(_logType);
    }
  }
}
