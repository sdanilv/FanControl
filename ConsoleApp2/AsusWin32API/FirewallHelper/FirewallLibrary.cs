// Decompiled with JetBrains decompiler
// Type: AsusWin32API.FirewallHelper.FirewallLibrary
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using NetFwTypeLib;
using System;

namespace AsusWin32API.FirewallHelper
{
  public class FirewallLibrary
  {
    private static string CLSID_FIREWALL_MANAGER = "{304CE942-6E39-40D8-943A-B913C40C9CD4}";
    private static string PROGID_AUTHORIZED_APPLICATION = "HNetCfg.FwAuthorizedApplication";

    private static INetFwMgr GetFirewallManager()
    {
      return Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid(FirewallLibrary.CLSID_FIREWALL_MANAGER))) as INetFwMgr;
    }

    public static bool AddAuthorizeApplicationForCurrentUser(string title, string applicationPath, NET_FW_SCOPE_ scope, NET_FW_IP_VERSION_ ipVersion)
    {
      try
      {
        // ISSUE: variable of a compiler-generated type
        INetFwAuthorizedApplication instance = Activator.CreateInstance(Type.GetTypeFromProgID(FirewallLibrary.PROGID_AUTHORIZED_APPLICATION)) as INetFwAuthorizedApplication;
        instance.Name = title;
        instance.ProcessImageFileName = applicationPath;
        instance.Scope = scope;
        instance.IpVersion = ipVersion;
        instance.Enabled = true;
        // ISSUE: reference to a compiler-generated method
        FirewallLibrary.GetFirewallManager().LocalPolicy.CurrentProfile.AuthorizedApplications.Add(instance);
      }
      catch (Exception ex)
      {
        return false;
      }
      return true;
    }

    public static bool RemoveAuthorizeApplicationForCurrentUser(string ImageFileName)
    {
      try
      {
        Type.GetTypeFromProgID(FirewallLibrary.PROGID_AUTHORIZED_APPLICATION);
        // ISSUE: reference to a compiler-generated method
        FirewallLibrary.GetFirewallManager().LocalPolicy.CurrentProfile.AuthorizedApplications.Remove(ImageFileName);
      }
      catch (Exception ex)
      {
        return false;
      }
      return true;
    }

    public static bool AddAuthorizeApplicationForAllUser(string FirewallRuleName, string ImageFilePath)
    {
      try
      {
        // ISSUE: variable of a compiler-generated type
        INetFwRule instance = (INetFwRule) Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
        instance.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
        instance.Description = FirewallRuleName;
        instance.ApplicationName = ImageFilePath;
        instance.Enabled = true;
        instance.InterfaceTypes = "All";
        instance.Name = FirewallRuleName;
        // ISSUE: reference to a compiler-generated method
        ((INetFwPolicy2) Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"))).Rules.Add(instance);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public static bool RemoveAuthorizeApplicationForAllUser(string FirewallRuleName)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        ((INetFwPolicy2) Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"))).Rules.Remove(FirewallRuleName);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}
