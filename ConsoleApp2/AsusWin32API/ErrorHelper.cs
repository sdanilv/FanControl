﻿// Decompiled with JetBrains decompiler
// Type: AsusWin32API.ErrorHelper
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;

namespace AsusWin32API
{
  public static class ErrorHelper
  {
    public static void VerifySucceeded(uint hresult)
    {
      if (hresult > 1U)
        throw new Exception("Failed with HRESULT: " + hresult.ToString("X"));
    }
  }
}
