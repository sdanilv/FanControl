using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class ATKHelper
    {
        public static int ESS = 393361;
        public static int HotZone = 327716;
        public static int LightBar = 327717;
        public static int DockingFanSilder = 1114134;
        public static int SystemFanSilder = 1114133;
        public static int MemoryVoltage = 1179765;
        public static int DockingStatus = 1179747;
        public static int DoublePowerStatus = 1179751;
        public static int DNotifyStatus = 1179764;
        public static int ThermalPolicy = 1114135;
        public static int ECOMode = 1114145;
        public static int FanBoost = 1114136;
        public static uint DOCKING_DC_STATUS_MASK = 1;
        public static uint NOTEBOOK_DC_STATUS_MASK = 2;
        private static int[] DNotify = new int[5]
        {
      0,
      2,
      0,
      1,
      1
        };
        private static string EVENT_BARON = "Global\\ASUS ASRgbKbSrv LightBar On Event";
        private static string EVENT_BARONCHANGE = "Global\\ASUS ASRgbKbSrv LightBar On Change Event";

        public static bool CheckATKIsSupport(ref SupportATKFunc IsSupportATK)
        {
            bool flag = false;
            ATKLib atkLib = new ATKLib();
            try
            {
                if (atkLib.InitializeATKACPIdevice())
                {
                    uint pulReturnValue = 0;
                    IsSupportATK.ESS = atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.ESS, ref pulReturnValue);
                    if (IsSupportATK.ESS)
                        IsSupportATK.ESS = pulReturnValue == 65536U || pulReturnValue == 32768U;
                    IsSupportATK.HotZone = atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.HotZone, ref pulReturnValue);
                    if (IsSupportATK.HotZone)
                        IsSupportATK.HotZone = pulReturnValue == 65536U || pulReturnValue == 32768U;
                    IsSupportATK.LightBar = atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.LightBar, ref pulReturnValue);
                    if (IsSupportATK.LightBar)
                        IsSupportATK.LightBar = ((int)pulReturnValue & 65536) == 65536;
                    IsSupportATK.SystemFan = atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.SystemFanSilder, ref pulReturnValue);
                    if (IsSupportATK.SystemFan)
                        IsSupportATK.SystemFan = pulReturnValue == 65536U || pulReturnValue == 32768U;
                    IsSupportATK.DockingFan = atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.DockingFanSilder, ref pulReturnValue);
                    if (IsSupportATK.DockingFan)
                        IsSupportATK.DockingFan = ((int)pulReturnValue & 65536) == 65536;
                    IsSupportATK.ThermalPolicy = atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.ThermalPolicy, ref pulReturnValue);
                    if (IsSupportATK.ThermalPolicy)
                        IsSupportATK.ThermalPolicy = ((int)pulReturnValue & 65536) == 65536;
                    IsSupportATK.ECOMode = atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.ECOMode, ref pulReturnValue);
                    if (IsSupportATK.ECOMode)
                        IsSupportATK.ECOMode = ((int)pulReturnValue & 65536) == 65536;
                    IsSupportATK.FanOverboost = atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.FanBoost, ref pulReturnValue);
                    if (IsSupportATK.FanOverboost)
                        IsSupportATK.FanOverboost = ((int)pulReturnValue & 65536) == 65536;
                    atkLib.UninitializeATKACPIDevice();
                }
            }
            catch (Exception ex)
            {
            }
            return flag;
        }

        public static int GetFanBoostMode()
        {
            int num = 0;
            ATKLib atkLib = new ATKLib();
            try
            {
                if (atkLib.InitializeATKACPIdevice())
                {
                    uint pulReturnValue = 0;
                    if (atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.FanBoost, ref pulReturnValue) && ((int)pulReturnValue & 65536) == 65536 && ((int)pulReturnValue & 1) == 1)
                    {
                        num = 2;
                        if (((int)pulReturnValue & 2) == 2)
                            num = 3;
                    }
                    atkLib.UninitializeATKACPIDevice();
                }
            }
            catch (Exception ex)
            {
            }
            return num;
        }

        public static bool IsSupportDocking()
        {
            bool flag = false;
            ATKLib atkLib = new ATKLib();
            try
            {
                if (atkLib.InitializeATKACPIdevice())
                {
                    uint pulReturnValue = 0;
                    if (atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.DoublePowerStatus, ref pulReturnValue))
                        flag = ((int)pulReturnValue & 65536) == 65536;
                    if (!flag && atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.DockingStatus, ref pulReturnValue))
                        flag = ((int)pulReturnValue & 65536) == 65536;
                    atkLib.UninitializeATKACPIDevice();
                }
            }
            catch (Exception ex)
            {
            }
            return flag;
        }

        public static bool IsEnableECOMode()
        {
            bool flag = false;
            ATKLib atkLib = new ATKLib();
            try
            {
                if (atkLib.InitializeATKACPIdevice())
                {
                    uint pulReturnValue = 0;
                    if (atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.ECOMode, ref pulReturnValue))
                        flag = ((int)pulReturnValue & 65536) == 65536;
                    if (flag)
                        flag = ((int)pulReturnValue & 1) == 0;
                    atkLib.UninitializeATKACPIDevice();
                }
            }
            catch (Exception ex)
            {
            }
            return flag;
        }

        public static bool SetECOMode(bool IsEnable)
        {
            return ATKHelper.SetStatusToATK(ATKHelper.ECOMode, IsEnable);
        }

        public static bool SetStatusToATK(int Command, bool IsEnable)
        {
            ATKLib atkLib = new ATKLib();
            bool flag = false;
            try
            {
                if (atkLib.InitializeATKACPIdevice())
                {
                    uint pulReturnValue = 0;
                    int iArg1 = 0;
                    if (IsEnable)
                        iArg1 = 1;
                    flag = atkLib.Two_WMIMethod_INT(ATKLib.SVED, Command, iArg1, ref pulReturnValue);
                    atkLib.UninitializeATKACPIDevice();
                }
            }
            catch (Exception ex)
            {
            }
            return flag;
        }

        public static bool GetLightBarStatus()
        {
            ATKLib atkLib = new ATKLib();
            bool flag = false;
            try
            {
                if (atkLib.InitializeATKACPIdevice())
                {
                    uint pulReturnValue = 0;
                    if (atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.LightBar, ref pulReturnValue) && ((int)pulReturnValue & 65536) == 65536)
                        flag = ((int)pulReturnValue & 15) == 1;
                    atkLib.UninitializeATKACPIDevice();
                }
            }
            catch (Exception ex)
            {
            }
            return flag;
        }

        public static bool SetLightBarStatus(bool IsEnable)
        {
            return ATKHelper.SetStatusToATK(ATKHelper.LightBar, IsEnable);
        }

        public static bool SetHotZoneStatus(bool IsEnable)
        {
            return ATKHelper.SetStatusToATK(ATKHelper.HotZone, IsEnable);
        }

        public static bool SetThermalPolicyStatus(bool IsEnable)
        {
            return ATKHelper.SetStatusToATK(ATKHelper.ThermalPolicy, IsEnable);
        }

        public static bool SetESSStatus(bool IsEnable)
        {
            return ATKHelper.SetStatusToATK(ATKHelper.ESS, IsEnable);
        }

        public static bool SetStatusToATK(int Command, int Arg0)
        {
            ATKLib atkLib = new ATKLib();
            bool flag = false;
            try
            {
                if (atkLib.InitializeATKACPIdevice())
                {
                    uint pulReturnValue = 0;
                    flag = atkLib.Two_WMIMethod_INT(ATKLib.SVED, Command, Arg0, ref pulReturnValue);
                    atkLib.UninitializeATKACPIDevice();
                }
            }
            catch (Exception ex)
            {
            }
            return flag;
        }

        public static bool SetSystemFanStatus(int Offset)
        {
            return ATKHelper.SetStatusToATK(ATKHelper.SystemFanSilder, Offset);
        }

        public static bool SetDockingStatus(int Offset)
        {
            return ATKHelper.SetStatusToATK(ATKHelper.DockingFanSilder, Offset);
        }

        public static bool GetMemoryVoltageStatus(out int NowStatus)
        {
            bool flag = false;
            ATKLib atkLib = new ATKLib();
            NowStatus = 0;
            try
            {
                if (atkLib.InitializeATKACPIdevice())
                {
                    uint pulReturnValue = 0;
                    flag = atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.MemoryVoltage, ref pulReturnValue);
                    if (flag)
                        NowStatus = (int)pulReturnValue & 15;
                    atkLib.UninitializeATKACPIDevice();
                }
            }
            catch (Exception ex)
            {
            }
            return flag;
        }

        public static bool SetMemoryVoltageStatus(int TuningStatus)
        {
            bool flag = false;
            ATKLib atkLib = new ATKLib();
            try
            {
                if (atkLib.InitializeATKACPIdevice())
                {
                    uint pulReturnValue = 0;
                    flag = atkLib.Two_WMIMethod_INT(ATKLib.SVED, ATKHelper.MemoryVoltage, TuningStatus, ref pulReturnValue);
                    if (flag)
                        flag = pulReturnValue == 1U;
                    atkLib.UninitializeATKACPIDevice();
                }
            }
            catch (Exception ex)
            {
            }
            return flag;
        }

        public static bool GetDockingStatus(out DOCKING_STATUS CurrentDockingStatus)
        {
            CurrentDockingStatus = DOCKING_STATUS.DS_NOTSUPPORT;
            ATKLib atkLib = new ATKLib();
            bool flag = false;
            try
            {
                if (atkLib.InitializeATKACPIdevice())
                {
                    uint pulReturnValue = 0;
                    flag = atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.DockingStatus, ref pulReturnValue);
                    if (flag)
                        flag = ((int)pulReturnValue & 65536) == 65536;
                    if (flag)
                    {
                        switch (pulReturnValue & 15U)
                        {
                            case 0:
                                CurrentDockingStatus = DOCKING_STATUS.DS_DISCONNECTED;
                                break;
                            case 1:
                                CurrentDockingStatus = DOCKING_STATUS.DS_CONNECTED;
                                break;
                        }
                    }
                    atkLib.UninitializeATKACPIDevice();
                }
            }
            catch (Exception ex)
            {
            }
            return flag;
        }

        public static bool GetPowerStatus(out DOUBLE_POWER_STATUS CurrentPowerStatus)
        {
            CurrentPowerStatus = DOUBLE_POWER_STATUS.DS_NOTSUPPORT;
            ATKLib atkLib = new ATKLib();
            bool flag = false;
            try
            {
                if (atkLib.InitializeATKACPIdevice())
                {
                    uint pulReturnValue = 0;
                    flag = atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.DoublePowerStatus, ref pulReturnValue);
                    if (flag)
                        flag = ((int)pulReturnValue & 65536) == 65536;
                    if (flag)
                    {
                        uint num = pulReturnValue & 15U;
                        CurrentPowerStatus = num < 1U || num > 3U ? DOUBLE_POWER_STATUS.DS_DCSTATUS : (DOUBLE_POWER_STATUS)num;
                    }
                    atkLib.UninitializeATKACPIDevice();
                }
            }
            catch (Exception ex)
            {
            }
            return flag;
        }

        public static bool GetDockingWithPowerStatus(out DOCKING_STATUS CurrentDockingStatus, out int CurrentPowerStatus)
        {
            CurrentPowerStatus = 0;
            CurrentDockingStatus = DOCKING_STATUS.DS_NOTSUPPORT;
            ATKLib atkLib = new ATKLib();
            bool flag = false;
            try
            {
                if (atkLib.InitializeATKACPIdevice())
                {
                    uint pulReturnValue = 0;
                    flag = atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.DoublePowerStatus, ref pulReturnValue);
                    if (flag)
                        flag = ((int)pulReturnValue & 65536) == 65536;
                    if (flag)
                        CurrentPowerStatus = (int)pulReturnValue & 15;
                    else
                        pulReturnValue = 0U;
                    flag = atkLib.One_WMIMethod_INT(ATKLib.STSD, ATKHelper.DockingStatus, ref pulReturnValue);
                    if (flag)
                        flag = ((int)pulReturnValue & 65536) == 65536;
                    if (flag)
                    {
                        switch (pulReturnValue & 15U)
                        {
                            case 0:
                                CurrentDockingStatus = DOCKING_STATUS.DS_DISCONNECTED;
                                break;
                            case 1:
                                CurrentDockingStatus = DOCKING_STATUS.DS_CONNECTED;
                                break;
                        }
                    }
                    else
                        CurrentDockingStatus = DOCKING_STATUS.DS_NOTSUPPORT;
                    flag = true;
                    atkLib.UninitializeATKACPIDevice();
                }
            }
            catch (Exception ex)
            {
            }
            return flag;
        }

        public static bool SetDNotifyStatus(int TurboGearMode)
        {
            bool flag = false;
            ATKLib atkLib = new ATKLib();
            try
            {
                if (atkLib.InitializeATKACPIdevice())
                {
                    uint pulReturnValue = 0;
                    if (TurboGearMode > 0 && TurboGearMode <= 4)
                        flag = atkLib.Two_WMIMethod_INT(ATKLib.SVED, ATKHelper.DNotifyStatus, ATKHelper.DNotify[TurboGearMode], ref pulReturnValue);
                    if (flag)
                        flag = pulReturnValue == 1U;
                    atkLib.UninitializeATKACPIDevice();
                }
            }
            catch (Exception ex)
            {
            }
            return flag;
        }

        public static uint GetHIDLightBarWithEvent()
        {
            uint num1 = 2;
            IntPtr num2 = Kernel32.OpenEvent(Kernel32.SYNCHRONIZE, false, ATKHelper.EVENT_BARON);
            if (num2 != IntPtr.Zero)
            {
                num1 = 0U;
                if ((int)Kernel32.WaitForSingleObject(num2, 0U) == (int)Kernel32.WAIT_OBJECT_0)
                    num1 = 1U;
                Kernel32.CloseHandle(num2);
            }
            return num1;
        }

        public static bool SetHIDLightBarWithEvent(bool bEnable)
        {
            IntPtr num1 = Kernel32.OpenEvent(Kernel32.EVENT_MODIFY_STATE, false, ATKHelper.EVENT_BARON);
            if (num1 != IntPtr.Zero)
            {
                if (bEnable)
                    Kernel32.SetEvent(num1);
                else
                    Kernel32.ResetEvent(num1);
                Kernel32.CloseHandle(num1);
                IntPtr num2 = Kernel32.OpenEvent(Kernel32.EVENT_MODIFY_STATE, false, ATKHelper.EVENT_BARONCHANGE);
                if (num2 != IntPtr.Zero)
                {
                    Kernel32.SetEvent(num2);
                    Kernel32.CloseHandle(num2);
                    return true;
                }
            }
            return false;
        }
    }
}
