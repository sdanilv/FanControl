using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Management;
using System.Management.Instrumentation;
using ConsoleApp2.Temperature;
namespace AsusWin32API
{
    public static class FunContol
    {
        public static string g_strROGATKPath = "SOFTWARE\\ASUS\\ROG Gaming Center\\ROG ATKStatus";
        private static double g_SystemFanCurrent = 100.0;
        //public static Action<ROGSYNCFUNC, object> NotifyChangedEvent = (Action<ROGSYNCFUNC, object>)null;
      
        public static void start()
        {
            ATKHelper.SetSystemFanStatus((int)byte.MaxValue);
            SetSystemFanOffsetValue((int)byte.MaxValue, (int)g_SystemFanCurrent);
        }

        public static void stop() {

              ATKHelper.SetSystemFanStatus((int)0);
              SetSystemFanOffsetValue((int)0, (int)0);
        }


        public static void SetSystemFanOffsetValue(int OffsetValue, int Offset)
        {
            
                RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                if (registryKey == null)
                    return;
                RegistryKey subKey = registryKey.CreateSubKey(g_strROGATKPath);
                if (subKey != null)
                {
                    subKey.SetValue("SystemFanOffsetValue", (object)OffsetValue, RegistryValueKind.DWord);
                    subKey.SetValue("SystemFanOffset", (object)Offset, RegistryValueKind.DWord);
                    subKey.Close();
                }
                registryKey.Close();
            
          
        }

        public struct Temperature
        {
            public readonly bool Active;
            public readonly uint[] ActiveTripPoint;
            public readonly uint ActiveTripPointCount;
            public readonly uint CriticalTripPointRaw;
            public readonly uint CurrentTemperatureRaw;
            public readonly string InstanceName;

            public Temperature(bool active, uint[] activeTripPoint, uint activeTripPointCount, uint criticalTripPointRaw, uint currentTemperatureRaw, string instanceName) : this()
            {
                Active = active;
                ActiveTripPoint = activeTripPoint;
                ActiveTripPointCount = activeTripPointCount;
                CriticalTripPointRaw = criticalTripPointRaw;
                CurrentTemperatureRaw = currentTemperatureRaw;
                InstanceName = instanceName;
            }

            public double CriticalTripPoint
            {
                get { return CriticalTripPointRaw * 0.1 - 273.15; }
            }

            public double CurrentTemperature
            {
                get { return CurrentTemperatureRaw * 0.1 - 273.15; }
            }

            public static IEnumerable<Temperature> Instances
            {
                get
                {
                    var searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
                    return from ManagementObject obj in searcher.Get()
                           select new Temperature((bool)obj["Active"], (uint[])obj["ActiveTripPoint"], (uint)obj["ActiveTripPointCount"],
                                                  (uint)obj["CriticalTripPoint"], (uint)obj["CurrentTemperature"], (string)obj["InstanceName"]);
                }
            }

            public override string ToString()
            {
                return string.Format("Active: {0}, ActiveTripPoint: [{1}], ActiveTripPointCount: {2}, InstanceName: {3}, CriticalTripPoint: {4}, CurrentTemperature: {5}",
                                      Active, string.Join(", ", ActiveTripPoint), ActiveTripPointCount, InstanceName,
                                      CriticalTripPoint, CurrentTemperature);
            }
        }
    }
}
