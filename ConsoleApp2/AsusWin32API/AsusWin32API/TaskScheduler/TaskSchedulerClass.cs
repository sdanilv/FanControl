// Decompiled with JetBrains decompiler
// Type: AsusWin32API.TaskScheduler.TaskSchedulerClass
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AsusWin32API.TaskScheduler
{
  public class TaskSchedulerClass
  {
    public static Guid TaskScheduler = new Guid("0f87369f-a4e5-4cfc-bd3e-73e6154572dd");
    public static Guid ITaskService = new Guid("2faba4c7-4da9-4013-9697-20cc3fd40f85");
    public static Guid ILogonTrigger = new Guid("72DADE38-FAE4-4b3e-BAF4-5D009AF02B1C");
    public static Guid IExecAction = new Guid("4c3d624d-fd6b-49a3-b9b7-09cb3cd3f047");
    public static ushort VARIANT_TRUE = ushort.MaxValue;
    public static ushort VARIANT_FALSE = 0;
    protected AsusWin32API.TaskScheduler.ITaskService g_TaskService;
    protected ITaskFolder g_TaskFolder;
    protected string g_rootPath;

    protected HRESULT SetTrigger(ref ITaskDefinition TaskDefinition, string TriggerId)
    {
      ITriggerCollection ppTriggers = (ITriggerCollection) null;
      ITrigger ppTrigger = (ITrigger) null;
      HRESULT hresult = TaskDefinition.get_Triggers(out ppTriggers);
      if (hresult == HRESULT.S_OK)
        hresult = ppTriggers.Create(TASK_TRIGGER_TYPE2.LOGON, out ppTrigger);
      if (hresult == HRESULT.S_OK)
      {
        IntPtr interfaceForObject = Marshal.GetComInterfaceForObject((object) ppTrigger, typeof (ITrigger));
        IntPtr ppv;
        Marshal.QueryInterface(interfaceForObject, ref TaskSchedulerClass.ILogonTrigger, out ppv);
        Marshal.Release(interfaceForObject);
        if (ppv != IntPtr.Zero)
        {
          AsusWin32API.TaskScheduler.ILogonTrigger objectForIunknown = (AsusWin32API.TaskScheduler.ILogonTrigger) Marshal.GetObjectForIUnknown(ppv);
          if (hresult == HRESULT.S_OK)
            hresult = objectForIunknown.put_Id(TriggerId);
          Marshal.Release(ppv);
          Marshal.ReleaseComObject((object) objectForIunknown);
        }
      }
      if (ppTrigger != null)
        Marshal.ReleaseComObject((object) ppTrigger);
      if (ppTriggers != null)
        Marshal.ReleaseComObject((object) ppTriggers);
      return hresult;
    }

    protected HRESULT SetTriggerWithDelay(ref ITaskDefinition TaskDefinition, string TriggerId, string DelayTime)
    {
      ITriggerCollection ppTriggers = (ITriggerCollection) null;
      ITrigger ppTrigger = (ITrigger) null;
      HRESULT hresult = TaskDefinition.get_Triggers(out ppTriggers);
      if (hresult == HRESULT.S_OK)
        hresult = ppTriggers.Create(TASK_TRIGGER_TYPE2.LOGON, out ppTrigger);
      if (hresult == HRESULT.S_OK)
      {
        IntPtr interfaceForObject = Marshal.GetComInterfaceForObject((object) ppTrigger, typeof (ITrigger));
        IntPtr ppv;
        Marshal.QueryInterface(interfaceForObject, ref TaskSchedulerClass.ILogonTrigger, out ppv);
        Marshal.Release(interfaceForObject);
        if (ppv != IntPtr.Zero)
        {
          AsusWin32API.TaskScheduler.ILogonTrigger objectForIunknown = (AsusWin32API.TaskScheduler.ILogonTrigger) Marshal.GetObjectForIUnknown(ppv);
          if (hresult == HRESULT.S_OK && TriggerId != string.Empty)
            hresult = objectForIunknown.put_Id(TriggerId);
          if (hresult == HRESULT.S_OK && DelayTime != string.Empty)
            hresult = objectForIunknown.put_Delay(DelayTime);
          Marshal.Release(ppv);
          Marshal.ReleaseComObject((object) objectForIunknown);
        }
      }
      if (ppTrigger != null)
        Marshal.ReleaseComObject((object) ppTrigger);
      if (ppTriggers != null)
        Marshal.ReleaseComObject((object) ppTriggers);
      return hresult;
    }

    protected HRESULT SetAction(ref ITaskDefinition TaskDefinition, string FullPathOfExeFile, string Parameter)
    {
      IActionCollection ppActions = (IActionCollection) null;
      IAction ppAction = (IAction) null;
      HRESULT hresult = TaskDefinition.get_Actions(out ppActions);
      if (hresult == HRESULT.S_OK)
        hresult = ppActions.Create(TASK_ACTION_TYPE.EXEC, out ppAction);
      if (hresult == HRESULT.S_OK)
      {
        IntPtr ppv = IntPtr.Zero;
        IntPtr interfaceForObject = Marshal.GetComInterfaceForObject((object) ppAction, typeof (IAction));
        Marshal.QueryInterface(interfaceForObject, ref TaskSchedulerClass.IExecAction, out ppv);
        Marshal.Release(interfaceForObject);
        if (ppv != IntPtr.Zero)
        {
          AsusWin32API.TaskScheduler.IExecAction objectForIunknown = (AsusWin32API.TaskScheduler.IExecAction) Marshal.GetObjectForIUnknown(ppv);
          objectForIunknown.put_Path(FullPathOfExeFile);
          hresult = objectForIunknown.put_Arguments(Parameter);
          Marshal.ReleaseComObject((object) objectForIunknown);
          Marshal.Release(ppv);
        }
      }
      if (ppAction != null)
        Marshal.ReleaseComObject((object) ppAction);
      if (ppActions != null)
        Marshal.ReleaseComObject((object) ppActions);
      return hresult;
    }

    protected HRESULT InitialTaskSetting(ref ITaskDefinition TaskDefinition)
    {
      ITaskSettings ppSettings = (ITaskSettings) null;
      IIdleSettings ppIdleSettings = (IIdleSettings) null;
      HRESULT hresult = TaskDefinition.get_Settings(out ppSettings);
      if (hresult == HRESULT.S_OK)
        hresult = ppSettings.put_Priority(1);
      if (hresult == HRESULT.S_OK)
        hresult = ppSettings.put_RunOnlyIfIdle(TaskSchedulerClass.VARIANT_FALSE);
      if (hresult == HRESULT.S_OK)
        hresult = ppSettings.put_StopIfGoingOnBatteries(TaskSchedulerClass.VARIANT_FALSE);
      if (hresult == HRESULT.S_OK)
        hresult = ppSettings.put_StartWhenAvailable(TaskSchedulerClass.VARIANT_TRUE);
      if (hresult == HRESULT.S_OK)
        hresult = ppSettings.put_DisallowStartIfOnBatteries(TaskSchedulerClass.VARIANT_FALSE);
      if (hresult == HRESULT.S_OK)
        hresult = ppSettings.put_ExecutionTimeLimit("P0Y0M0DT0H0M0S");
      if (hresult == HRESULT.S_OK)
        hresult = ppSettings.put_MultipleInstances(TASK_INSTANCES_POLICY.TASK_INSTANCES_PARALLEL);
      if (hresult == HRESULT.S_OK)
        hresult = ppSettings.get_IdleSettings(out ppIdleSettings);
      if (hresult == HRESULT.S_OK)
        hresult = ppIdleSettings.put_RestartOnIdle(TaskSchedulerClass.VARIANT_FALSE);
      if (hresult == HRESULT.S_OK)
        hresult = ppIdleSettings.put_StopOnIdleEnd(TaskSchedulerClass.VARIANT_FALSE);
      if (ppIdleSettings != null)
        Marshal.ReleaseComObject((object) ppIdleSettings);
      if (ppSettings != null)
        Marshal.ReleaseComObject((object) ppSettings);
      return hresult;
    }

    protected void CreateVariant(VT vt, object val, out VARIANT variant)
    {
      variant = new VARIANT();
      variant.vt = vt;
      switch (vt)
      {
        case VT.EMPTY:
        case VT.NULL:
          variant.bstrVal = IntPtr.Zero;
          break;
        case VT.BSTR:
          variant.bstrVal = Marshal.StringToBSTR(val.ToString());
          break;
      }
    }

    public TaskSchedulerClass()
    {
      this.g_TaskService = (AsusWin32API.TaskScheduler.ITaskService) null;
      this.g_TaskFolder = (ITaskFolder) null;
      this.g_rootPath = "\\";
    }

    public TaskSchedulerClass(string rootPath)
    {
      this.g_TaskService = (AsusWin32API.TaskScheduler.ITaskService) null;
      this.g_TaskFolder = (ITaskFolder) null;
      this.g_rootPath = rootPath;
    }

    public string GetUserGroupIDForMultiLanguage()
    {
      string str = "S-1-5-32-545";
      SidIdentifierAuthority pIdentifierAuthority = new SidIdentifierAuthority();
      ref SidIdentifierAuthority local = ref pIdentifierAuthority;
      byte[] numArray = new byte[6];
      numArray[5] = (byte) 5;
      local.Value = numArray;
      IntPtr pSid = IntPtr.Zero;
      if (Advapi32.AllocateAndInitializeSid(ref pIdentifierAuthority, (byte) 2, 32, 545, 0, 0, 0, 0, 0, 0, out pSid))
      {
        StringBuilder lpName = new StringBuilder(125);
        uint capacity1 = (uint) lpName.Capacity;
        StringBuilder ReferencedDomainName = new StringBuilder(125);
        uint capacity2 = (uint) ReferencedDomainName.Capacity;
        SID_NAME_USE peUse;
        if (Advapi32.LookupAccountSid(IntPtr.Zero, pSid, lpName, ref capacity1, ReferencedDomainName, ref capacity2, out peUse))
          str = lpName.ToString();
        if (pSid != IntPtr.Zero)
          Advapi32.FreeSid(pSid);
      }
      return str;
    }

    public bool Initialization()
    {
      bool flag = true;
      IntPtr ppv;
      HRESULT hresult = Ole32.CoCreateInstance(ref TaskSchedulerClass.TaskScheduler, IntPtr.Zero, CLSCTX.INPROC_SERVER, ref TaskSchedulerClass.ITaskService, out ppv);
      if (hresult == HRESULT.S_OK)
      {
        this.g_TaskService = (AsusWin32API.TaskScheduler.ITaskService) Marshal.GetObjectForIUnknown(ppv);
        Marshal.Release(ppv);
        hresult = this.g_TaskService.Connect((object) null, (object) null, (object) null, (object) null);
        if (hresult == HRESULT.S_OK)
          hresult = this.g_TaskService.GetFolder(this.g_rootPath, out this.g_TaskFolder);
      }
      if (hresult != HRESULT.S_OK)
        flag = false;
      return flag;
    }

    public void InitConfigure(ref TaskSchedulerConfigure TSC)
    {
      TSC.TaskName = "ASUSPortal";
      TSC.Parameter = string.Empty;
      TSC.AuthorName = "ASUSTek Computer  Inc.";
      TSC.runlevel = TASK_RUNLEVEL_TYPE.HIGHEST;
      TSC.DelayTime = string.Empty;
      TSC.Builtin = "S-1-5-32-545";
      TSC.FullPathOfExeFile = string.Empty;
      TSC.TriggerId = "ASUSPortalTrigger";
    }

    public bool CreateTask(ref TaskSchedulerConfigure TSC)
    {
      ITaskDefinition ppDefinition = (ITaskDefinition) null;
      IRegistrationInfo ppRegistrationInfo = (IRegistrationInfo) null;
      ITaskSettings taskSettings = (ITaskSettings) null;
      IPrincipal ppPrincipal = (IPrincipal) null;
      HRESULT hresult = this.g_TaskService.NewTask(0U, out ppDefinition);
      if (hresult == HRESULT.S_OK)
        hresult = ppDefinition.get_RegistrationInfo(out ppRegistrationInfo);
      if (hresult == HRESULT.S_OK && TSC.AuthorName != string.Empty)
        hresult = ppRegistrationInfo.put_Author(TSC.AuthorName);
      if (hresult == HRESULT.S_OK)
        hresult = ppDefinition.get_Principal(out ppPrincipal);
      if (hresult == HRESULT.S_OK)
        hresult = ppPrincipal.put_RunLevel(TSC.runlevel);
      if (hresult == HRESULT.S_OK)
        hresult = this.InitialTaskSetting(ref ppDefinition);
      if (hresult == HRESULT.S_OK && (TSC.TriggerId != string.Empty || TSC.DelayTime != string.Empty))
        hresult = this.SetTriggerWithDelay(ref ppDefinition, TSC.TriggerId, TSC.DelayTime);
      if (hresult == HRESULT.S_OK && TSC.FullPathOfExeFile != string.Empty)
        hresult = this.SetAction(ref ppDefinition, TSC.FullPathOfExeFile, TSC.Parameter);
      if (hresult == HRESULT.S_OK)
      {
        VARIANT variant1;
        this.CreateVariant(VT.BSTR, (object) TSC.Builtin, out variant1);
        VARIANT variant2;
        this.CreateVariant(VT.EMPTY, (object) IntPtr.Zero, out variant2);
        VARIANT variant3;
        this.CreateVariant(VT.BSTR, (object) "", out variant3);
        IntPtr ppTask;
        hresult = this.g_TaskFolder.RegisterTaskDefinition(Marshal.StringToBSTR(TSC.TaskName), ppDefinition, TASK_CREATION.CREATE_OR_UPDATE, variant1, variant2, TASK_LOGON_TYPE.GROUP, variant3, out ppTask);
        if (hresult == HRESULT.S_OK)
          Marshal.Release(ppTask);
      }
      if (ppDefinition != null)
        Marshal.ReleaseComObject((object) ppDefinition);
      if (ppRegistrationInfo != null)
        Marshal.ReleaseComObject((object) ppRegistrationInfo);
      if (taskSettings != null)
        Marshal.ReleaseComObject((object) taskSettings);
      return hresult == HRESULT.S_OK;
    }

    public bool CreateTask(string TaskName, string AuthorName, string FullPathOfExeFile, TASK_RUNLEVEL_TYPE runlevel)
    {
      ITaskDefinition ppDefinition = (ITaskDefinition) null;
      IRegistrationInfo ppRegistrationInfo = (IRegistrationInfo) null;
      ITaskSettings taskSettings = (ITaskSettings) null;
      IPrincipal ppPrincipal = (IPrincipal) null;
      HRESULT hresult = this.g_TaskService.NewTask(0U, out ppDefinition);
      if (hresult == HRESULT.S_OK)
        hresult = ppDefinition.get_RegistrationInfo(out ppRegistrationInfo);
      if (hresult == HRESULT.S_OK)
        hresult = ppRegistrationInfo.put_Author(AuthorName);
      if (hresult == HRESULT.S_OK)
        hresult = ppDefinition.get_Principal(out ppPrincipal);
      if (hresult == HRESULT.S_OK)
        hresult = ppPrincipal.put_RunLevel(runlevel);
      if (hresult == HRESULT.S_OK)
        hresult = this.InitialTaskSetting(ref ppDefinition);
      if (hresult == HRESULT.S_OK)
        hresult = this.SetAction(ref ppDefinition, FullPathOfExeFile, string.Empty);
      if (hresult == HRESULT.S_OK)
      {
        VARIANT variant1;
        this.CreateVariant(VT.BSTR, (object) "Users", out variant1);
        VARIANT variant2;
        this.CreateVariant(VT.EMPTY, (object) IntPtr.Zero, out variant2);
        VARIANT variant3;
        this.CreateVariant(VT.BSTR, (object) "", out variant3);
        IntPtr ppTask;
        hresult = this.g_TaskFolder.RegisterTaskDefinition(Marshal.StringToBSTR(TaskName), ppDefinition, TASK_CREATION.CREATE_OR_UPDATE, variant1, variant2, TASK_LOGON_TYPE.GROUP, variant3, out ppTask);
        if (hresult == HRESULT.S_OK)
          Marshal.Release(ppTask);
      }
      if (ppDefinition != null)
        Marshal.ReleaseComObject((object) ppDefinition);
      if (ppRegistrationInfo != null)
        Marshal.ReleaseComObject((object) ppRegistrationInfo);
      if (taskSettings != null)
        Marshal.ReleaseComObject((object) taskSettings);
      return hresult == HRESULT.S_OK;
    }

    public bool CreateTask(string TaskName, string AuthorName, string TriggerId, string FullPathOfExeFile, TASK_RUNLEVEL_TYPE runlevel)
    {
      ITaskDefinition ppDefinition = (ITaskDefinition) null;
      IRegistrationInfo ppRegistrationInfo = (IRegistrationInfo) null;
      ITaskSettings taskSettings = (ITaskSettings) null;
      IPrincipal ppPrincipal = (IPrincipal) null;
      HRESULT hresult = this.g_TaskService.NewTask(0U, out ppDefinition);
      if (hresult == HRESULT.S_OK)
        hresult = ppDefinition.get_RegistrationInfo(out ppRegistrationInfo);
      if (hresult == HRESULT.S_OK)
        hresult = ppRegistrationInfo.put_Author(AuthorName);
      if (hresult == HRESULT.S_OK)
        hresult = ppDefinition.get_Principal(out ppPrincipal);
      if (hresult == HRESULT.S_OK)
        hresult = ppPrincipal.put_RunLevel(runlevel);
      if (hresult == HRESULT.S_OK)
        hresult = this.InitialTaskSetting(ref ppDefinition);
      if (hresult == HRESULT.S_OK)
        hresult = this.SetTrigger(ref ppDefinition, TriggerId);
      if (hresult == HRESULT.S_OK)
        hresult = this.SetAction(ref ppDefinition, FullPathOfExeFile, string.Empty);
      if (hresult == HRESULT.S_OK)
      {
        VARIANT variant1;
        this.CreateVariant(VT.BSTR, (object) "Users", out variant1);
        VARIANT variant2;
        this.CreateVariant(VT.EMPTY, (object) IntPtr.Zero, out variant2);
        VARIANT variant3;
        this.CreateVariant(VT.BSTR, (object) "", out variant3);
        IntPtr ppTask;
        hresult = this.g_TaskFolder.RegisterTaskDefinition(Marshal.StringToBSTR(TaskName), ppDefinition, TASK_CREATION.CREATE_OR_UPDATE, variant1, variant2, TASK_LOGON_TYPE.GROUP, variant3, out ppTask);
        if (hresult == HRESULT.S_OK)
          Marshal.Release(ppTask);
      }
      if (ppDefinition != null)
        Marshal.ReleaseComObject((object) ppDefinition);
      if (ppRegistrationInfo != null)
        Marshal.ReleaseComObject((object) ppRegistrationInfo);
      if (taskSettings != null)
        Marshal.ReleaseComObject((object) taskSettings);
      return hresult == HRESULT.S_OK;
    }

    public bool RunTask(string TaskName)
    {
      bool flag = false;
      IRegisteredTask ppTask = (IRegisteredTask) null;
      if (this.g_TaskFolder.GetTask(TaskName, out ppTask) == HRESULT.S_OK)
      {
        VARIANT variant;
        this.CreateVariant(VT.EMPTY, (object) null, out variant);
        IntPtr ppRunningTask;
        if (ppTask.Run(variant, out ppRunningTask) == HRESULT.S_OK)
        {
          Marshal.Release(ppRunningTask);
          flag = true;
        }
        Marshal.ReleaseComObject((object) ppTask);
      }
      return flag;
    }

    public bool RunExTask(int iSessionID, int iFlag, string UserName, string TaskName, string Argument)
    {
      bool flag = false;
      IRegisteredTask ppTask = (IRegisteredTask) null;
      if (this.g_TaskFolder.GetTask(TaskName, out ppTask) == HRESULT.S_OK)
      {
        IntPtr ppRunningTask = IntPtr.Zero;
        VARIANT variant;
        this.CreateVariant(VT.BSTR, (object) Argument, out variant);
        if (ppTask.RunEx(variant, iFlag, iSessionID, UserName, out ppRunningTask) == HRESULT.S_OK)
        {
          flag = true;
          Marshal.Release(ppRunningTask);
        }
        Marshal.ReleaseComObject((object) ppTask);
      }
      return flag;
    }

    public bool DeleteTask(string TaskName)
    {
      return this.g_TaskFolder.DeleteTask(TaskName, 0) == HRESULT.S_OK;
    }

    public bool StopTask(string TaskName)
    {
      bool flag = false;
      IRegisteredTask ppTask = (IRegisteredTask) null;
      if (this.g_TaskFolder.GetTask(TaskName, out ppTask) == HRESULT.S_OK)
      {
        if (ppTask.Stop(0) == HRESULT.S_OK)
          flag = true;
        Marshal.ReleaseComObject((object) ppTask);
      }
      return flag;
    }

    public void CloseTask()
    {
      if (this.g_TaskService != null)
        Marshal.ReleaseComObject((object) this.g_TaskService);
      if (this.g_TaskFolder != null)
        Marshal.ReleaseComObject((object) this.g_TaskFolder);
      this.g_TaskFolder = (ITaskFolder) null;
      this.g_TaskService = (AsusWin32API.TaskScheduler.ITaskService) null;
    }
  }
}
