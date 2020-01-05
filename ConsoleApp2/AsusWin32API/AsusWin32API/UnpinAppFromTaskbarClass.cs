// Decompiled with JetBrains decompiler
// Type: AsusWin32API.UnpinAppFromTaskbarClass
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;

namespace AsusWin32API
{
  public class UnpinAppFromTaskbarClass
  {
    private static IntPtr _myToken;
    private static TokPriv1Luid _tokenPrivileges;
    private static TokPriv1Luid _tokenPrivileges2;
    private static LUID _restoreLuid;
    private static LUID _backupLuid;

    public static bool CompareApp(ref byte[] FavoritesData, int StartIndex, int Len, ref byte[] CompareData)
    {
      bool flag = false;
      for (int index1 = StartIndex; index1 < StartIndex + Len; ++index1)
      {
        flag = true;
        for (int index2 = 0; index2 < CompareData.Length; ++index2)
        {
          if ((int) FavoritesData[index1 + index2] != (int) CompareData[index2])
          {
            flag = false;
            break;
          }
        }
        if (flag)
          break;
      }
      return flag;
    }

    public static void RemoveFavorite(ref byte[] FavoritesData, string AppName, out byte[] newFaorites)
    {
      int destinationIndex = 1;
      byte[] bytes = Encoding.Unicode.GetBytes(AppName);
      byte[] numArray1 = new byte[FavoritesData.Length];
      newFaorites = (byte[]) null;
      if (FavoritesData == null)
        return;
      int int32;
      for (int index = 1; index < FavoritesData.Length - 4; index = index + int32 + 4 + 1)
      {
        int32 = BitConverter.ToInt32(FavoritesData, index);
        if (!UnpinAppFromTaskbarClass.CompareApp(ref FavoritesData, index + 4, int32, ref bytes))
        {
          Array.Copy((Array) FavoritesData, index, (Array) numArray1, destinationIndex, int32 + 4);
          destinationIndex = destinationIndex + int32 + 4 + 1;
        }
      }
      byte[] numArray2 = numArray1;
      int index1 = destinationIndex;
      int num1 = index1 + 1;
      int num2 = 0;
      numArray2[index1] = (byte) num2;
      byte[] numArray3 = numArray1;
      int index2 = num1;
      int num3 = index2 + 1;
      int num4 = 0;
      numArray3[index2] = (byte) num4;
      byte[] numArray4 = numArray1;
      int index3 = num3;
      int num5 = index3 + 1;
      int num6 = 0;
      numArray4[index3] = (byte) num6;
      byte[] numArray5 = numArray1;
      int index4 = num5;
      int length = index4 + 1;
      int maxValue = (int) byte.MaxValue;
      numArray5[index4] = (byte) maxValue;
      newFaorites = new byte[length];
      Array.Copy((Array) numArray1, 0, (Array) newFaorites, 0, length);
    }

    public static bool CheckFavoriteData(ref byte[] FavoritesData)
    {
      bool flag = true;
      int num1 = 1;
      if (FavoritesData != null)
      {
        int int32;
        for (int startIndex = 1; startIndex < FavoritesData.Length - 4; startIndex = startIndex + int32 + 4 + 1)
        {
          int32 = BitConverter.ToInt32(FavoritesData, startIndex);
          num1 = num1 + int32 + 4 + 1;
          if (num1 > FavoritesData.Length - 4)
          {
            flag = false;
            break;
          }
        }
        if (flag)
        {
          flag = false;
          byte[] numArray1 = FavoritesData;
          int index1 = num1;
          int num2 = index1 + 1;
          int num3 = (int) numArray1[index1];
          byte[] numArray2 = FavoritesData;
          int index2 = num2;
          int num4 = index2 + 1;
          int num5 = (int) numArray2[index2];
          int num6 = num3 + num5;
          byte[] numArray3 = FavoritesData;
          int index3 = num4;
          int num7 = index3 + 1;
          int num8 = (int) numArray3[index3];
          if (num6 + num8 == 0)
          {
            byte[] numArray4 = FavoritesData;
            int index4 = num7;
            int num9 = index4 + 1;
            if (numArray4[index4] == byte.MaxValue)
              flag = true;
          }
        }
      }
      return flag;
    }

    public static void RemoveFavoritesResolve(ref byte[] FavoritesData, string AppName, out byte[] newFaorites)
    {
      int length = 0;
      byte[] bytes = Encoding.Unicode.GetBytes(AppName);
      byte[] numArray = new byte[FavoritesData.Length];
      newFaorites = (byte[]) null;
      if (FavoritesData == null)
        return;
      int int32;
      for (int index = 0; index < FavoritesData.Length; index = index + int32 + 4 - 1 + 1)
      {
        int32 = BitConverter.ToInt32(FavoritesData, index);
        if (!UnpinAppFromTaskbarClass.CompareApp(ref FavoritesData, index + 4, int32, ref bytes))
        {
          Array.Copy((Array) FavoritesData, index, (Array) numArray, length, int32 + 4);
          length = length + int32 + 4;
        }
      }
      newFaorites = new byte[length];
      Array.Copy((Array) numArray, 0, (Array) newFaorites, 0, length);
    }

    public static bool CheckFavoriteResolveData(ref byte[] FavoritesData)
    {
      bool flag = true;
      int num = 0;
      int int32;
      if (FavoritesData != null)
      {
        for (int startIndex = 0; startIndex < FavoritesData.Length; startIndex = startIndex + int32 + 4 - 1 + 1)
        {
          int32 = BitConverter.ToInt32(FavoritesData, startIndex);
          num = num + int32 + 4;
          if (num > FavoritesData.Length)
          {
            flag = false;
            break;
          }
        }
      }
      return flag;
    }

    public static bool RemoveByOfflineRegistry(string UserName, string AppName)
    {
      if (!Advapi32.OpenProcessToken(Kernel32.GetCurrentProcess(), 40U, out UnpinAppFromTaskbarClass._myToken) || !Advapi32.LookupPrivilegeValue((string) null, Advapi32.SE_RESTORE_NAME, out UnpinAppFromTaskbarClass._restoreLuid) || !Advapi32.LookupPrivilegeValue((string) null, Advapi32.SE_BACKUP_NAME, out UnpinAppFromTaskbarClass._backupLuid))
        return false;
      UnpinAppFromTaskbarClass._tokenPrivileges.Attr = 2U;
      UnpinAppFromTaskbarClass._tokenPrivileges.Luid = UnpinAppFromTaskbarClass._restoreLuid;
      UnpinAppFromTaskbarClass._tokenPrivileges.Count = 1;
      UnpinAppFromTaskbarClass._tokenPrivileges2.Attr = 2U;
      UnpinAppFromTaskbarClass._tokenPrivileges2.Luid = UnpinAppFromTaskbarClass._backupLuid;
      UnpinAppFromTaskbarClass._tokenPrivileges2.Count = 1;
      if (!Advapi32.AdjustTokenPrivileges(UnpinAppFromTaskbarClass._myToken, false, ref UnpinAppFromTaskbarClass._tokenPrivileges, 0, IntPtr.Zero, IntPtr.Zero))
        return false;
      if (!Advapi32.AdjustTokenPrivileges(UnpinAppFromTaskbarClass._myToken, false, ref UnpinAppFromTaskbarClass._tokenPrivileges2, 0, IntPtr.Zero, IntPtr.Zero))
        return false;
      try
      {
        if (Advapi32.RegLoadKey(HKEY.USERS, "LoadRegistry", "C:\\Users\\" + UserName + "\\NTUSER.DAT") != 0)
          return false;
        object defaultValue = (object) null;
        byte[] FavoritesData1 = (byte[]) Registry.GetValue("HKEY_USERS\\LoadRegistry\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Taskband", "Favorites", defaultValue);
        byte[] newFaorites1 = (byte[]) null;
        UnpinAppFromTaskbarClass.RemoveFavorite(ref FavoritesData1, AppName, out newFaorites1);
        byte[] FavoritesData2 = (byte[]) Registry.GetValue("HKEY_USERS\\LoadRegistry\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Taskband", "FavoritesResolve", defaultValue);
        byte[] newFaorites2 = (byte[]) null;
        UnpinAppFromTaskbarClass.RemoveFavoritesResolve(ref FavoritesData2, AppName, out newFaorites2);
        if (newFaorites1 != null)
        {
          if (newFaorites2 != null)
          {
            if (UnpinAppFromTaskbarClass.CheckFavoriteData(ref newFaorites1))
            {
              if (UnpinAppFromTaskbarClass.CheckFavoriteResolveData(ref newFaorites2))
              {
                Registry.SetValue("HKEY_USERS\\LoadRegistry\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Taskband", "Favorites", (object) newFaorites1, RegistryValueKind.Binary);
                Registry.SetValue("HKEY_USERS\\LoadRegistry\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Taskband", "FavoritesResolve", (object) newFaorites2, RegistryValueKind.Binary);
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
      }
      finally
      {
        Advapi32.RegUnLoadKey(HKEY.USERS, "LoadRegistry");
      }
      return true;
    }

    public static void RemoveByOnlineRegistry(string UserName, string AppName)
    {
      byte[] numArray = (byte[]) null;
      uint cbSid = 0;
      StringBuilder ReferencedDomainName = new StringBuilder();
      uint capacity = (uint) ReferencedDomainName.Capacity;
      int num = Advapi32.NO_ERROR;
      SID_NAME_USE peUse;
      if (!Advapi32.LookupAccountName((string) null, UserName, numArray, ref cbSid, ReferencedDomainName, ref capacity, out peUse))
      {
        num = Marshal.GetLastWin32Error();
        if (num == Advapi32.ERROR_INSUFFICIENT_BUFFER || num == Advapi32.ERROR_INVALID_FLAGS)
        {
          numArray = new byte[(int) cbSid];
          ReferencedDomainName.EnsureCapacity((int) capacity);
          num = Advapi32.NO_ERROR;
          if (!Advapi32.LookupAccountName((string) null, UserName, numArray, ref cbSid, ReferencedDomainName, ref capacity, out peUse))
            num = Marshal.GetLastWin32Error();
        }
      }
      if (num != Advapi32.NO_ERROR || numArray == null)
        return;
      SecurityIdentifier securityIdentifier = new SecurityIdentifier(numArray, 0);
      RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default);
      byte[] newFaorites1 = (byte[]) null;
      byte[] newFaorites2 = (byte[]) null;
      object defaultValue = (object) null;
      if (registryKey1 == null)
        return;
      RegistryKey registryKey2 = (RegistryKey) null;
      RegistryKey registryKey3 = (RegistryKey) null;
      try
      {
        registryKey3 = registryKey1.OpenSubKey(securityIdentifier.ToString() + "\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Taskband", true);
        if (registryKey3 != null)
        {
          byte[] FavoritesData = (byte[]) registryKey3.GetValue("Favorites", defaultValue);
          UnpinAppFromTaskbarClass.RemoveFavorite(ref FavoritesData, AppName, out newFaorites1);
        }
        registryKey2 = registryKey1.OpenSubKey(securityIdentifier.ToString() + "\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Taskband", true);
        if (registryKey2 != null)
        {
          byte[] FavoritesData = (byte[]) registryKey2.GetValue("FavoritesResolve", defaultValue);
          UnpinAppFromTaskbarClass.RemoveFavoritesResolve(ref FavoritesData, AppName, out newFaorites2);
        }
        if (newFaorites1 != null)
        {
          if (newFaorites2 != null)
          {
            if (UnpinAppFromTaskbarClass.CheckFavoriteData(ref newFaorites1))
            {
              if (UnpinAppFromTaskbarClass.CheckFavoriteResolveData(ref newFaorites2))
              {
                registryKey3.SetValue("Favorites", (object) newFaorites1, RegistryValueKind.Binary);
                registryKey2.SetValue("FavoritesResolve", (object) newFaorites2, RegistryValueKind.Binary);
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
      }
      finally
      {
        registryKey2?.Close();
        registryKey3?.Close();
      }
      registryKey1.Close();
    }

    public static bool RemoveShortCut(string UserName, string AppName)
    {
      string str = "C:\\Users\\" + UserName + "\\AppData\\Roaming\\Microsoft\\Internet Explorer\\Quick Launch\\User Pinned\\TaskBar\\";
      if (!File.Exists(str + AppName + ".lnk"))
        return false;
      File.Delete(str + AppName + ".lnk");
      return true;
    }

    public static bool RemoveByProcess(uint uiSessionID, string installFolder, string strShortcutStartMenuDir, string appName)
    {
      string str = strShortcutStartMenuDir + appName + ".lnk";
      bool flag = false;
      IntPtr phNewToken = IntPtr.Zero;
      IntPtr Token = IntPtr.Zero;
      IntPtr lpEnvironment = IntPtr.Zero;
      if (uiSessionID > 0U)
        flag = true;
      if (flag)
        flag = Wtsapi32.WTSQueryUserToken(uiSessionID, out Token);
      SECURITY_ATTRIBUTES lpTokenAttributes = new SECURITY_ATTRIBUTES();
      lpTokenAttributes.nLength = Marshal.SizeOf<SECURITY_ATTRIBUTES>((M0) lpTokenAttributes);
      if (flag)
        flag = Advapi32.DuplicateTokenEx(Token, ACCESS_MASK.MAXIMUM_ALLOWED, ref lpTokenAttributes, SECURITY_IMPERSONATION_LEVEL.SecurityIdentification, TOKEN_TYPE.TokenPrimary, out phNewToken);
      if (flag)
        flag = Userenv.CreateEnvironmentBlock(out lpEnvironment, phNewToken, true);
      SECURITY_ATTRIBUTES lpProcessAttributes = new SECURITY_ATTRIBUTES();
      lpProcessAttributes.nLength = Marshal.SizeOf<SECURITY_ATTRIBUTES>((M0) lpProcessAttributes);
      SECURITY_ATTRIBUTES lpThreadAttributes = new SECURITY_ATTRIBUTES();
      lpThreadAttributes.nLength = Marshal.SizeOf<SECURITY_ATTRIBUTES>((M0) lpThreadAttributes);
      STARTUPINFO lpStartupInfo = new STARTUPINFO()
      {
        lpDesktop = "WinSta0\\Default",
        dwFlags = 65,
        wShowWindow = (short) User32.SW_HIDE
      };
      lpStartupInfo.cb = Marshal.SizeOf<STARTUPINFO>((M0) lpStartupInfo);
      if (flag)
      {
        PROCESS_INFORMATION lpProcessInformation = new PROCESS_INFORMATION();
        flag = Advapi32.CreateProcessAsUser(phNewToken, installFolder + "\\UnPinApp.exe", "\"" + str + "\"", ref lpProcessAttributes, ref lpThreadAttributes, false, CreateProcessFlags.CREATE_NEW_CONSOLE | CreateProcessFlags.CREATE_UNICODE_ENVIRONMENT | CreateProcessFlags.NORMAL_PRIORITY_CLASS, lpEnvironment, (string) null, ref lpStartupInfo, ref lpProcessInformation);
      }
      Advapi32.RevertToSelf();
      if (Token != IntPtr.Zero)
        Marshal.Release(Token);
      if (phNewToken != IntPtr.Zero)
        Marshal.Release(phNewToken);
      if (lpEnvironment != IntPtr.Zero)
        Userenv.DestroyEnvironmentBlock(lpEnvironment);
      return flag;
    }

    public static bool RemoveByProcess(uint uiSessionID, string installFolder, string target)
    {
      bool flag = false;
      IntPtr phNewToken = IntPtr.Zero;
      IntPtr Token = IntPtr.Zero;
      IntPtr lpEnvironment = IntPtr.Zero;
      if (uiSessionID > 0U)
        flag = true;
      if (flag)
        flag = Wtsapi32.WTSQueryUserToken(uiSessionID, out Token);
      SECURITY_ATTRIBUTES lpTokenAttributes = new SECURITY_ATTRIBUTES();
      lpTokenAttributes.nLength = Marshal.SizeOf<SECURITY_ATTRIBUTES>((M0) lpTokenAttributes);
      if (flag)
        flag = Advapi32.DuplicateTokenEx(Token, ACCESS_MASK.MAXIMUM_ALLOWED, ref lpTokenAttributes, SECURITY_IMPERSONATION_LEVEL.SecurityIdentification, TOKEN_TYPE.TokenPrimary, out phNewToken);
      if (flag)
        flag = Userenv.CreateEnvironmentBlock(out lpEnvironment, phNewToken, true);
      SECURITY_ATTRIBUTES lpProcessAttributes = new SECURITY_ATTRIBUTES();
      lpProcessAttributes.nLength = Marshal.SizeOf<SECURITY_ATTRIBUTES>((M0) lpProcessAttributes);
      SECURITY_ATTRIBUTES lpThreadAttributes = new SECURITY_ATTRIBUTES();
      lpThreadAttributes.nLength = Marshal.SizeOf<SECURITY_ATTRIBUTES>((M0) lpThreadAttributes);
      STARTUPINFO lpStartupInfo = new STARTUPINFO()
      {
        lpDesktop = "WinSta0\\Default",
        dwFlags = 65,
        wShowWindow = (short) User32.SW_HIDE
      };
      lpStartupInfo.cb = Marshal.SizeOf<STARTUPINFO>((M0) lpStartupInfo);
      if (flag)
      {
        PROCESS_INFORMATION lpProcessInformation = new PROCESS_INFORMATION();
        flag = Advapi32.CreateProcessAsUser(phNewToken, installFolder + "\\UnPinApp.exe", "\"" + target + "\"", ref lpProcessAttributes, ref lpThreadAttributes, false, CreateProcessFlags.CREATE_NEW_CONSOLE | CreateProcessFlags.CREATE_UNICODE_ENVIRONMENT | CreateProcessFlags.NORMAL_PRIORITY_CLASS, lpEnvironment, (string) null, ref lpStartupInfo, ref lpProcessInformation);
      }
      Advapi32.RevertToSelf();
      if (Token != IntPtr.Zero)
        Marshal.Release(Token);
      if (phNewToken != IntPtr.Zero)
        Marshal.Release(phNewToken);
      if (lpEnvironment != IntPtr.Zero)
        Userenv.DestroyEnvironmentBlock(lpEnvironment);
      return flag;
    }

    public static uint GetUserSessionID(string UserName)
    {
      IntPtr zero1 = IntPtr.Zero;
      List<string> stringList = new List<string>();
      IntPtr hServer = Wtsapi32.WTSOpenServer((string) null);
      uint num1 = 0;
      try
      {
        IntPtr zero2 = IntPtr.Zero;
        IntPtr ppBuffer = IntPtr.Zero;
        int pCount = 0;
        int num2 = Wtsapi32.WTSEnumerateSessions(hServer, 0, 1, ref zero2, ref pCount);
        int num3 = Marshal.SizeOf(typeof (WTS_SESSION_INFO));
        int num4 = (int) zero2;
        uint pBytesReturned = 0;
        if (num2 != 0)
        {
          for (int index = 0; index < pCount; ++index)
          {
            WTS_SESSION_INFO structure = (WTS_SESSION_INFO) Marshal.PtrToStructure((IntPtr) num4, typeof (WTS_SESSION_INFO));
            num4 += num3;
            Wtsapi32.WTSQuerySessionInformation(hServer, structure.SessionID, WTS_INFO_CLASS.WTSUserName, out ppBuffer, out pBytesReturned);
            if (UserName == Marshal.PtrToStringUni(ppBuffer))
              num1 = Convert.ToUInt32(structure.SessionID);
            Wtsapi32.WTSFreeMemory(ppBuffer);
          }
          Wtsapi32.WTSFreeMemory(zero2);
        }
      }
      finally
      {
        Wtsapi32.WTSCloseServer(hServer);
      }
      return num1;
    }
  }
}
