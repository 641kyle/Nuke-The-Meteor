using System;
using static System.Console;
namespace Nuke_The_Meteor.Scenes
{
    public class About : Scene
    {
        public About(Game game) : base(game)
        {
        }

        public override void Run()
        {
            WriteLine($"Hello! \nThere's not much about this game other than that it's for my Intro to Programming class! \nI'm not even a programming major! \nBut it's fun haha! \nOh me is Kyle Hansen! \nHave Fun!\n\nVersion: {MyGame.GameVersion}");
            ReadKey(true);
            Clear();
            MyGame.MyIntroMenu.Run();
        }
    }
}
