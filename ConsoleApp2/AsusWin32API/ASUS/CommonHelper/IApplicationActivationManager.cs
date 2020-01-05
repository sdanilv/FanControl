// Decompiled with JetBrains decompiler
// Type: ASUS.CommonHelper.IApplicationActivationManager
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.InteropServices;

namespace ASUS.CommonHelper
{
  [Guid("2e941141-7f97-4756-ba1d-9decde894a3d")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  internal interface IApplicationActivationManager
  {
    IntPtr ActivateApplication([In] string appUserModelId, [In] string arguments, [In] ActivateOptions options, out uint processId);

    IntPtr ActivateForFile([In] string appUserModelId, [In] IntPtr itemArray, [In] string verb, out uint processId);

    IntPtr ActivateForProtocol([In] string appUserModelId, [In] IntPtr itemArray, out uint processId);
  }
}
