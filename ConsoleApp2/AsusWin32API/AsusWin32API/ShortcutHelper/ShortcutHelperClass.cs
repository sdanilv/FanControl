// Decompiled with JetBrains decompiler
// Type: AsusWin32API.ShortcutHelper.ShortcutHelperClass
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using MS.WindowsAPICodePack.Internal;
using System;
using System.IO;
using System.Reflection;

namespace AsusWin32API.ShortcutHelper
{
  public class ShortcutHelperClass
  {
    private string _strShortcutDestDir = "";
    private string _strAPP_ID = "";
    private string _strShortcutName = "";
    private string _strDestDir = "";
    private string _strDestName = "";
    private string _strDestIcon = "";

    public string strAPP_ID
    {
      get
      {
        return this._strAPP_ID;
      }
      set
      {
        this._strAPP_ID = value;
      }
    }

    public string strShortcutName
    {
      get
      {
        return this._strShortcutName;
      }
      set
      {
        this._strShortcutName = value;
      }
    }

    public string strShortcutDestDir
    {
      get
      {
        return this._strShortcutDestDir;
      }
      set
      {
        this._strShortcutDestDir = value;
      }
    }

    public string strDestDir
    {
      get
      {
        return this._strDestDir;
      }
      set
      {
        this._strDestDir = value;
      }
    }

    public string strDestName
    {
      get
      {
        return this._strDestName;
      }
      set
      {
        this._strDestName = value;
      }
    }

    public string strDestIcon
    {
      get
      {
        return this._strDestIcon;
      }
      set
      {
        this._strDestIcon = value;
      }
    }

    public ShortcutHelperClass(string strShortcutName = "", string strDestIcon = "", string strDestName = "", string strApp_ID = "", string strDestDir = "", string strShortcutDestDir = "")
    {
      this.strDestDir = strDestDir;
      this.strDestName = strDestName;
      this.strDestIcon = strDestIcon;
      this.strShortcutName = strShortcutName;
      this.strAPP_ID = strApp_ID;
      this.strShortcutDestDir = strShortcutDestDir;
    }

    public bool TryCreateShortcut()
    {
      if (this.strShortcutName.Length == 0)
        this.strShortcutName = "ASUS VivoBook";
      if (this.strShortcutDestDir.Length == 0)
      {
        this.strShortcutDestDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu) + "\\Programs\\ASUS\\";
        if (!Directory.Exists(this.strShortcutDestDir))
          Directory.CreateDirectory(this.strShortcutDestDir);
      }
      string str = this.strShortcutDestDir + this.strShortcutName + ".lnk";
      if (File.Exists(str))
        return false;
      this.InstallShortcut(str);
      return true;
    }

    private void InstallShortcut(string shortcutPath)
    {
      if (this.strDestDir.Length == 0)
        this.strDestDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";
      if (this.strDestName.Length == 0)
        this.strDestName = "ASUS Console.exe";
      if (this.strDestIcon.Length == 0)
        this.strDestIcon = "VivoBook.ico";
      if (this.strAPP_ID.Length == 0)
        this.strAPP_ID = "ASUS Portal toast";
      string pszIconPath = this.strDestDir + this.strDestIcon;
      string pszFile = this.strDestDir + this.strDestName;
      IShellLinkW shellLinkW = (IShellLinkW) new CShellLink();
      ErrorHelper.VerifySucceeded(shellLinkW.SetPath(pszFile));
      ErrorHelper.VerifySucceeded(shellLinkW.SetArguments(""));
      ErrorHelper.VerifySucceeded(shellLinkW.SetIconLocation(pszIconPath, 0));
      AsusWin32API.IPropertyStore propertyStore1 = (AsusWin32API.IPropertyStore) shellLinkW;
      using (PropVariant propVariant = new PropVariant(this._strAPP_ID))
      {
        AsusWin32API.IPropertyStore propertyStore2 = propertyStore1;
        PropertyKey id = SystemProperties.System.AppUserModel.ID;
        ref PropertyKey local = ref id;
        PropVariant pv = propVariant;
        ErrorHelper.VerifySucceeded(propertyStore2.SetValue(ref local, pv));
        ErrorHelper.VerifySucceeded(propertyStore1.Commit());
      }
      ErrorHelper.VerifySucceeded(((IPersistFile) shellLinkW).Save(shortcutPath, true));
    }

    public bool TryDeleteShortcut()
    {
      if (this.strShortcutName.Length == 0)
        this.strShortcutName = "ASUS VivoBook";
      if (this.strShortcutDestDir.Length == 0)
        this.strShortcutDestDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu) + "\\Programs\\ASUS\\";
      string path = this.strShortcutDestDir + this.strShortcutName + ".lnk";
      try
      {
        if (File.Exists(path))
        {
          File.Delete(path);
          return true;
        }
      }
      catch
      {
      }
      return false;
    }
  }
}
