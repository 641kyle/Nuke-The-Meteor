using System;
using static System.Console;
namespace Nuke_The_Meteor.Scenes
{
    public class ThreeUpgrade : Scene
    {
        public ThreeUpgrade(Game game) : base(game)
        {
        }

        public override void Run()
        {
            string[] ASC = { "Accuracy", "Speed", "Combustion", "Home" };
            string prompt = "Which would you like to upgrade?";
            Menu ASCUpgrade = new Menu(prompt, ASC);
            int selectedIndex = ASCUpgrade.MenuRun(MyGame.day, MyGame.cash, MyGame.CurrentRocket.Speed, MyGame.CurrentRocket.Accuracy, MyGame.CurrentRocket.Combustion, MyGame.Feedback);
            switch (selectedIndex)
            {
                case 0:
                    UpgradeAccuracy(MyGame.CurrentRocket.Accuracy);

                    break;
                case 1:
                    UpgradeSpeed(MyGame.CurrentRocket.Speed);

                    break;
                case 2:
                    UpgradeCombustion(MyGame.CurrentRocket.Combustion);
                    break;
                case 3:
                    MyGame.MyUpgradeMenu.Run();
                    break;
            }
        }

        public void UpgradeSpeed(double speed)
        {

            Upgrade speedUp = new Upgrade("Speed", speed, 10, MyGame.cash);
            MyGame.cash = speedUp.FinalTotal;
            MyGame.CurrentRocket.Speed = speedUp.FinalUpNum;
            Write("                       ");
            ForegroundColor = ConsoleColor.Cyan;
            MyGame.Feedback = speedUp.Feedback;
        }

        public void UpgradeAccuracy(double accuracy)
        {
            Upgrade accuracyUp = new Upgrade("Accuracy", accuracy, 20, MyGame.cash);
            MyGame.cash = accuracyUp.FinalTotal;
            MyGame.CurrentRocket.Accuracy = accuracyUp.FinalUpNum;
            Write("                       ");
            ForegroundColor = ConsoleColor.DarkMagenta;
            MyGame.Feedback = accuracyUp.Feedback;
        }

        private void UpgradeCombustion(double combustion)
        {
            Upgrade combustionUp = new Upgrade("Combustion", combustion, 50, MyGame.cash);
            MyGame.cash = combustionUp.FinalTotal;
            MyGame.CurrentRocket.Combustion = combustionUp.FinalUpNum;
            ForegroundColor = ConsoleColor.Blue;
            MyGame.Feedback = combustionUp.Feedback;
        }
    }
}