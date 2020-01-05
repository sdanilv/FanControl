// Decompiled with JetBrains decompiler
// Type: AsusWin32API.ASUSAPI.AsusAPIClass
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using Microsoft.Win32;
using System;
using System.Management;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace AsusWin32API.ASUSAPI
{
  public static class AsusAPIClass
  {
    public const uint FILE_DEVICE_FILE_SYSTEM = 32784;
    public const uint METHOD_NEITHER = 3;
    public const uint METHOD_BUFFERED = 0;
    public const uint FILE_ANY_ACCESS = 0;
    public const uint FILE_SPECIAL_ACCESS = 0;

    public static void AttachedThreadInputAction(Action action)
    {
      uint windowThreadProcessId = User32.GetWindowThreadProcessId(User32.GetForegroundWindow(), IntPtr.Zero);
      uint currentThreadId = Kernel32.GetCurrentThreadId();
      bool flag = false;
      try
      {
        flag = (int) windowThreadProcessId == (int) currentThreadId || User32.AttachThreadInput(windowThreadProcessId, currentThreadId, true);
        if (!flag)
          return;
        action();
      }
      catch (Exception ex)
      {
      }
      finally
      {
        if (!flag)
          User32.AttachThreadInput(windowThreadProcessId, currentThreadId, false);
      }
    }

    public static void ForceWindowToForeground(IntPtr hwnd)
    {
      AsusAPIClass.AttachedThreadInputAction((Action) (() =>
      {
        User32.BringWindowToTop(hwnd);
        User32.ShowWindow(hwnd, User32.SW_SHOW);
      }));
    }

    public static IntPtr SetFocusAttached(IntPtr hWnd)
    {
      IntPtr result = new IntPtr();
      AsusAPIClass.AttachedThreadInputAction((Action) (() => result = User32.SetFocus(hWnd)));
      return result;
    }

    public static uint RegistrySpecialWindowMessage(IntPtr handle, string message)
    {
      try
      {
        CHANGEFILTERSTRUCT changeInfo = new CHANGEFILTERSTRUCT();
        changeInfo.size = (uint) Marshal.SizeOf<CHANGEFILTERSTRUCT>((M0) changeInfo);
        changeInfo.info = MessageFilterInfo.None;
        uint msg = User32.RegisterWindowMessage(message);
        User32.ChangeWindowMessageFilterEx(handle, msg, ChangeWindowMessageFilterExAction.Allow, ref changeInfo);
        return msg;
      }
      catch
      {
        return 0;
      }
    }

    public static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
    {
      MINMAXINFO structure = (MINMAXINFO) Marshal.PtrToStructure(lParam, typeof (MINMAXINFO));
      int flags = 2;
      IntPtr hMonitor = User32.MonitorFromWindow(hwnd, flags);
      if (hMonitor != IntPtr.Zero)
      {
        MONITORINFO lpmi = new MONITORINFO();
        User32.GetMonitorInfo(hMonitor, lpmi);
        RECT rcWork = lpmi.rcWork;
        RECT rcMonitor = lpmi.rcMonitor;
        structure.ptMaxPosition.x = Math.Abs(rcWork.left - rcMonitor.left);
        structure.ptMaxPosition.y = Math.Abs(rcWork.top - rcMonitor.top);
        structure.ptMaxSize.x = Math.Abs(rcWork.right - rcWork.left);
        structure.ptMaxSize.y = Math.Abs(rcWork.bottom - rcWork.top);
      }
      Marshal.StructureToPtr<MINMAXINFO>((M0) structure, lParam, true);
    }

    public static bool IsUserAdmin()
    {
      int dwSubAuthority1 = 544;
      int dwSubAuthority0 = 32;
      byte num = 5;
      SidIdentifierAuthority pIdentifierAuthority = new SidIdentifierAuthority();
      ref SidIdentifierAuthority local = ref pIdentifierAuthority;
      byte[] numArray = new byte[6];
      numArray[5] = num;
      local.Value = numArray;
      IntPtr pSid = IntPtr.Zero;
      bool IsMember = false;
      if (Advapi32.AllocateAndInitializeSid(ref pIdentifierAuthority, (byte) 2, dwSubAuthority0, dwSubAuthority1, 0, 0, 0, 0, 0, 0, out pSid) && !Advapi32.CheckTokenMembership(IntPtr.Zero, pSid, out IsMember))
        IsMember = false;
      Advapi32.FreeSid(pSid);
      return IsMember;
    }

    public static uint CTL_CODE(uint DeviceType, uint Function, uint Method, uint Access)
    {
      return (uint) ((int) DeviceType << 16 | (int) Access << 14 | (int) Function << 2) | Method;
    }

    public static void Uninstall(string serviceName)
    {
      IntPtr num1 = AsusAPIClass.OpenSCManager(ScmAccessRights.AllAccess);
      try
      {
        IntPtr num2 = Advapi32.OpenService(num1, serviceName, ServiceAccessRights.AllAccess);
        if (!(num2 != IntPtr.Zero))
          return;
        try
        {
          AsusAPIClass.StopService(num2);
          Advapi32.DeleteService(num2);
        }
        catch (Exception ex)
        {
        }
        finally
        {
          Advapi32.CloseServiceHandle(num2);
        }
      }
      catch (Exception ex)
      {
      }
      finally
      {
        Advapi32.CloseServiceHandle(num1);
      }
    }

    public static bool ServiceIsInstalled(string serviceName)
    {
      IntPtr num = AsusAPIClass.OpenSCManager(ScmAccessRights.Connect);
      bool flag = false;
      try
      {
        IntPtr hSCObject = Advapi32.OpenService(num, serviceName, ServiceAccessRights.QueryStatus);
        if (hSCObject != IntPtr.Zero)
        {
          Advapi32.CloseServiceHandle(hSCObject);
          flag = true;
        }
      }
      catch (Exception ex)
      {
      }
      finally
      {
        Advapi32.CloseServiceHandle(num);
      }
      return flag;
    }

    public static bool InstallService(string serviceName, string displayName, int ServiceType, string fileName, ServiceBootFlag servicebootFlag)
    {
      bool flag = false;
      IntPtr num1 = AsusAPIClass.OpenSCManager(ScmAccessRights.AllAccess);
      try
      {
        IntPtr num2 = Advapi32.OpenService(num1, serviceName, ServiceAccessRights.AllAccess);
        if (num2 != IntPtr.Zero)
        {
          AsusAPIClass.StopService(num2);
          Advapi32.DeleteService(num2);
          Advapi32.CloseServiceHandle(num2);
          num2 = IntPtr.Zero;
        }
        if (num2 == IntPtr.Zero)
          num2 = Advapi32.CreateService(num1, serviceName, displayName, ServiceAccessRights.AllAccess, ServiceType, servicebootFlag, ServiceError.Normal, fileName, (string) null, IntPtr.Zero, (string) null, (string) null, (string) null);
        if (num2 != IntPtr.Zero)
          Advapi32.CloseServiceHandle(num2);
      }
      catch (Exception ex)
      {
      }
      finally
      {
        Advapi32.CloseServiceHandle(num1);
      }
      return flag;
    }

    public static bool InstallAndStart(string serviceName, string displayName, int ServiceType, string fileName, ServiceBootFlag servicebootFlag)
    {
      bool flag = false;
      IntPtr num1 = AsusAPIClass.OpenSCManager(ScmAccessRights.AllAccess);
      try
      {
        IntPtr num2 = Advapi32.OpenService(num1, serviceName, ServiceAccessRights.AllAccess);
        if (num2 != IntPtr.Zero)
        {
          AsusAPIClass.StopService(num2);
          Advapi32.DeleteService(num2);
          Advapi32.CloseServiceHandle(num2);
          num2 = IntPtr.Zero;
        }
        if (num2 == IntPtr.Zero)
          num2 = Advapi32.CreateService(num1, serviceName, displayName, ServiceAccessRights.AllAccess, ServiceType, servicebootFlag, ServiceError.Normal, fileName, (string) null, IntPtr.Zero, (string) null, (string) null, (string) null);
        if (num2 != IntPtr.Zero)
        {
          try
          {
            flag = AsusAPIClass.StartService(num2);
          }
          catch (Exception ex)
          {
          }
          finally
          {
            Advapi32.CloseServiceHandle(num2);
          }
        }
      }
      catch (Exception ex)
      {
      }
      finally
      {
        Advapi32.CloseServiceHandle(num1);
      }
      return flag;
    }

    public static bool InstallAndStartWithFailure(string serviceName, string displayName, int ServiceType, string fileName, ServiceBootFlag servicebootFlag, IntPtr pfailureActions)
    {
      bool flag = false;
      IntPtr num1 = AsusAPIClass.OpenSCManager(ScmAccessRights.AllAccess);
      try
      {
        IntPtr num2 = Advapi32.OpenService(num1, serviceName, ServiceAccessRights.AllAccess);
        if (num2 != IntPtr.Zero)
        {
          AsusAPIClass.StopService(num2);
          Advapi32.DeleteService(num2);
          Advapi32.CloseServiceHandle(num2);
          num2 = IntPtr.Zero;
        }
        if (num2 == IntPtr.Zero)
          num2 = Advapi32.CreateService(num1, serviceName, displayName, ServiceAccessRights.AllAccess, ServiceType, servicebootFlag, ServiceError.Normal, fileName, (string) null, IntPtr.Zero, (string) null, (string) null, (string) null);
        if (num2 != IntPtr.Zero)
        {
          try
          {
            flag = Advapi32.ChangeServiceConfig2(num2, 2, pfailureActions);
            flag = AsusAPIClass.StartService(num2);
          }
          catch (Exception ex)
          {
          }
          finally
          {
            Advapi32.CloseServiceHandle(num2);
          }
        }
      }
      catch (Exception ex)
      {
      }
      finally
      {
        Advapi32.CloseServiceHandle(num1);
      }
      return flag;
    }

    public static bool StartService(string serviceName)
    {
      IntPtr num1 = AsusAPIClass.OpenSCManager(ScmAccessRights.Connect);
      bool flag = false;
      try
      {
        IntPtr num2 = Advapi32.OpenService(num1, serviceName, ServiceAccessRights.QueryStatus | ServiceAccessRights.Start);
        if (num2 != IntPtr.Zero)
        {
          try
          {
            flag = AsusAPIClass.StartService(num2);
          }
          catch (Exception ex)
          {
          }
          finally
          {
            Advapi32.CloseServiceHandle(num2);
          }
        }
      }
      catch (Exception ex)
      {
      }
      finally
      {
        Advapi32.CloseServiceHandle(num1);
      }
      return flag;
    }

    public static bool StopService(string serviceName)
    {
      IntPtr num1 = AsusAPIClass.OpenSCManager(ScmAccessRights.Connect);
      bool flag = false;
      try
      {
        IntPtr num2 = Advapi32.OpenService(num1, serviceName, ServiceAccessRights.QueryStatus | ServiceAccessRights.Stop);
        if (num2 != IntPtr.Zero)
        {
          try
          {
            flag = AsusAPIClass.StopService(num2);
          }
          catch (Exception ex)
          {
          }
          finally
          {
            Advapi32.CloseServiceHandle(num2);
          }
        }
      }
      catch (Exception ex)
      {
      }
      finally
      {
        Advapi32.CloseServiceHandle(num1);
      }
      return flag;
    }

    private static bool StartService(IntPtr service)
    {
      if (Advapi32.StartService(service, 0, 0) != 0)
        return AsusAPIClass.WaitForServiceStatus(service, ServiceState.StartPending, ServiceState.Running);
      return false;
    }

    private static bool StopService(IntPtr service)
    {
      SERVICE_STATUS lpServiceStatus = new SERVICE_STATUS();
      Advapi32.ControlService(service, ServiceControl.Stop, lpServiceStatus);
      return AsusAPIClass.WaitForServiceStatus(service, ServiceState.StopPending, ServiceState.Stopped);
    }

    public static ServiceState GetServiceStatus(string serviceName)
    {
      IntPtr num1 = AsusAPIClass.OpenSCManager(ScmAccessRights.Connect);
      ServiceState serviceState = ServiceState.NotFound;
      try
      {
        IntPtr num2 = Advapi32.OpenService(num1, serviceName, ServiceAccessRights.QueryStatus);
        if (num2 == IntPtr.Zero)
          return serviceState;
        try
        {
          serviceState = AsusAPIClass.GetServiceStatus(num2);
        }
        catch (Exception ex)
        {
        }
        finally
        {
          Advapi32.CloseServiceHandle(num2);
        }
      }
      finally
      {
        Advapi32.CloseServiceHandle(num1);
      }
      return serviceState;
    }

    private static ServiceState GetServiceStatus(IntPtr service)
    {
      SERVICE_STATUS lpServiceStatus = new SERVICE_STATUS();
      Advapi32.QueryServiceStatus(service, lpServiceStatus);
      return lpServiceStatus.dwCurrentState;
    }

    private static bool WaitForServiceStatus(IntPtr service, ServiceState waitStatus, ServiceState desiredStatus)
    {
      SERVICE_STATUS lpServiceStatus = new SERVICE_STATUS();
      Advapi32.QueryServiceStatus(service, lpServiceStatus);
      if (lpServiceStatus.dwCurrentState == desiredStatus)
        return true;
      int tickCount = Environment.TickCount;
      int dwCheckPoint = lpServiceStatus.dwCheckPoint;
      while (lpServiceStatus.dwCurrentState == waitStatus)
      {
        int millisecondsTimeout = lpServiceStatus.dwWaitHint / 10;
        if (millisecondsTimeout < 1000)
          millisecondsTimeout = 1000;
        else if (millisecondsTimeout > 10000)
          millisecondsTimeout = 10000;
        Thread.Sleep(millisecondsTimeout);
        if (Advapi32.QueryServiceStatus(service, lpServiceStatus) != 0)
        {
          if (lpServiceStatus.dwCheckPoint > dwCheckPoint)
          {
            tickCount = Environment.TickCount;
            dwCheckPoint = lpServiceStatus.dwCheckPoint;
          }
          else if (Environment.TickCount - tickCount > lpServiceStatus.dwWaitHint)
            break;
        }
        else
          break;
      }
      return lpServiceStatus.dwCurrentState == desiredStatus;
    }

    public static IntPtr OpenSCManager(ScmAccessRights rights)
    {
      return Advapi32.OpenSCManager((string) null, (string) null, rights);
    }

    private static bool MatchHardwareId(string HardwareId, ref byte[] HrdwareBytes)
    {
      string empty = string.Empty;
      int length = HardwareId.Length;
      int index1;
      for (int index2 = 0; index2 < HrdwareBytes.Length - 2; index2 = index1 + 1)
      {
        int index3 = index2;
        index1 = index2 + 2;
        while (index1 < HrdwareBytes.Length - 1)
        {
          if (HrdwareBytes[index1] == (byte) 0 && HrdwareBytes[index1 + 1] == (byte) 0)
          {
            ++index1;
            break;
          }
          index1 += 2;
        }
        if (index1 - index3 + 1 > HardwareId.Length && Encoding.Unicode.GetString(HrdwareBytes, index3, index1 - index3 + 1).ToUpper().Contains(HardwareId))
          return true;
      }
      return false;
    }

    public static bool IsExistHardwareDevice(string Class, string HardwareId)
    {
      Guid empty = Guid.Empty;
      IntPtr classDevs = Setupapi.SetupDiGetClassDevs(ref empty, IntPtr.Zero, IntPtr.Zero, DiGetClassFlags.DIGCF_ALLCLASSES);
      if (classDevs == new IntPtr(-1))
        return false;
      SP_DEVINFO_DATA DeviceInfoData = new SP_DEVINFO_DATA();
      DeviceInfoData.cbSize = (uint) Marshal.SizeOf<SP_DEVINFO_DATA>((M0) DeviceInfoData);
      uint MemberIndex = 0;
      int length = 50;
      byte[] HrdwareBytes = new byte[length];
      DEVPROPKEY propertyKey1 = DEVPKEY_Device.Class();
      DEVPROPKEY propertyKey2 = DEVPKEY_Device.HardwareIds();
      IntPtr zero = IntPtr.Zero;
      IntPtr num = Marshal.AllocHGlobal(length);
      int requiredSize = 0;
      bool flag = true;
      while (flag)
      {
        flag = Setupapi.SetupDiEnumDeviceInfo(classDevs, MemberIndex, ref DeviceInfoData);
        ++MemberIndex;
        if (flag && Setupapi.SetupDiGetDeviceProperty(classDevs, ref DeviceInfoData, ref propertyKey1, ref zero, num, length, out requiredSize, 0U) && Marshal.PtrToStringAuto(num).Contains(Class))
        {
          requiredSize = 0;
          Setupapi.SetupDiGetDeviceProperty(classDevs, ref DeviceInfoData, ref propertyKey2, ref zero, IntPtr.Zero, 0, out requiredSize, 0U);
          if (requiredSize > 0)
          {
            if (requiredSize > length)
            {
              Marshal.FreeHGlobal(num);
              length = requiredSize;
              num = Marshal.AllocHGlobal(length);
              HrdwareBytes = new byte[length];
            }
            if (Setupapi.SetupDiGetDeviceProperty(classDevs, ref DeviceInfoData, ref propertyKey2, ref zero, num, length, out requiredSize, 0U))
            {
              Marshal.Copy(num, HrdwareBytes, 0, requiredSize);
              if (AsusAPIClass.MatchHardwareId(HardwareId, ref HrdwareBytes))
              {
                flag = true;
                break;
              }
            }
          }
        }
      }
      Marshal.FreeHGlobal(num);
      Setupapi.SetupDiDestroyDeviceInfoList(classDevs);
      return flag;
    }

    public static bool IsASUSMachine()
    {
      bool flag = false;
      try
      {
        foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem").Get())
        {
          object obj = managementBaseObject["Manufacturer"];
          if (obj != null && obj.ToString() == "ASUSTeK COMPUTER INC.")
          {
            flag = true;
            break;
          }
        }
      }
      catch (Exception ex)
      {
      }
      return flag;
    }

    public static bool SetFullControl(RegistryHive regHive, RegistryView regView, string TargetKey)
    {
      RegistryKey registryKey1 = RegistryKey.OpenBaseKey(regHive, regView);
      bool flag = false;
      if (registryKey1 != null)
      {
        try
        {
          RegistryKey registryKey2 = registryKey1.OpenSubKey(TargetKey, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
          if (registryKey2 != null)
          {
            RegistrySecurity registrySecurity = new RegistrySecurity();
            string identity = new SecurityIdentifier("S-1-1-0").Translate(typeof (NTAccount)).ToString();
            RegistryAccessRule rule = new RegistryAccessRule(identity, RegistryRights.FullControl, AccessControlType.Allow);
            registrySecurity.SetAccessRule(rule);
            registrySecurity.AddAccessRule(new RegistryAccessRule(identity, RegistryRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
            registryKey2.SetAccessControl(registrySecurity);
            registryKey2.Close();
          }
        }
        catch (Exception ex)
        {
        }
        registryKey1.Close();
      }
      return flag;
    }

    public static int MAKEWPARAM(int l, int h)
    {
      return l & (int) ushort.MaxValue | h << 16;
    }

    public static bool ATKWindowFunction(AsusAPIClass.ATKWindowCommand command)
    {
      bool flag = false;
      try
      {
        uint Msg = 273;
        IntPtr window = User32.FindWindow("ATKMEDIA", "ATKMEDIA");
        if (window != IntPtr.Zero)
        {
          int num = 2327;
          int h = (int) command;
          IntPtr dlgItem = User32.GetDlgItem(window, num);
          int wParam = AsusAPIClass.MAKEWPARAM(num, h);
          flag = User32.PostMessage(window, Msg, wParam, dlgItem);
        }
      }
      catch (Exception ex)
      {
      }
      return flag;
    }

    public static bool PTPIsEnabled()
    {
      bool flag = false;
      RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PrecisionTouchPad\\Status");
      if (registryKey != null)
      {
        object obj = registryKey.GetValue("Enabled", (object) 0);
        if (obj != null)
          flag = (uint) (int) obj > 0U;
      }
      return flag;
    }

    public static void Restart()
    {
      try
      {
        ManagementClass managementClass = new ManagementClass("Win32_OperatingSystem");
        managementClass.Get();
        managementClass.Scope.Options.EnablePrivileges = true;
        ManagementBaseObject methodParameters = managementClass.GetMethodParameters("Win32Shutdown");
        methodParameters["Flags"] = (object) "2";
        methodParameters["Reserved"] = (object) "0";
        foreach (ManagementObject instance in managementClass.GetInstances())
          instance.InvokeMethod("Win32Shutdown", methodParameters, (InvokeMethodOptions) null);
      }
      catch (Exception ex)
      {
      }
    }

    [HandleProcessCorruptedStateExceptions]
    public static string GetAppxPackagePathFromPackageFamilyName(string PackageFamilyName)
    {
      string str = string.Empty;
      uint count1 = 0;
      uint bufferLength1 = 0;
      IntPtr num1 = Marshal.AllocHGlobal(1024);
      IntPtr num2 = Marshal.AllocHGlobal(1024);
      try
      {
        int packagesByPackageFamily = (int) Kernel32.FindPackagesByPackageFamily(PackageFamilyName, Kernel32.PACKAGE_FILTER_DIRECT | Kernel32.PACKAGE_FILTER_HEAD, ref count1, IntPtr.Zero, ref bufferLength1, IntPtr.Zero, IntPtr.Zero);
        if (count1 >= 1U)
        {
          if (Kernel32.FindPackagesByPackageFamily(PackageFamilyName, Kernel32.PACKAGE_FILTER_DIRECT | Kernel32.PACKAGE_FILTER_HEAD, ref count1, num1, ref bufferLength1, num2, IntPtr.Zero) == 0U)
          {
            IntPtr ptr = Marshal.ReadIntPtr(num1);
            if (ptr != IntPtr.Zero)
            {
              if (Kernel32.OpenPackageInfoByFullName(Marshal.PtrToStringUni(ptr), 0U, num2) == 0U)
              {
                uint count2 = 1024;
                uint bufferLength2 = 1024;
                if (Kernel32.GetPackageInfo(Marshal.ReadIntPtr(num2), Kernel32.PACKAGE_FILTER_DIRECT | Kernel32.PACKAGE_FILTER_HEAD, ref bufferLength2, num2, ref count2) == 0U)
                  str = Marshal.PtrToStringUni(((PACKAGE_INFO) Marshal.PtrToStructure(num2, typeof (PACKAGE_INFO))).path);
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        str = string.Empty;
      }
      finally
      {
        if (num1 != IntPtr.Zero)
          Marshal.FreeHGlobal(num1);
        if (num2 != IntPtr.Zero)
          Marshal.FreeHGlobal(num2);
        IntPtr zero1 = IntPtr.Zero;
        IntPtr zero2 = IntPtr.Zero;
      }
      return str;
    }

    public static void RunMetroApp(string appUserModelId)
    {
      try
      {
        IntPtr zero1 = IntPtr.Zero;
        Guid guid = new Guid("2e941141-7f97-4756-ba1d-9decde894a3d");
        Guid rclsid = new Guid("45BA127D-10A8-46EA-8AB7-56EA9078943C");
        Ole32.CoInitializeEx(IntPtr.Zero, CoInit.ApartmentThreaded);
        IntPtr zero2 = IntPtr.Zero;
        int num = 4;
        Guid riid = guid;
        ref IntPtr local = ref zero1;
        if (Ole32.CoCreateInstance(rclsid, zero2, (CLSCTX) num, riid, out local) != 0U || !(zero1 != IntPtr.Zero))
          return;
        IApplicationActivationManager objectForIunknown = (IApplicationActivationManager) Marshal.GetObjectForIUnknown(zero1);
        if (objectForIunknown == null)
          return;
        Ole32.CoAllowSetForegroundWindow((object) objectForIunknown, IntPtr.Zero);
        uint processId;
        objectForIunknown.ActivateApplication(appUserModelId, (string) null, ActivateOptions.None, out processId);
        Marshal.ReleaseComObject((object) objectForIunknown);
        Marshal.Release(zero1);
      }
      catch (Exception ex)
      {
      }
      finally
      {
        Ole32.CoUninitialize();
      }
    }

    public static int CPUVenderID()
    {
      int num = 0;
      RegistryKey localMachine = Registry.LocalMachine;
      if (localMachine != null)
      {
        RegistryKey registryKey = localMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
        if (registryKey != null)
        {
          object obj = registryKey.GetValue("VendorIdentifier", (object) "Intel");
          if (obj != null)
          {
            string str = obj.ToString();
            Logger.log_info("CPU Vendor - : " + str, "ROGOverclockBaseClass", MethodBase.GetCurrentMethod().Name);
            if (str.ToLower().Contains("amd"))
              num = 1;
          }
          registryKey.Close();
        }
        localMachine.Close();
      }
      Logger.log_info("CPU Vendor ID - : " + (object) num, "ROGOverclockBaseClass", MethodBase.GetCurrentMethod().Name);
      return num;
    }

    public enum ATKWindowCommand
    {
      SwitchToDeskTop = 31, // 0x0000001F
      DisablePTP = 60, // 0x0000003C
      EnablePTP = 61, // 0x0000003D
    }
  }
}
