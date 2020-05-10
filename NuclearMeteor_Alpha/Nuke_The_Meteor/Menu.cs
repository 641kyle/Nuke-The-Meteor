using System;
using static System.Console;
using Pastel;
namespace Nuke_The_Meteor
{
    public class Menu
    {

        int SelectedIndex;
        string[] Options;
        string Prompt;

        public Menu(string prompt, string[] options)
        { 
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;

        }

        private void DisplayOptions()
        {
            WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                if (i == SelectedIndex)
                {
                    prefix = ">";
                    BackgroundColor = ConsoleColor.Cyan;
                    ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                }
                WriteLine($"{prefix} {currentOption}");
                ResetColor();

            }
            

        }


        public int MenuRun()
        {
            ConsoleKey keyPressed;

            do
            {
                
                DisplayOptions();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.S)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
                else if (keyPressed == ConsoleKey.UpArrow || keyPressed == ConsoleKey.W)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        
                        SelectedIndex = Options.Length - 1;
                    }
                }
                Clear();
            } while (keyPressed != ConsoleKey.Enter);

            Clear();
            return SelectedIndex;
        }

        public int MenuRun(double day, double cash, double speed, double accuracy, double combustion, string feedback)
        {
            //https://www.geeksforgeeks.org/c-sharp-math-pow-method/ for power of number
            ConsoleKey keyPressed;
            do
            {
                ConsoleColor currentFColor = ForegroundColor;
                WriteLine(feedback);
                double RD = Math.Pow(speed * accuracy, combustion);
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine($"Speed: {speed}");
                ForegroundColor = ConsoleColor.DarkMagenta;
                WriteLine($"Accuracy: {accuracy}");
                ForegroundColor = ConsoleColor.Blue;
                WriteLine($"Combustion: {combustion}");
                ResetColor();
                Write($"                           ");
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"Rocket Destruction: |{RD}|");
                //.Pastel("#d4ff00"));
                ForegroundColor = ConsoleColor.Green;
                Write("                              ");
                WriteLine($"\nDay: {day}");
                ResetColor();
                ForegroundColor = ConsoleColor.Green;
                WriteLine($"\nCash = ${cash}");
                ResetColor();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.S)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
                else if (keyPressed == ConsoleKey.UpArrow || keyPressed == ConsoleKey.W)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {

                        SelectedIndex = Options.Length - 1;
                    }
                }
                Clear();
                ForegroundColor = currentFColor;
            } while (keyPressed != ConsoleKey.Enter);

            Clear();
            return SelectedIndex;
        }
    }


}
