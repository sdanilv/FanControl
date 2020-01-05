using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp2.Temperature
{
    public static class Program
    {
        public static float getTemperature()
        {  
            NvidiaGroup gpus = new NvidiaGroup();
            foreach (NvidiaGPU gpu in gpus.Hardware)
            {   
                    ISensor TemperatureSensor = gpu.Sensors.Single(s => s.SensorType == SensorType.Temperature);
                    //Console.Write(" | Current Temp: ");
                    //Console.Write(TemperatureSensor.Value);

                return (float) TemperatureSensor.Value;
                   
             }
            gpus = null;
            return 0;
         }
        
     }  
}
