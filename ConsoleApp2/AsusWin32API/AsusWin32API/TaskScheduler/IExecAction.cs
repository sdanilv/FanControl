// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskScheduler.IExecAction
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsusWin32API.TaskScheduler
{
  [Guid("4c3d624d-fd6b-49a3-b9b7-09cb3cd3f047")]
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [ComImport]
  public interface IExecAction
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Id(out string pId);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Id(string Id);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Type(out TASK_ACTION_TYPE pType);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Path(out string pPath);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Path(string path);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Arguments(out string pArgument);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Arguments(string argument);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_WorkingDirectory(out string pWorkingDirectory);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_WorkingDirectory(string workingDirectory);
  }
}
