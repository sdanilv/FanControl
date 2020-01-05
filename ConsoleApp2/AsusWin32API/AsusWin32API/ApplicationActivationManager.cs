// Decompiled with JetBrains decompiler
// Type: AsusWin32API.ApplicationActivationManager
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsusWin32API
{
  [Guid("45BA127D-10A8-46EA-8AB7-56EA9078943C")]
  [ComImport]
  public class ApplicationActivationManager : IApplicationActivationManager
  {
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public extern IntPtr ActivateApplication([In] string appUserModelId, [In] string arguments, [In] ActivateOptions options, out uint processId);

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public extern IntPtr ActivateForFile([In] string appUserModelId, [In] IntPtr itemArray, [In] string verb, out uint processId);

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public extern IntPtr ActivateForProtocol([In] string appUserModelId, [In] IntPtr itemArray, out uint processId);

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public extern ApplicationActivationManager();
  }
}
