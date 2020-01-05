// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskScheduler.IActionCollection
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsusWin32API.TaskScheduler
{
  [Guid("02820E19-7B98-4ed2-B2E8-FDCCCEFF619B")]
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [ComImport]
  public interface IActionCollection
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Count(out int pCount);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Item(int index, out IAction ppAction);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get__NewEnum(out IntPtr ppEnum);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_XmlText(out string pText);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_XmlText(string text);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT Create(TASK_ACTION_TYPE type, out IAction ppAction);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT Remove(VARIANT index);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT Clear();

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Context(out string pContext);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Context(string context);
  }
}
