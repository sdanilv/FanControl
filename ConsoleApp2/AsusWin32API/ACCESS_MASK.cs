﻿// Decompiled with JetBrains decompiler
// Type: AsusWin32API.ACCESS_MASK
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

namespace AsusWin32API
{
  public enum ACCESS_MASK : uint
  {
    DESKTOP_READOBJECTS = 1,
    WINSTA_ENUMDESKTOPS = 1,
    DESKTOP_CREATEWINDOW = 2,
    WINSTA_READATTRIBUTES = 2,
    DESKTOP_CREATEMENU = 4,
    WINSTA_ACCESSCLIPBOARD = 4,
    DESKTOP_HOOKCONTROL = 8,
    WINSTA_CREATEDESKTOP = 8,
    DESKTOP_JOURNALRECORD = 16, // 0x00000010
    WINSTA_WRITEATTRIBUTES = 16, // 0x00000010
    DESKTOP_JOURNALPLAYBACK = 32, // 0x00000020
    WINSTA_ACCESSGLOBALATOMS = 32, // 0x00000020
    DESKTOP_ENUMERATE = 64, // 0x00000040
    WINSTA_EXITWINDOWS = 64, // 0x00000040
    DESKTOP_WRITEOBJECTS = 128, // 0x00000080
    DESKTOP_SWITCHDESKTOP = 256, // 0x00000100
    WINSTA_ENUMERATE = 256, // 0x00000100
    WINSTA_READSCREEN = 512, // 0x00000200
    WINSTA_ALL_ACCESS = 895, // 0x0000037F
    SPECIFIC_RIGHTS_ALL = 65535, // 0x0000FFFF
    DELETE = 65536, // 0x00010000
    READ_CONTROL = 131072, // 0x00020000
    STANDARD_RIGHTS_EXECUTE = 131072, // 0x00020000
    STANDARD_RIGHTS_READ = 131072, // 0x00020000
    STANDARD_RIGHTS_WRITE = 131072, // 0x00020000
    WRITE_DAC = 262144, // 0x00040000
    WRITE_OWNER = 524288, // 0x00080000
    STANDARD_RIGHTS_REQUIRED = 983040, // 0x000F0000
    SYNCHRONIZE = 1048576, // 0x00100000
    STANDARD_RIGHTS_ALL = 2031616, // 0x001F0000
    ACCESS_SYSTEM_SECURITY = 16777216, // 0x01000000
    MAXIMUM_ALLOWED = 33554432, // 0x02000000
    GENERIC_ALL = 268435456, // 0x10000000
    GENERIC_EXECUTE = 536870912, // 0x20000000
    GENERIC_WRITE = 1073741824, // 0x40000000
    GENERIC_READ = 2147483648, // 0x80000000
  }
}
