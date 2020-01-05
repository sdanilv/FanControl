// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskScheduler.IAction
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsusWin32API.TaskScheduler
{
  [Guid("BAE54997-48B1-4cbe-9965-D6BE263EBEA4")]
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [ComImport]
  public interface IAction
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Id(out string pId);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Id(string Id);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Type(out TASK_ACTION_TYPE pType);
  }
}
