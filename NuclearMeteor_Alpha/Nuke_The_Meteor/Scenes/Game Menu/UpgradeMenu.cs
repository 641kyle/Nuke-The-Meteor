using System;
using static System.Console;
namespace Nuke_The_Meteor.Scenes
{
    public class UpgradeMenu : Scene
    {
        string Feedback;

        public UpgradeMenu(Game game) : base(game)
        {
        }

        public override void Run()
        {
            string UpgradePrompt = $"What would you like to do?";
            string[] UpgradeOptions = { "Next Day", "Upgrade Rocket", "Invest", "Consult Scientist", "Display History", "Launch Rocket" };
            ForegroundColor = ConsoleColor.Green;
            Menu upgradeMenu = new Menu(UpgradePrompt, UpgradeOptions);
            int selectedIndex = upgradeMenu.MenuRun(MyGame.day, MyGame.cash, MyGame.CurrentRocket.Speed, MyGame.CurrentRocket.Accuracy, MyGame.CurrentRocket.Combustion, Feedback);

            switch (selectedIndex)
            {
                case 0:
                    MyGame.MyNextDay.Run();
                    break;
                case 1:
                    MyGame.MyThreeUpgrade.Run();
                    break;
                case 2:
                    MyGame.MyInvest.Run();
                    break;
                case 3:
                    MyGame.MyScientist.Run();
                    break;
                case 4:
                    MyGame.MyHistory.Run();
                    break;
                case 5:
                    MyGame.fin = true;
                    break;


            }

            Feedback = null;
        }
    }

}
