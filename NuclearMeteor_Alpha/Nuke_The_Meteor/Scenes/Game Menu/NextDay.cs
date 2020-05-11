using System;
using System.IO;
namespace Nuke_The_Meteor.Scenes
{
    public class NextDay : Scene
    {
        public NextDay(Game game) : base(game)
        {
        }

        public override void Run()
        {
            MyGame.day = MyGame.day + 1;
            MyGame.cash = MyGame.cash + 100;
            MyGame.MyInvest.InvestmentCalc(MyGame.MyInvest.MoneyInvested);
            MyGame.CurrentMeteor.MDTCalc(MyGame.day, MyGame.CurrentMeteor.MDT);

            //I got help from https://stackoverflow.com/questions/9559616/c-sharp-add-text-to-text-file-without-rewriting-it
            File.AppendAllText("History.txt", $"\n\nDay {MyGame.day}:");
        }
    }
}