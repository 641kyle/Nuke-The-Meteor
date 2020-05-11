using System;
using static System.Console;
namespace Nuke_The_Meteor
{
    public class Utils
    {
        public Utils()
        {
        }

        public static void WaitForKey()
        {
            WriteLine("- Press Enter to Continue -");
            ReadKey();
        }

        public static void ExitGame()
        {
            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }

    }
}
