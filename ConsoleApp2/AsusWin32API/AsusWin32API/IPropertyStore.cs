// Decompiled with JetBrains decompiler
// Type: AsusWin32API.IPropertyStore
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using MS.WindowsAPICodePack.Internal;
using System.Runtime.InteropServices;

namespace AsusWin32API
{
  [Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  public interface IPropertyStore
  {
    uint GetCount(out uint propertyCount);

    uint GetAt([In] uint propertyIndex, out PropertyKey key);

    uint GetValue([In] ref PropertyKey key, [Out] PropVariant pv);

    uint SetValue([In] ref PropertyKey key, [In] PropVariant pv);

    uint Commit();
  }
}
