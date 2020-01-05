// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskScheduler.IIdleSettings
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System.Runtime.InteropServices;

namespace AsusWin32API.TaskScheduler
{
  [Guid("84594461-0053-4342-A8FD-088FABF11F32")]
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [ComImport]
  public interface IIdleSettings
  {
    HRESULT get_IdleDuration(out string pDelay);

    HRESULT put_IdleDuration(string delay);

    HRESULT get_WaitTimeout(out string pTimeout);

    HRESULT put_WaitTimeout(string timeout);

    HRESULT get_StopOnIdleEnd(out ushort pStop);

    HRESULT put_StopOnIdleEnd(ushort stop);

    HRESULT get_RestartOnIdle(out ushort pRestart);

    HRESULT put_RestartOnIdle(ushort restart);
  }
}
