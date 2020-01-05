// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskScheduler.ITriggerCollection
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsusWin32API.TaskScheduler
{
  [Guid("85df5081-1b24-4f32-878a-d9d14df4cb77")]
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [ComImport]
  public interface ITriggerCollection
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Count(out int pCount);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Item(int index, out ITrigger ppTrigger);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get__NewEnum(out IntPtr ppEnum);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT Create(TASK_TRIGGER_TYPE2 type, out ITrigger ppTrigger);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT Remove(VARIANT index);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT Clear();
  }
}
