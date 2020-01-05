// Decompiled with JetBrains decompiler
// Type: AsusWin32API.IShellLinkW
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AsusWin32API
{
  [Guid("000214F9-0000-0000-C000-000000000046")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  public interface IShellLinkW
  {
    uint GetPath([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszFile, int cchMaxPath, IntPtr pfd, uint fFlags);

    uint GetIDList(out IntPtr ppidl);

    uint SetIDList(IntPtr pidl);

    uint GetDescription([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszFile, int cchMaxName);

    uint SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);

    uint GetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszDir, int cchMaxPath);

    uint SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);

    uint GetArguments([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszArgs, int cchMaxPath);

    uint SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

    uint GetHotKey(out short wHotKey);

    uint SetHotKey(short wHotKey);

    uint GetShowCmd(out uint iShowCmd);

    uint SetShowCmd(uint iShowCmd);

    uint GetIconLocation([MarshalAs(UnmanagedType.LPWStr)] out StringBuilder pszIconPath, int cchIconPath, out int iIcon);

    uint SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);

    uint SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, uint dwReserved);

    uint Resolve(IntPtr hwnd, uint fFlags);

    uint SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
  }
}
