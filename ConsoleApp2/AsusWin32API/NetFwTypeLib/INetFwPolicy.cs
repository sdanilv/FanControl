// Decompiled with JetBrains decompiler
// Type: NetFwTypeLib.INetFwPolicy
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFwTypeLib
{
  [CompilerGenerated]
  [Guid("D46D2478-9AC9-4008-9DC7-5563CE5536CC")]
  [TypeIdentifier]
  [ComImport]
  public interface INetFwPolicy
  {
    [DispId(1)]
    INetFwProfile CurrentProfile { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }
  }
}
