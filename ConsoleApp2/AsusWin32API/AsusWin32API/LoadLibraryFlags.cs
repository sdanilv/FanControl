// Decompiled with JetBrains decompiler
// Type: AsusWin32API.LoadLibraryFlags
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

namespace AsusWin32API
{
  public enum LoadLibraryFlags : uint
  {
    DONT_RESOLVE_DLL_REFERENCES = 1,
    LOAD_LIBRARY_AS_DATAFILE = 2,
    LOAD_WITH_ALTERED_SEARCH_PATH = 8,
    LOAD_IGNORE_CODE_AUTHZ_LEVEL = 16, // 0x00000010
    LOAD_LIBRARY_AS_IMAGE_RESOURCE = 32, // 0x00000020
    LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 64, // 0x00000040
  }
}
