using System;
using System.Threading;
using AsusWin32API;
using System.Runtime.InteropServices;

public class ConsoleManager
{
    internal delegate void SignalHandler(ConsoleSignal consoleSignal, int vs);
    internal enum ConsoleSignal
    {
        CtrlC = 0,
        CtrlBreak = 1,
        Close = 2,
        LogOff = 5,
        Shutdown = 6
    }
    [DllImport("Kernel32", EntryPoint = "SetConsoleCtrlHandler")]
    static extern bool SetSignalHandler(SignalHandler handler, bool add);
    

    [DllImport("kernel32.dll")]
    static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    const int SW_HIDE = 0;
    const int SW_SHOW = 5;
    public static void addExitHandler (){
        SetSignalHandler(HandleConsoleSignal, true);
    }
    public static void hideWindow()
    {
        ShowWindow(GetConsoleWindow(), SW_HIDE);
    }

    public static void showWindow(string message)
    {
        ShowWindow(GetConsoleWindow(), SW_SHOW);
        Console.WriteLine(message);
        Console.ReadKey();
    }



    private static void HandleConsoleSignal(ConsoleSignal consoleSignal, int returnedValue)
    {
        FunContol.stop();
    }
    
}
