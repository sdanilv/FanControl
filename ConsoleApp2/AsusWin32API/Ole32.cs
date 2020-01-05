// Decompiled with JetBrains decompiler
// Type: AsusWin32API.Ole32
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.InteropServices;

namespace AsusWin32API
{
  public static class Ole32
  {
    [DllImport("Ole32.dll", CharSet = CharSet.Unicode)]
    public static extern void CoInitializeEx(IntPtr pvReserved, CoInit coInit);

    [DllImport("Ole32.dll", CharSet = CharSet.Unicode)]
    public static extern void CoUninitialize();

    [DllImport("ole32.dll", PreserveSig = false)]
    public static extern void CoAllowSetForegroundWindow([MarshalAs(UnmanagedType.IUnknown)] object pUnk, IntPtr lpvReserved);

    [DllImport("ole32.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern uint CoCreateInstance([MarshalAs(UnmanagedType.LPStruct), In] Guid rclsid, IntPtr pUnkOuter, CLSCTX dwClsContext, [MarshalAs(UnmanagedType.LPStruct), In] Guid riid, out IntPtr ppv);

    [DllImport("oleaut32.dll", SetLastError = true)]
    public static extern void VariantInit(ref VARIANT pvarg);

    [DllImport("Ole32", SetLastError = true)]
    public static extern HRESULT CoInitializeEx(IntPtr pvReserved, uint dwCoInit);

    [DllImport("Ole32", SetLastError = true)]
    public static extern HRESULT CoCreateInstance(ref Guid rclsid, IntPtr pUnkOuter, CLSCTX dwClsContext, ref Guid riid, IntPtr ppv);

    [DllImport("Ole32", SetLastError = true)]
    public static extern HRESULT CoCreateInstance(ref Guid rclsid, IntPtr pUnkOuter, CLSCTX dwClsContext, ref Guid riid, out IntPtr ppv);
  }
}
