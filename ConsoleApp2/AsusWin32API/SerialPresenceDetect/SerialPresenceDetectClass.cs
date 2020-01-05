// Decompiled with JetBrains decompiler
// Type: AsusWin32API.SerialPresenceDetect.SerialPresenceDetectClass
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using AsusWin32API.SMBusIoCtrl;
using System.Collections.Generic;

namespace AsusWin32API.SerialPresenceDetect
{
  public class SerialPresenceDetectClass : SMBusIoCtrlClass
  {
    private List<byte> SPDList = new List<byte>();

    ~SerialPresenceDetectClass()
    {
    }

    private bool GetSerialPresenceDetectBySMBus(ushort BaseAddress, uint Slave_Address, uint StartAddress, int ReadCount)
    {
      bool flag = false;
      uint pdwPortVal = 0;
      for (uint index = 0; (long) index < (long) ReadCount; ++index)
      {
        uint num1 = 0;
        do
        {
          flag = this.g_AsusIoCtrlLib.SetPortVal(BaseAddress, (uint) byte.MaxValue, (byte) 1);
          if (flag)
            flag = this.g_AsusIoCtrlLib.GetPortVal(BaseAddress, ref pdwPortVal, (byte) 1);
          if (((int) pdwPortVal & 159) != 0)
          {
            flag = false;
            ++num1;
          }
          else
            break;
        }
        while (num1 < 1000U);
        if (flag)
          flag = this.g_AsusIoCtrlLib.SetPortVal((ushort) ((uint) BaseAddress + 4U), Slave_Address, (byte) 1);
        if (flag)
          flag = this.g_AsusIoCtrlLib.SetPortVal((ushort) ((uint) BaseAddress + 3U), StartAddress + index, (byte) 1);
        if (flag)
          flag = this.g_AsusIoCtrlLib.SetPortVal((ushort) ((uint) BaseAddress + 2U), 72U, (byte) 1);
        uint num2 = 0;
        while (flag)
        {
          ++num2;
          flag = this.g_AsusIoCtrlLib.GetPortVal(BaseAddress, ref pdwPortVal, (byte) 1);
          if (((int) pdwPortVal & 2) != 2)
          {
            if (((int) pdwPortVal & 4) == 4 || num2 > 1000U)
              return false;
          }
          else
            break;
        }
        if (flag)
          flag = this.g_AsusIoCtrlLib.GetPortVal((ushort) ((uint) BaseAddress + 5U), ref pdwPortVal, (byte) 1);
        if (flag)
          this.SPDList.Add((byte) pdwPortVal);
      }
      return flag;
    }

    private bool GetSerialPresenceDetectByI2C(ushort BaseAddress, uint Slave_Address, uint StartAddress, int ReadCount)
    {
      bool flag1 = false;
      uint pdwPortVal = 0;
      uint num1 = 0;
      flag1 = this.g_AsusIoCtrlLib.SetPortVal((ushort) ((uint) BaseAddress + 2U), 56U, (byte) 1);
      bool flag2;
      do
      {
        flag2 = this.g_AsusIoCtrlLib.SetPortVal(BaseAddress, (uint) byte.MaxValue, (byte) 1);
        if (flag2)
          flag2 = this.g_AsusIoCtrlLib.GetPortVal(BaseAddress, ref pdwPortVal, (byte) 1);
        if (num1 > 1000U)
          return false;
        ++num1;
      }
      while (flag2 && ((int) pdwPortVal & 159) != 0);
      bool flag3 = this.g_AsusIoCtrlLib.SetPortVal((ushort) ((uint) BaseAddress + 4U), Slave_Address, (byte) 1);
      if (flag3)
        flag3 = this.g_AsusIoCtrlLib.SetPortVal((ushort) ((uint) BaseAddress + 6U), StartAddress, (byte) 1);
      if (flag3)
        flag3 = this.g_AsusIoCtrlLib.SetPortVal((ushort) ((uint) BaseAddress + 2U), 88U, (byte) 1);
      if (flag3)
      {
        for (uint index = 0; (long) index < (long) ReadCount; ++index)
        {
          uint num2 = 0;
          bool flag4 = this.g_AsusIoCtrlLib.SetPortVal(BaseAddress, 128U, (byte) 1);
          while (flag4)
          {
            ++num2;
            flag4 = this.g_AsusIoCtrlLib.GetPortVal(BaseAddress, ref pdwPortVal, (byte) 1);
            if (((int) pdwPortVal & 128) != 128)
            {
              if (num2 > 1000U)
                return false;
            }
            else
              break;
          }
          if (flag4)
            flag4 = this.g_AsusIoCtrlLib.GetPortVal((ushort) ((uint) BaseAddress + 7U), ref pdwPortVal, (byte) 1);
          if (flag4)
            this.SPDList.Add((byte) pdwPortVal);
        }
        flag3 = this.g_AsusIoCtrlLib.SetPortVal((ushort) ((uint) BaseAddress + 2U), 56U, (byte) 1);
      }
      return flag3;
    }

    private bool SMBusQuickCommand(ushort BaseAddress, uint Slave_Address)
    {
      uint pdwPortVal = 0;
      uint num = 0;
      bool flag1;
      do
      {
        flag1 = this.g_AsusIoCtrlLib.SetPortVal(BaseAddress, (uint) byte.MaxValue, (byte) 1);
        if (flag1)
          flag1 = this.g_AsusIoCtrlLib.GetPortVal(BaseAddress, ref pdwPortVal, (byte) 1);
        if (num > 100U)
          return false;
        ++num;
      }
      while (flag1 && ((int) pdwPortVal & 159) != 0);
      bool flag2 = this.g_AsusIoCtrlLib.SetPortVal((ushort) ((uint) BaseAddress + 4U), Slave_Address, (byte) 1);
      if (flag2)
        flag2 = this.g_AsusIoCtrlLib.SetPortVal((ushort) ((uint) BaseAddress + 2U), 64U, (byte) 1);
      return flag2;
    }

    private bool SetSMBusMode(uint PCIRegisterAddress, bool IsI2CMode)
    {
      bool flag1 = false;
      uint pdwPortVal = 0;
      bool flag2 = this.g_AsusIoCtrlLib.SetPortVal(SMBusIoCtrlClass.PCI_CONFIG_ADRESS, PCIRegisterAddress + 64U, (byte) 4);
      if (flag2)
        flag2 = this.g_AsusIoCtrlLib.GetPortVal(SMBusIoCtrlClass.PCI_CONFIG_DATA, ref pdwPortVal, (byte) 1);
      if (flag2)
      {
        if (IsI2CMode)
          pdwPortVal |= 4U;
        else
          pdwPortVal &= 251U;
        flag2 = this.g_AsusIoCtrlLib.SetPortVal(SMBusIoCtrlClass.PCI_CONFIG_DATA, pdwPortVal, (byte) 1);
      }
      if (flag2)
        flag2 = this.g_AsusIoCtrlLib.SetPortVal(SMBusIoCtrlClass.PCI_CONFIG_ADRESS, PCIRegisterAddress + 64U, (byte) 4);
      if (flag2)
        flag1 = this.g_AsusIoCtrlLib.GetPortVal(SMBusIoCtrlClass.PCI_CONFIG_DATA, ref pdwPortVal, (byte) 1);
      return ((int) pdwPortVal & 4) == 4 == IsI2CMode;
    }

    public bool GetSMBusInfo(out SMBusInfo smbusInfo)
    {
      return this.GetSMBusInformation((byte) 0, (byte) 31, (byte) 4, (byte) 0, out smbusInfo);
    }

    public bool GetSPDIInformationBySMBusMode(ushort SMBusBaseAddress, DIMM DIMMIndex, out byte[] SPDData)
    {
      SPDData = (byte[]) null;
      this.SPDList.Clear();
      bool flag = this.SMBusQuickCommand(SMBusBaseAddress, 108U);
      if (flag)
        flag = this.GetSerialPresenceDetectBySMBus(SMBusBaseAddress, (uint) DIMMIndex, 0U, 256);
      if (flag)
      {
        this.SMBusQuickCommand(SMBusBaseAddress, 110U);
        flag = this.GetSerialPresenceDetectBySMBus(SMBusBaseAddress, (uint) DIMMIndex, 0U, 256);
      }
      if (flag)
        SPDData = this.SPDList.ToArray();
      return flag;
    }

    public bool GetSPDIInformationByI2CMode(ushort SMBusBaseAddress, DIMM DIMMIndex, out byte[] SPDData)
    {
      SPDData = (byte[]) null;
      this.SPDList.Clear();
      bool flag = this.SMBusQuickCommand(SMBusBaseAddress, 108U);
      if (flag)
        flag = this.GetSerialPresenceDetectByI2C(SMBusBaseAddress, (uint) DIMMIndex, 0U, 256);
      if (flag)
      {
        this.SMBusQuickCommand(SMBusBaseAddress, 110U);
        flag = this.GetSerialPresenceDetectByI2C(SMBusBaseAddress, (uint) DIMMIndex, 0U, 256);
      }
      if (flag)
        SPDData = this.SPDList.ToArray();
      return flag;
    }

    public bool GetXMPProfileByI2C(ushort SMBusBaseAddress, DIMM DIMMIndex, out byte Version, out bool Profile1IsEnable, out bool Profile2IsEanble)
    {
      bool flag = false;
      Version = (byte) 0;
      Profile1IsEnable = false;
      Profile2IsEanble = false;
      this.SPDList.Clear();
      if (this.SMBusQuickCommand(SMBusBaseAddress, 110U))
      {
        flag = this.GetSerialPresenceDetectByI2C(SMBusBaseAddress, (uint) DIMMIndex, 112U, 4);
        if (flag)
        {
          byte[] array = this.SPDList.ToArray();
          if (array[0] == (byte) 202 && array[1] == (byte) 74)
          {
            Profile1IsEnable = ((int) array[2] & 1) == 1;
            Profile2IsEanble = ((int) array[2] & 2) == 2;
            Version = array[3];
          }
        }
      }
      return flag;
    }

    public bool GetXMPProfileBySMBus(ushort SMBusBaseAddress, DIMM DIMMIndex, out byte Version, out bool Profile1IsEnable, out bool Profile2IsEanble)
    {
      bool flag = false;
      Version = (byte) 0;
      Profile1IsEnable = false;
      Profile2IsEanble = false;
      this.SPDList.Clear();
      if (this.SMBusQuickCommand(SMBusBaseAddress, 110U))
      {
        flag = this.GetSerialPresenceDetectBySMBus(SMBusBaseAddress, (uint) DIMMIndex, 128U, 4);
        if (flag)
        {
          byte[] array = this.SPDList.ToArray();
          if (array[0] == (byte) 12 && array[1] == (byte) 74)
          {
            Profile1IsEnable = ((int) array[2] & 1) == 1;
            Profile2IsEanble = ((int) array[2] & 2) == 2;
            Version = array[3];
          }
        }
      }
      return flag;
    }
  }
}
