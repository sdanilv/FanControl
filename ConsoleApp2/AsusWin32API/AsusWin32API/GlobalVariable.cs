// Decompiled with JetBrains decompiler
// Type: AsusWin32API.GlobalVariable
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System.IO;

namespace AsusWin32API
{
  internal static class GlobalVariable
  {
    public static bool gInit = false;
    public static int gFlag = 0;
    public static object gLogLock = new object();
    public static FileStream gLogStream = (FileStream) null;
    public static StreamWriter gLogWriter = (StreamWriter) null;
    public static string gModuleName = string.Empty;
    public static string gLogDir = string.Empty;
    public static string gLogFilePath = string.Empty;
  }
}
