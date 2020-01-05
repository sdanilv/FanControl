using System;

public class ConsoleManager
{

    public static void addExitHandler (){
        signalHandler += HandleConsoleSignal;
        ConsoleHelper.SetSignalHandler(signalHandler, true);
    }

    internal delegate void SignalHandler(ConsoleSignal consoleSignal, int vs);

    internal enum ConsoleSignal
    {
        CtrlC = 0,
        CtrlBreak = 1,
        Close = 2,
        LogOff = 5,
        Shutdown = 6
    }

    internal static class ConsoleHelper
    {
        [DllImport("Kernel32", EntryPoint = "SetConsoleCtrlHandler")]
        public static extern bool SetSignalHandler(SignalHandler handler, bool add);
    }



    private static SignalHandler signalHandler;

    private static void HandleConsoleSignal(ConsoleSignal consoleSignal, int returnedValue)
    {
        FunContol.stop();
    }
    
}
