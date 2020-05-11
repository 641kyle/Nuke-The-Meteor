using System;
using static System.Console;
using System.IO;
namespace Nuke_The_Meteor.Scenes.GameMenu
{
    public class History : Scene
    {
        public History(Game game) : base(game)
        {
        }

        public override void Run()
        {
            Clear();
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine(File.ReadAllText("History.txt"));
            ReadKey();
            Clear();
            MyGame.MyUpgradeMenu.Run();
        }
    }
}