using System;
using static System.Console;
using System.IO;
namespace Nuke_The_Meteor.Scenes.MainMenu
{
    public class Help : Scene
    {
        public Help(Game game) : base(game)
        {
        }

        public override void Run()
        {
            Clear();
            WriteLine(File.ReadAllText("Rules.txt"));
            ReadKey();
            Clear();
            MyGame.MyIntroMenu.Run();
        }
    }
}