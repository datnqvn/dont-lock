using System;
using System.Runtime.InteropServices;

class Program
{
    // Import the SetThreadExecutionState function from the Windows API
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

    // Define the possible thread execution states
    [FlagsAttribute]
    public enum EXECUTION_STATE : uint
    {
        ES_SYSTEM_REQUIRED = 0x00000001,
        ES_DISPLAY_REQUIRED = 0x00000002,
        ES_CONTINUOUS = 0x80000000
    }

    static void Main(string[] args)
    {
        // Prevent the Windows lock screen
        SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_SYSTEM_REQUIRED);

        // Wait for user input
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

        // Allow the Windows lock screen again
        SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
    }
}
