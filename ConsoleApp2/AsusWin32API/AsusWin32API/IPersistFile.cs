// Decompiled with JetBrains decompiler
// Type: AsusWin32API.IPersistFile
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System.Runtime.InteropServices;
using System.Text;

namespace AsusWin32API
{
  [Guid("0000010b-0000-0000-C000-000000000046")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  public interface IPersistFile
  {
    uint GetCurFile([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszFile);

    uint IsDirty();

    uint Load([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, [MarshalAs(UnmanagedType.U4)] STGM dwMode);

    uint Save([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, bool fRemember);

    uint SaveCompleted([MarshalAs(UnmanagedType.LPWStr)] string pszFileName);
  }
}
