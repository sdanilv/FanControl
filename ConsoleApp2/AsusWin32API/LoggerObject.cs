// Decompiled with JetBrains decompiler
// Type: AsusWin32API.LoggerObject
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.IO;
using System.Text;

namespace AsusWin32API
{
  internal static class LoggerObject
  {
    private static int maxLogFileSize_ = 10485760;
    private static int maxLogFileNum_ = 5;
    public const int MB_SIZE = 1048576;

    private static int open_log_file()
    {
      try
      {
        if (!Directory.Exists(GlobalVariable.gLogDir))
          Directory.CreateDirectory(GlobalVariable.gLogDir);
        GlobalVariable.gLogStream = new FileStream(GlobalVariable.gLogFilePath, FileMode.Create, FileAccess.Write, FileShare.Read);
        GlobalVariable.gLogWriter = new StreamWriter((Stream) GlobalVariable.gLogStream, Encoding.UTF8);
      }
      catch (Exception ex)
      {
                ConsoleManager.showWindow(ex.Message);
                GlobalVariable.gLogWriter = (StreamWriter) null;
      }
      return GlobalVariable.gLogWriter == null ? -1 : 0;
    }

    private static int close_log_file()
    {
      if (GlobalVariable.gLogWriter != null)
      {
        GlobalVariable.gLogWriter.Close();
        GlobalVariable.gLogWriter = (StreamWriter) null;
        GlobalVariable.gLogStream.Close();
        GlobalVariable.gLogStream = (FileStream) null;
      }
      return 0;
    }

    private static void set_type(int _logType, bool _flag)
    {
      if (!GlobalVariable.gInit)
        return;
      if (_flag)
        GlobalVariable.gFlag |= _logType;
      else
        GlobalVariable.gFlag &= ~_logType;
    }

    private static string composeLogStr(int _logType, string _desc, int _errCode, string _className, string _funcName)
    {
      string empty = string.Empty;
      string str1 = string.Empty;
      DateTime now = DateTime.Now;
      int year = now.Year;
      int month = now.Month;
      int day = now.Day;
      int hour = now.Hour;
      int minute = now.Minute;
      int second = now.Second;
      int millisecond = now.Millisecond;
      switch (_logType)
      {
        case 1:
          str1 = "ERR";
          break;
        case 2:
          str1 = "WRN";
          break;
        case 4:
          str1 = "INF";
          break;
        case 8:
          str1 = "TRC";
          break;
        case 16:
          str1 = "DBG";
          break;
        case 32:
          str1 = "FTL";
          break;
      }
      string str2;
      if (1 == _logType || 16 == _logType || 32 == _logType)
        str2 = string.Format("[{0}] [{1:D4}-{2:D2}-{3:D2} {4:D2}:{5:D2}:{6:D2}.{7:D3}] {8}::{9} [err_code = {10}], {11}", (object) str1, (object) year, (object) month, (object) day, (object) hour, (object) minute, (object) second, (object) millisecond, (object) _className, (object) _funcName, (object) _errCode, (object) _desc);
      else
        str2 = string.Format("[{0}] [{1:D4}-{2:D2}-{3:D2} {4:D2}:{5:D2}:{6:D2}.{7:D3}] {8}::{9}, {10}", (object) str1, (object) year, (object) month, (object) day, (object) hour, (object) minute, (object) second, (object) millisecond, (object) _className, (object) _funcName, (object) _desc);
      return str2;
    }

    private static void backup_file()
    {
      LoggerObject.close_log_file();
      if (1 == LoggerObject.maxLogFileNum_)
      {
        try
        {
          File.Delete(GlobalVariable.gLogFilePath);
        }
        catch
        {
        }
      }
      else
      {
        string path = GlobalVariable.gLogDir + GlobalVariable.gModuleName + "_" + (LoggerObject.maxLogFileNum_ - 1).ToString() + ".log";
        if (File.Exists(path))
          File.Delete(path);
        for (int index = LoggerObject.maxLogFileNum_ - 2; index > 0; --index)
        {
          string str = GlobalVariable.gLogDir + GlobalVariable.gModuleName + "_" + index.ToString() + ".log";
          string destFileName = GlobalVariable.gLogDir + GlobalVariable.gModuleName + "_" + (index + 1).ToString() + ".log";
          if (File.Exists(str))
          {
            try
            {
              File.Move(str, destFileName);
            }
            catch
            {
            }
          }
        }
        string destFileName1 = GlobalVariable.gLogDir + GlobalVariable.gModuleName + "_" + 1.ToString() + ".log";
        try
        {
          File.Move(GlobalVariable.gLogFilePath, destFileName1);
        }
        catch
        {
        }
      }
      LoggerObject.open_log_file();
    }

    public static int init(string _moduleName, string _logDir, int _maxFileSizeInMB, int _maxLogFileNum)
    {
      if (_maxFileSizeInMB <= 0)
        _maxFileSizeInMB = 1;
      if (_maxFileSizeInMB > 1024)
        _maxFileSizeInMB = 1024;
      if (_maxLogFileNum <= 0)
        _maxLogFileNum = 1;
      lock (GlobalVariable.gLogLock)
      {
        GlobalVariable.gModuleName = _moduleName;
        if (Path.GetPathRoot(_logDir) == _logDir)
        {
          if (_logDir.Length == 2)
            _logDir += Path.DirectorySeparatorChar.ToString();
        }
        else
          _logDir = Path.GetDirectoryName(_logDir + Path.DirectorySeparatorChar.ToString()) + Path.DirectorySeparatorChar.ToString();
        GlobalVariable.gLogDir = _logDir;
        GlobalVariable.gLogFilePath = GlobalVariable.gLogDir + GlobalVariable.gModuleName + ".log";
        if (!GlobalVariable.gInit)
        {
          int num = LoggerObject.open_log_file();
          if (num != 0)
            return num;
          LoggerObject.maxLogFileSize_ = _maxFileSizeInMB * 1048576;
          LoggerObject.maxLogFileNum_ = _maxLogFileNum;
          GlobalVariable.gInit = true;
        }
      }
      return 0;
    }

    public static void close()
    {
      LoggerObject.close_log_file();
      GlobalVariable.gInit = false;
    }

    public static void enable(int logType)
    {
      LoggerObject.set_type(logType, true);
    }

    public static void disable(int logType)
    {
      LoggerObject.set_type(logType, false);
    }

    public static void log(int logType, string _desc, int _errCode, string _className, string _funcName)
    {
      if (!GlobalVariable.gInit || GlobalVariable.gLogWriter == null || (GlobalVariable.gFlag & logType) == 0)
        return;
      string str = LoggerObject.composeLogStr(logType, _desc, _errCode, _className, _funcName);
      lock (GlobalVariable.gLogLock)
      {
        if (!GlobalVariable.gInit)
          return;
        GlobalVariable.gLogWriter.WriteLine(str);
        GlobalVariable.gLogWriter.Flush();
        if (GlobalVariable.gLogWriter.BaseStream.Length < (long) LoggerObject.maxLogFileSize_)
          return;
        LoggerObject.backup_file();
      }
    }
  }
}
