// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskScheduler.ITaskDefinition
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsusWin32API.TaskScheduler
{
  [Guid("f5bc8fc5-536d-4f77-b852-fbc1356fdeb6")]
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [ComImport]
  public interface ITaskDefinition
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_RegistrationInfo(out IRegistrationInfo ppRegistrationInfo);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_RegistrationInfo(out IRegistrationInfo pRegistrationInfo);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Triggers(out ITriggerCollection ppTriggers);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Triggers([In] ITriggerCollection pTriggers);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Settings(out ITaskSettings ppSettings);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Settings([In] ITaskSettings pSettings);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Data(out string pData);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Data([In] string data);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Principal(out IPrincipal ppPrincipal);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Principal([In] IntPtr pPrincipal);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Actions(out IActionCollection ppActions);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Actions([In] IActionCollection pActions);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_XmlText(out string pXml);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_XmlText([In] string xml);
  }
}
