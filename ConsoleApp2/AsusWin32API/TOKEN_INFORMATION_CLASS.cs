// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TOKEN_INFORMATION_CLASS
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

namespace AsusWin32API
{
  public enum TOKEN_INFORMATION_CLASS
  {
    TokenUser = 1,
    TokenGroups = 2,
    TokenPrivileges = 3,
    TokenOwner = 4,
    TokenPrimaryGroup = 5,
    TokenDefaultDacl = 6,
    TokenSource = 7,
    TokenType = 8,
    TokenImpersonationLevel = 9,
    TokenStatistics = 10, // 0x0000000A
    TokenRestrictedSids = 11, // 0x0000000B
    TokenSessionId = 12, // 0x0000000C
    TokenGroupsAndPrivileges = 13, // 0x0000000D
    TokenSessionReference = 14, // 0x0000000E
    TokenSandBoxInert = 15, // 0x0000000F
    TokenAuditPolicy = 16, // 0x00000010
    TokenOrigin = 17, // 0x00000011
    TokenElevationType = 18, // 0x00000012
    TokenLinkedToken = 19, // 0x00000013
    TokenElevation = 20, // 0x00000014
    TokenHasRestrictions = 21, // 0x00000015
    TokenAccessInformation = 22, // 0x00000016
    TokenVirtualizationAllowed = 23, // 0x00000017
    TokenVirtualizationEnabled = 24, // 0x00000018
    TokenIntegrityLevel = 25, // 0x00000019
    TokenUIAccess = 26, // 0x0000001A
    TokenMandatoryPolicy = 27, // 0x0000001B
    TokenLogonSid = 28, // 0x0000001C
    MaxTokenInfoClass = 29, // 0x0000001D
  }
}
