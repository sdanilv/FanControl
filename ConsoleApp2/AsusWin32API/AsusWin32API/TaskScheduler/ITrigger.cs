// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskScheduler.ITrigger
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsusWin32API.TaskScheduler
{
  [Guid("09941815-ea89-4b5b-89e0-2a773801fac3")]
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [ComImport]
  public interface ITrigger
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Type(out TASK_TRIGGER_TYPE2 pType);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Id(out string pId);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Id(string id);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Repetition(out IntPtr ppRepeat);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Repetition(IntPtr pRepeat);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_ExecutionTimeLimit(out string pTimeLimit);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_ExecutionTimeLimit(string timelimit);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_StartBoundary(out string pStart);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_StartBoundary(string start);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_EndBoundary(out string pEnd);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_EndBoundary(string end);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Enabled(out short pEnabled);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Enabled(short enabled);
  }
}
