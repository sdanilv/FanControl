// Decompiled with JetBrains decompiler
// Type: AsusWin32API.ATKLib
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.InteropServices;

namespace AsusWin32API
{
  public class ATKLib
  {
    public static uint STSD = 1398035268;
    public static uint SVED = 1398162756;
    private static uint IOCTL_ASUS_ACPI_WMIFUNCTION = 2237452;
    private IntPtr hDevHandle = Kernel32.INVALID_HANDLE_VALUE;
    private int BufferSize = 100;

    public bool InitializeATKACPIdevice()
    {
      this.hDevHandle = Kernel32.CreateFile("\\\\.\\ATKACPI", Kernel32.GENERIC_WRITE | Kernel32.GENERIC_READ, Kernel32.FILE_SHARE_WRITE | Kernel32.FILE_SHARE_READ, IntPtr.Zero, ECreationDisposition.OpenExisting, 0U, IntPtr.Zero);
      return !(this.hDevHandle == Kernel32.INVALID_HANDLE_VALUE);
    }

    public bool One_WMIMethod_INT(uint szMethod, int iArg, ref uint pulReturnValue)
    {
      bool flag = false;
      byte[] bytes = BitConverter.GetBytes(iArg);
      byte[] pOutBuffer = (byte[]) null;
      int pOutBufSize = 0;
      pulReturnValue = 0U;
      if (this.hDevHandle != Kernel32.INVALID_HANDLE_VALUE)
      {
        flag = this.ControlWMIMethod(szMethod, bytes, 4, out pOutBuffer, ref pOutBufSize);
        if (flag && pOutBufSize > 0)
          pulReturnValue = BitConverter.ToUInt32(pOutBuffer, 0);
      }
      return flag;
    }

    public bool Two_WMIMethod_INT(uint szMethod, int iArg0, int iArg1, ref uint pulReturnValue)
    {
      bool flag = false;
      byte[] bytes1 = BitConverter.GetBytes(iArg0);
      byte[] bytes2 = BitConverter.GetBytes(iArg1);
      byte[] pInBuffer = new byte[bytes1.Length + bytes2.Length];
      byte[] pOutBuffer = (byte[]) null;
      int pOutBufSize = 0;
      pulReturnValue = 0U;
      Array.Copy((Array) bytes1, (Array) pInBuffer, bytes1.Length);
      Array.Copy((Array) bytes2, 0, (Array) pInBuffer, bytes1.Length, bytes2.Length);
      if (this.hDevHandle != Kernel32.INVALID_HANDLE_VALUE)
      {
        flag = this.ControlWMIMethod(szMethod, pInBuffer, 8, out pOutBuffer, ref pOutBufSize);
        if (flag && pOutBufSize > 0)
          pulReturnValue = BitConverter.ToUInt32(pOutBuffer, 0);
      }
      return flag;
    }

    public void UninitializeATKACPIDevice()
    {
      if (!(this.hDevHandle != Kernel32.INVALID_HANDLE_VALUE))
        return;
      Kernel32.CloseHandle(this.hDevHandle);
      this.hDevHandle = Kernel32.INVALID_HANDLE_VALUE;
    }

    private bool ControlWMIMethod(uint szMethod, byte[] pInBuffer, int InBufSize, out byte[] pOutBuffer, ref int pOutBufSize)
    {
      int ofs = 0;
      int lpBytesReturned = 0;
      pOutBuffer = (byte[]) null;
      IntPtr num1 = Marshal.AllocHGlobal(this.BufferSize);
      IntPtr num2 = Marshal.AllocHGlobal(this.BufferSize);
      Marshal.WriteInt32(num2, ofs, (int) szMethod);
      int num3 = ofs + 4;
      Marshal.WriteInt32(num2, 4, InBufSize);
      int num4 = num3 + 4;
      for (int index = 0; index < pInBuffer.Length; ++index)
        Marshal.WriteByte(num2, num4 + index, pInBuffer[index]);
      int nInBufferSize = num4 + pInBuffer.Length;
      pOutBuffer = (byte[]) null;
      int num5 = Kernel32.DeviceIoControl(this.hDevHandle, ATKLib.IOCTL_ASUS_ACPI_WMIFUNCTION, num2, nInBufferSize, num1, this.BufferSize, ref lpBytesReturned, IntPtr.Zero) ? 1 : 0;
      if (num5 != 0)
      {
        pOutBufSize = lpBytesReturned;
        pOutBuffer = new byte[lpBytesReturned];
        Marshal.Copy(num1, pOutBuffer, 0, lpBytesReturned);
      }
      Marshal.FreeHGlobal(num1);
      Marshal.FreeHGlobal(num2);
      return num5 != 0;
    }
  }
}
