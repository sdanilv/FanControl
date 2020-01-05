// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskScheduler.IRegisteredTask
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsusWin32API.TaskScheduler
{
  [Guid("9c86f320-dee3-4dd1-b972-a303f26b061e")]
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [ComImport]
  public interface IRegisteredTask
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Name(out string pName);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Path(out string pPath);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_State(out IntPtr pState);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Enabled(out ushort pEnabled);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Enabled(ushort enabled);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT Run(VARIANT param, out IntPtr ppRunningTask);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT RunEx(VARIANT param, int flags, int sessionID, string user, out IntPtr ppRunningTask);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT GetInstances(int flags, out IntPtr ppRunningTasks);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_LastRunTime(out IntPtr pLastRunTime);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_LastTaskResult(out int pLastTaskResult);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_NumberOfMissedRuns(out int pNumberOfMissedRuns);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_NextRunTime(out IntPtr pNextRunTime);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Definition(out IntPtr ppDefinition);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Xml(out string pXml);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT GetSecurityDescriptor(int securityInformation, out string pSddl);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT SetSecurityDescriptor(string sddl, int flags);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT Stop(int flags);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT GetRunTimes(SYSTEMTIME pstStart, SYSTEMTIME pstEnd, [In, Out] ref uint pCount, out IntPtr pRunTimes);
  }
}
