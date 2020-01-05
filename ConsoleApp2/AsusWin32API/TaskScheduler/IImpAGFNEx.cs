// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskScheduler.IImpAGFNEx
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsusWin32API.TaskScheduler
{
  [Guid("8B236864-ADDF-4C82-BA22-F3C1F5728E43")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  public interface IImpAGFNEx
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT GENERIC_IDENTIFY([In] IntPtr pData, [In, Out] ref uint dwResult);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT GENERIC_FUNCTION([In] IntPtr pData, [In, Out] ref uint dwResult);
  }
}
