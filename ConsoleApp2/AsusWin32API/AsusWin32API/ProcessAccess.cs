// Decompiled with JetBrains decompiler
// Type: AsusWin32API.ProcessAccess
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

namespace AsusWin32API
{
  public enum ProcessAccess
  {
    Terminate = 1,
    CreateThread = 2,
    VMOperation = 8,
    VMRead = 16, // 0x00000010
    VMWrite = 32, // 0x00000020
    DuplicateHandle = 64, // 0x00000040
    SetInformation = 512, // 0x00000200
    QueryInformation = 1024, // 0x00000400
    Synchronize = 1048576, // 0x00100000
    AllAccess = 1050235, // 0x0010067B
    MAXIMUM_ALLOWED = 33554432, // 0x02000000
  }
}
