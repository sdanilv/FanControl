// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskScheduler.IRegistrationInfo
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsusWin32API.TaskScheduler
{
  [Guid("416D8B73-CB41-4ea1-805C-9BE9A5AC4A74")]
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [ComImport]
  public interface IRegistrationInfo
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Description([Out] string pDescription);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Description([In] string description);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Author(out string pAuthor);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Author([In] string author);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Version(out string pVersion);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Version([In] string version);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Date(out string pDate);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Date([In] string date);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Documentation(out string pDocumentation);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Documentation([In] string documentation);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_XmlText(out string pText);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_XmlText([In] string text);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_URI(out string pUri);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_URI([In] string uri);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_SecurityDescriptor(out VARIANT pSddl);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_SecurityDescriptor(VARIANT sddl);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Source(out string pSource);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT put_Source(string source);
  }
}
