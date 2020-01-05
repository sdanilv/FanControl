// Decompiled with JetBrains decompiler
// Type: AsusWin32API.Secur32
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System.Runtime.InteropServices;
using System.Text;

namespace AsusWin32API
{
  public static class Secur32
  {
    [DllImport("Secur32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool GetUserNameEx(int NameFormat, StringBuilder lpNameBuffer, ref uint lpnSize);
  }
}
