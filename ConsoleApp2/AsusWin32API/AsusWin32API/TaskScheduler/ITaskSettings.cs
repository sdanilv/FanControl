// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskScheduler.ITaskSettings
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsusWin32API.TaskScheduler
{
  [Guid("8FD4711D-2D02-4c8c-87E3-EFF699DE127E")]
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [ComImport]
  public interface ITaskSettings
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_AllowDemandStart(out ushort pAllowDemandStart);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_AllowDemandStart(ushort allowDemandStart);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_RestartInterval(out string pRestartInterval);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_RestartInterval(string restartInterval);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_RestartCount(out int pRestartCount);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_RestartCount(int restartCount);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_MultipleInstances(out TASK_INSTANCES_POLICY pPolicy);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_MultipleInstances(TASK_INSTANCES_POLICY policy);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_StopIfGoingOnBatteries(out ushort pStopIfOnBatteries);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_StopIfGoingOnBatteries(ushort stopIfOnBatteries);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_DisallowStartIfOnBatteries(out ushort pDisallowStart);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_DisallowStartIfOnBatteries(ushort disallowStart);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_AllowHardTerminate(out ushort pAllowHardTerminate);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_AllowHardTerminate(ushort allowHardTerminate);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_StartWhenAvailable(out ushort pStartWhenAvailable);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_StartWhenAvailable(ushort startWhenAvailable);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_XmlText(out string pText);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_XmlText(string text);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_RunOnlyIfNetworkAvailable(out ushort pRunOnlyIfNetworkAvailable);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_RunOnlyIfNetworkAvailable(ushort runOnlyIfNetworkAvailable);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_ExecutionTimeLimit(out string pExecutionTimeLimit);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_ExecutionTimeLimit(string executionTimeLimit);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Enabled(out ushort pEnabled);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Enabled(ushort enabled);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_DeleteExpiredTaskAfter(out string pExpirationDelay);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_DeleteExpiredTaskAfter(string expirationDelay);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Priority(out int pPriority);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Priority(int priority);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Compatibility(out IntPtr pCompatLevel);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Compatibility(IntPtr compatLevel);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Hidden(out ushort pHidden);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Hidden(ushort hidden);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_IdleSettings(out IIdleSettings ppIdleSettings);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_IdleSettings(IIdleSettings pIdleSettings);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_RunOnlyIfIdle(out ushort pRunOnlyIfIdle);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_RunOnlyIfIdle(ushort runOnlyIfIdle);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_WakeToRun(out ushort pWake);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_WakeToRun(ushort wake);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_NetworkSettings(out IntPtr ppNetworkSettings);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_NetworkSettings(IntPtr pNetworkSettings);
  }
}
