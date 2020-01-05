// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskScheduler.ITaskService
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsusWin32API.TaskScheduler
{
  [Guid("2faba4c7-4da9-4013-9697-20cc3fd40f85")]
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [ComImport]
  public interface ITaskService
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT GetFolder([In] string path, out ITaskFolder ppFolder);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT GetRunningTasks([In] int flags, [Out] IntPtr retVal);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT NewTask([In] uint flags, out ITaskDefinition ppDefinition);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT Connect([In, Optional] object serverName, [In, Optional] object user, [In, Optional] object domain, [In, Optional] object password);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Connected(out ushort pConnected);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_TargetServer(out IntPtr pServer);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_ConnectedUser(out IntPtr pUser);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_ConnectedDomain(out IntPtr pDomain);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_HighestVersion(out uint pVersion);
  }
}
