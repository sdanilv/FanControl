// Decompiled with JetBrains decompiler
// Type: AsusWin32API.GFHelpers
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using AsusWin32API.TaskScheduler;
using System;
using System.Runtime.InteropServices;

namespace AsusWin32API
{
  public class GFHelpers
  {
    private Guid CLSID_ImpAGFNEx = new Guid("CE040E8E-719A-41CD-99C3-92BDA47D732D");
    private Guid IID_IImpAGFNEx = new Guid("8B236864-ADDF-4C82-BA22-F3C1F5728E43");

    public bool InitialGenericFunction(ref uint dwError)
    {
      bool flag = false;
      IntPtr ppv = IntPtr.Zero;
      Ole32.CoInitializeEx(IntPtr.Zero, CoInit.ApartmentThreaded);
      int instance = (int) Ole32.CoCreateInstance(this.CLSID_ImpAGFNEx, IntPtr.Zero, CLSCTX.ALL, this.IID_IImpAGFNEx, out ppv);
      if (ppv == IntPtr.Zero)
        dwError = ATKGFNEXSRV_ERR.SUCCESS;
      else if (ppv != IntPtr.Zero)
      {
        uint dwResult = 0;
        AGFN_BUFFER agfnBuffer = new AGFN_BUFFER();
        agfnBuffer.Header.MainFunc = ushort.MaxValue;
        agfnBuffer.Header.ErrorCode = (byte) 0;
        IntPtr pData = Marshal.AllocHGlobal(Marshal.SizeOf<AGFN_BUFFER>((M0) agfnBuffer));
        Marshal.StructureToPtr<AGFN_BUFFER>((M0) agfnBuffer, pData, false);
        IImpAGFNEx objectForIunknown = (IImpAGFNEx) Marshal.GetObjectForIUnknown(ppv);
        int num = (int) objectForIunknown.GENERIC_IDENTIFY(pData, ref dwResult);
        if ((int) dwResult == (int) ATKGFNEXSRV_ERR.SUCCESS)
          flag = true;
        dwError = dwResult;
        Marshal.ReleaseComObject((object) objectForIunknown);
      }
      Ole32.CoUninitialize();
      return flag;
    }

    public uint CallGenericFunction(ushort wMainFunc, ushort wSubFunc, ref uint dwError)
    {
      uint gferrorNotinstall = GFNEX.GFERROR_NOTINSTALL;
      IntPtr ppv = IntPtr.Zero;
      Ole32.CoInitializeEx(IntPtr.Zero, CoInit.ApartmentThreaded);
      int instance = (int) Ole32.CoCreateInstance(this.CLSID_ImpAGFNEx, IntPtr.Zero, CLSCTX.ALL, this.IID_IImpAGFNEx, out ppv);
      if (ppv == IntPtr.Zero)
        dwError = ATKGFNEXSRV_ERR.SUCCESS;
      else if (ppv != IntPtr.Zero)
      {
        AGFN_BUFFER agfnBuffer = new AGFN_BUFFER();
        agfnBuffer.Header.MainFunc = wMainFunc;
        agfnBuffer.Header.SubFunc = wSubFunc;
        agfnBuffer.Header.BufferLen = (ushort) 4096;
        agfnBuffer.Header.ErrorCode = (byte) 0;
        IntPtr pData = Marshal.AllocHGlobal(Marshal.SizeOf<AGFN_BUFFER>((M0) agfnBuffer));
        Marshal.StructureToPtr<AGFN_BUFFER>((M0) agfnBuffer, pData, false);
        IImpAGFNEx objectForIunknown = (IImpAGFNEx) Marshal.GetObjectForIUnknown(ppv);
        int num = (int) objectForIunknown.GENERIC_FUNCTION(pData, ref gferrorNotinstall);
        Marshal.ReleaseComObject((object) objectForIunknown);
      }
      Ole32.CoUninitialize();
      return (int) gferrorNotinstall != (int) ATKGFNEXSRV_ERR.SUCCESS ? ((int) gferrorNotinstall != (int) ATKGFNEXSRV_ERR.ERROR ? GFNEX.GFERROR_OTHERERROR : GFNEX.GFERROR_STATUSERROR) : GFNEX.ERROR_SUCCESS;
    }
  }
}
