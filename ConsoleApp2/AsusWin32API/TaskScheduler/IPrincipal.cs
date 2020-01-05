// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskScheduler.IPrincipal
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsusWin32API.TaskScheduler
{
  [Guid("D98D51E5-C9B4-496a-A9C1-18980261CF0F")]
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [ComImport]
  public interface IPrincipal
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Id(out string pId);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Id(string Id);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_DisplayName(out string pName);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_DisplayName(string name);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_UserId(out string pUser);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_UserId(string user);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_LogonType(out TASK_LOGON_TYPE pLogon);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_LogonType(TASK_LOGON_TYPE logon);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_GroupId(out string pGroup);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_GroupId(string group);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_RunLevel(out TASK_RUNLEVEL_TYPE pRunLevel);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_RunLevel(TASK_RUNLEVEL_TYPE runLevel);
  }
}
