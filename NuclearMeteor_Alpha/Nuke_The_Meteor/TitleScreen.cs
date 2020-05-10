using System;
using static System.Console;
using System.Diagnostics;
using System.Threading;
using Pastel;
namespace Nuke_The_Meteor
{
    public class TitleScreen
    {
        //Did you like this? haha 
        int x = 100;
        public TitleScreen()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();


            string titleArt = @"
     __       _          _   _                   p     _                  
  /\ \ \_   _| p| _____  | |_| |__p   ___    /\/\   ___|p |_ ___  ___  _ __ p
 /  \/ / | | | |/ / _ \ | __|p '_ \ / _ \  /    \ / _ \ __/ _ \/ _ \| '__|p
/ /\  /| |_| |p   <  __/ | |_| | | |  _p_/ / /\/\ \  __/ ||  p__/ (_) | |   p
\_\ \/ p \__,_|_|\_\_p__|  \__|_| |_|\___| \/    \/\___|\__\__p_|\___/|_|   
                                                                         ";

            //got code from https://www.geeksforgeeks.org/string-split-method-in-c-sharp-with-examples/

            char[] splitter = { 'p' };
            Int32 count = 20;

            string[] titleSplit = titleArt.Split(splitter, count, StringSplitOptions.None);

            foreach (String s in titleSplit)
            {
                Thread.Sleep(x);
                Write(s);

            }

            Thread.Sleep(1000);
            timer.Stop();
        }


    }


     
}
