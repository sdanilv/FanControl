// Decompiled with JetBrains decompiler
// Type: AsusWin32API.AsusIoCtrlLib.AsusIoCtrlLibClass
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using AsusWin32API.ASUSAPI;
using System;
using System.Runtime.InteropServices;

namespace AsusWin32API.AsusIoCtrlLib
{
  public class AsusIoCtrlLibClass
  {
    private static uint FILE_DEVICE_WINIO = 32784;
    private static uint WINIO_IOCTL_INDEX = 2064;
    private static uint IOCTL_WINIO_READPORT = AsusAPIClass.CTL_CODE(AsusIoCtrlLibClass.FILE_DEVICE_WINIO, AsusIoCtrlLibClass.WINIO_IOCTL_INDEX + 4U, 0U, 0U);
    private static uint IOCTL_WINIO_WRITEPORT = AsusAPIClass.CTL_CODE(AsusIoCtrlLibClass.FILE_DEVICE_WINIO, AsusIoCtrlLibClass.WINIO_IOCTL_INDEX + 5U, 0U, 0U);
    private IntPtr hDevHandle = Kernel32.INVALID_HANDLE_VALUE;
    private IntPtr iPortVal = IntPtr.Zero;
    private IntPtr pPortStruct = Kernel32.INVALID_HANDLE_VALUE;
    private AsusIoCtrlLibClass.tagPortStruct PortStruct;
    private int iStructSize;

    public bool InitializeAsusIoCtrldevice()
    {
      this.hDevHandle = Kernel32.CreateFile("\\\\.\\WinIO", Kernel32.GENERIC_WRITE | Kernel32.GENERIC_READ, 0U, IntPtr.Zero, ECreationDisposition.OpenExisting, Kernel32.FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
      if (this.hDevHandle == Kernel32.INVALID_HANDLE_VALUE)
        return false;
      this.PortStruct = new AsusIoCtrlLibClass.tagPortStruct();
      this.iStructSize = Marshal.SizeOf<AsusIoCtrlLibClass.tagPortStruct>((M0) this.PortStruct);
      this.pPortStruct = Marshal.AllocHGlobal(this.iStructSize);
      this.iPortVal = Marshal.AllocHGlobal(4);
      return true;
    }

    public void UninitializeATKACPIDevice()
    {
      if (this.hDevHandle != IntPtr.Zero && this.hDevHandle != Kernel32.INVALID_HANDLE_VALUE)
        Kernel32.CloseHandle(this.hDevHandle);
      if (this.pPortStruct != IntPtr.Zero && this.pPortStruct != Kernel32.INVALID_HANDLE_VALUE)
        Marshal.FreeHGlobal(this.pPortStruct);
      if (!(this.iPortVal != IntPtr.Zero) || !(this.pPortStruct != Kernel32.INVALID_HANDLE_VALUE))
        return;
      Marshal.FreeHGlobal(this.iPortVal);
    }

    public bool GetPortVal(ushort wProtAddr, ref uint pdwPortVal, byte bSize)
    {
      int lpBytesReturned = 0;
      this.PortStruct.bSize = bSize;
      this.PortStruct.wPortAddr = wProtAddr;
      Marshal.StructureToPtr<AsusIoCtrlLibClass.tagPortStruct>((M0) this.PortStruct, this.pPortStruct, false);
      IntPtr num1 = Marshal.AllocHGlobal(4);
      int num2 = Kernel32.DeviceIoControl(this.hDevHandle, AsusIoCtrlLibClass.IOCTL_WINIO_READPORT, this.pPortStruct, this.iStructSize, num1, 4, ref lpBytesReturned, IntPtr.Zero) ? 1 : 0;
      if (num2 != 0 && lpBytesReturned != 0)
        pdwPortVal = (uint) Marshal.ReadInt32(num1);
      Marshal.FreeHGlobal(num1);
      return num2 != 0;
    }

    public bool SetPortVal(ushort wProtAddr, uint pdwPortVal, byte bSize)
    {
      bool flag = false;
      if (this.hDevHandle != IntPtr.Zero || this.hDevHandle != Kernel32.INVALID_HANDLE_VALUE)
      {
        int lpBytesReturned = 0;
        this.PortStruct.bSize = bSize;
        this.PortStruct.dwPortVal = pdwPortVal;
        this.PortStruct.wPortAddr = wProtAddr;
        Marshal.StructureToPtr<AsusIoCtrlLibClass.tagPortStruct>((M0) this.PortStruct, this.pPortStruct, false);
        flag = Kernel32.DeviceIoControl(this.hDevHandle, AsusIoCtrlLibClass.IOCTL_WINIO_WRITEPORT, this.pPortStruct, this.iStructSize, IntPtr.Zero, 0, ref lpBytesReturned, IntPtr.Zero);
      }
      return flag;
    }

    [StructLayout(LayoutKind.Sequential, Size = 7, Pack = 1)]
    private struct tagPortStruct
    {
      public ushort wPortAddr;
      public uint dwPortVal;
      public byte bSize;
    }
  }
}
