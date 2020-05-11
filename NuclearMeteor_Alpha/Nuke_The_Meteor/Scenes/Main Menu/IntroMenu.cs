using System;
using static System.Console;
using Nuke_The_Meteor;
using System.IO;
namespace Nuke_The_Meteor.Scenes
{
    public class IntroMenu : Scene
    { 
        string description = "\nHello, and welcome to Nuke the Meteor. \nThe game where you must upgrade your rocket enough to destroy the incoming meteor!\n(Use Arrow Keys or WS keys to scroll. Press ENTER to make a Selection)";

        public IntroMenu(Game game) : base(game)
        {
        }

        public override void Run()
        {

            string[] welcomeOptions = { "New Game", "Continue", "About", "Help", "Exit" };
            Menu mainMenu = new Menu(description + "\n", welcomeOptions);
            int selectedIndex = mainMenu.MenuRun();

            switch (selectedIndex)
            {
                case 0:
                    MyGame.NewGame();
                    break;
                case 1:
                    //ContinueGame();
                    break;
                case 2:
                    MyGame.MyAbout.Run();
                    break;
                case 3:
                    MyGame.MyHelp.Run();
                    break;
                case 4:
                    Utils.ExitGame();
                    break;
            }



        }
    }
}

