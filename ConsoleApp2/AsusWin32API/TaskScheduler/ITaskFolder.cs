// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskScheduler.ITaskFolder
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsusWin32API.TaskScheduler
{
  [Guid("8cfac062-a080-4c15-9a88-aa7c2af80dfc")]
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [ComImport]
  public interface ITaskFolder
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Name(out string pName);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT get_Path(out string pPath);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT GetFolder([In] IntPtr path, out ITaskFolder ppFolder);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT GetFolders([In] int flags, [In, Out] ref IntPtr ppFolders);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT CreateFolder([In] string folderName, [In] VARIANT sddl, out ITaskFolder ppFolder);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT DeleteFolder([In] string Name, [In] int flags);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT GetTask([In] string path, out IRegisteredTask ppTask);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT GetTasks([In] int flags, out IntPtr ppTasks);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT DeleteTask([In] string Name, [In] int flags);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT RegisterTask([In] string path, [In] string xmlText, [In] int flags, [In] VARIANT userId, [In] VARIANT password, [In] int logonType, [In, Optional] VARIANT sddl, out IRegisteredTask ppTask);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT RegisterTaskDefinition([In] IntPtr path, [In] ITaskDefinition pDefinition, [In] TASK_CREATION flags, [In] VARIANT userId, [In] VARIANT password, [In] TASK_LOGON_TYPE logonType, [In, Optional] VARIANT sddl, out IntPtr ppTask);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT GetSecurityDescriptor([In] int sercurityInformation, out string pSddl);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    HRESULT SetSecurityDescriptor([In] string sddl, [In] int flags);
  }
}
