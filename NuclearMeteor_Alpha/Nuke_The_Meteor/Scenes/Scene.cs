using System;
using static System.Console;
namespace Nuke_The_Meteor.Scenes
{
    public class Scene
    {
        protected Game MyGame;

        public Scene(Game game)
        {
            MyGame = game;
        }

        virtual public void Run()
        {
            //this will be overwritten by child class

        }
    }
}
