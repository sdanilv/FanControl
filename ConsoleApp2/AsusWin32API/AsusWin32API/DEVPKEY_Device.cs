// Decompiled with JetBrains decompiler
// Type: AsusWin32API.DEVPKEY_Device
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;

namespace AsusWin32API
{
  public static class DEVPKEY_Device
  {
    public static DEVPROPKEY Class()
    {
      return new DEVPROPKEY()
      {
        fmtid = new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"),
        pid = 9
      };
    }

    public static DEVPROPKEY MatchingDeviceId()
    {
      return new DEVPROPKEY()
      {
        fmtid = new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"),
        pid = 8
      };
    }

    public static DEVPROPKEY HardwareIds()
    {
      return new DEVPROPKEY()
      {
        fmtid = new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"),
        pid = 3
      };
    }
  }
}
