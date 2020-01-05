// Decompiled with JetBrains decompiler
// Type: NetFwTypeLib.INetFwMgr
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFwTypeLib
{
  [CompilerGenerated]
  [Guid("F7898AF5-CAC4-4632-A2EC-DA06E5111AF2")]
  [TypeIdentifier]
  [ComImport]
  public interface INetFwMgr
  {
    [DispId(1)]
    INetFwPolicy LocalPolicy { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }
  }
}
