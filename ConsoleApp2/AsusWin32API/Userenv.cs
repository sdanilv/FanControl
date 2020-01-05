// Decompiled with JetBrains decompiler
// Type: AsusWin32API.Userenv
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.InteropServices;

namespace AsusWin32API
{
  public static class Userenv
  {
    [DllImport("userenv.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool CreateEnvironmentBlock(out IntPtr lpEnvironment, IntPtr hToken, bool bInherit);

    [DllImport("userenv.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool DestroyEnvironmentBlock(IntPtr lpEnvironment);
  }
}
