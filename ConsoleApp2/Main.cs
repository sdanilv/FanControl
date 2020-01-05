using AsusWin32API;
using System;
using System.Threading;


namespace ConsoleApp2
{
    class main
    {
        static float GPUTemperature()
        {
            return Temperature.Program.getTemperature();
        }

        public static void Main(String[] arg)
        {
                ConsoleManager.hideWindow();
                ConsoleManager.addExitHandler();
                WaitingOverHeat();
        }

        public static void WaitingOverHeat()
        {
            do
            {
                Thread.Sleep(1000);
            } while (GPUTemperature() < 70);
            FunContol.start();
            WaitingNormalizeTemperature();
        }

        public static void WaitingNormalizeTemperature()
        {
            do
            {
                Thread.Sleep(1000);
            } while (GPUTemperature() > 70);
            FunContol.stop();
            WaitingOverHeat();
        }
    }
}
