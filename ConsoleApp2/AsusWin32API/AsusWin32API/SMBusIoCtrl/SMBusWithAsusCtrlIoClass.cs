// Decompiled with JetBrains decompiler
// Type: AsusWin32API.SMBusIoCtrl.SMBusWithAsusCtrlIoClass
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using AsusWin32API.ASUSAPI;
using AsusWin32API.AsusIoCtrlLib;

namespace AsusWin32API.SMBusIoCtrl
{
  public class SMBusWithAsusCtrlIoClass
  {
    protected static ushort PCI_CONFIG_ADRESS = 3320;
    protected static ushort PCI_CONFIG_DATA = 3324;
    protected static string AsusIoCtrlServiceName = "AsusCtrlIo";
    protected static string AsusIoCtrlDisplayName = "Asus IO Port Control";
    protected AsusCtrlIoLibClass g_AsusIoCtrlLib;

    ~SMBusWithAsusCtrlIoClass()
    {
      this.Uninitialization();
    }

    public bool Initialization()
    {
      bool flag = AsusAPIClass.StartService(SMBusWithAsusCtrlIoClass.AsusIoCtrlServiceName);
      if (flag)
      {
        this.g_AsusIoCtrlLib = new AsusCtrlIoLibClass();
        flag = this.g_AsusIoCtrlLib.InitializeAsusIoCtrldevice();
        if (!flag)
          this.g_AsusIoCtrlLib = (AsusCtrlIoLibClass) null;
      }
      return flag;
    }

    public void Uninitialization()
    {
      if (this.g_AsusIoCtrlLib != null)
      {
        this.g_AsusIoCtrlLib.UninitializeATKACPIDevice();
        AsusAPIClass.StopService(SMBusWithAsusCtrlIoClass.AsusIoCtrlServiceName);
      }
      this.g_AsusIoCtrlLib = (AsusCtrlIoLibClass) null;
    }

    protected bool GetSMBusInformation(byte Bus, byte Device, byte Function, byte Register, out SMBusInfo smbusInfo)
    {
      uint pdwPortVal1 = (uint) ((int) (((((uint) (128 << 8) | (uint) Bus) << 5 | (uint) Device) << 3 | (uint) Function) << 6 | (uint) Register) << 2 | 0);
      uint pdwPortVal2 = 0;
      bool flag1 = false;
      smbusInfo = new SMBusInfo();
      bool flag2 = this.g_AsusIoCtrlLib.SetPortVal(SMBusWithAsusCtrlIoClass.PCI_CONFIG_ADRESS, pdwPortVal1, (byte) 4);
      if (flag2)
        flag2 = this.g_AsusIoCtrlLib.GetPortVal(SMBusWithAsusCtrlIoClass.PCI_CONFIG_DATA, ref pdwPortVal2, (byte) 4);
      if (pdwPortVal2 == uint.MaxValue || pdwPortVal2 == 0U)
        flag2 = false;
      if (flag2)
      {
        smbusInfo.PCIRegisterAddress = pdwPortVal1;
        smbusInfo.VendorID = (ushort) pdwPortVal2;
        smbusInfo.DeviceID = (ushort) (pdwPortVal2 >> 16);
        flag2 = this.g_AsusIoCtrlLib.SetPortVal(SMBusWithAsusCtrlIoClass.PCI_CONFIG_ADRESS, pdwPortVal1 + 10U, (byte) 4);
      }
      if (flag2)
      {
        flag1 = this.g_AsusIoCtrlLib.GetPortVal(SMBusWithAsusCtrlIoClass.PCI_CONFIG_DATA, ref pdwPortVal2, (byte) 4);
        smbusInfo.ClssCode = (ushort) (pdwPortVal2 >> 16);
        flag2 = this.g_AsusIoCtrlLib.SetPortVal(SMBusWithAsusCtrlIoClass.PCI_CONFIG_ADRESS, pdwPortVal1 + 32U, (byte) 4);
      }
      if (flag2)
        flag2 = this.g_AsusIoCtrlLib.GetPortVal(SMBusWithAsusCtrlIoClass.PCI_CONFIG_DATA, ref pdwPortVal2, (byte) 4);
      if (flag2)
      {
        smbusInfo.SMBusBaseAddress = (ushort) (pdwPortVal2 & 65520U);
        return flag2;
      }
      smbusInfo = (SMBusInfo) null;
      return false;
    }
  }
}
