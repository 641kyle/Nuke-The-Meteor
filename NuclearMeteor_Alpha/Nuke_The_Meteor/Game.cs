using System;
using static System.Console;
using Pastel;
using System.IO;
using Nuke_The_Meteor.Scenes;
using Nuke_The_Meteor.Scenes.GameMenu;
using Nuke_The_Meteor.Scenes.MainMenu;

namespace Nuke_The_Meteor
{
    public class Game
    {
        //Im going to add the descriptions and such to a text file
        
        
        public double cash = 100;
        public double day = 1;

        public string Feedback;

        public bool fin = false;
        public string GameVersion = "Alpha: 0.1.0";
        double MoneyInvested;

        public Meteor CurrentMeteor;
        public Rocket CurrentRocket;

        public IntroMenu MyIntroMenu;
        public About MyAbout;
        public Help MyHelp;
        public UpgradeMenu MyUpgradeMenu;
        public ThreeUpgrade MyThreeUpgrade;
        public Scientist MyScientist;
        public NextDay MyNextDay;
        public Invest MyInvest;
        public History MyHistory;
        double MDT =  10;

        public Game()
        {
            TitleScreen titleScreen = new TitleScreen();

            MyIntroMenu = new IntroMenu(this);
            MyAbout = new About(this);
            MyHelp = new Help(this);
            MyInvest = new Invest(this);
            MyNextDay = new NextDay(this);
            MyScientist = new Scientist(this);
            MyThreeUpgrade = new ThreeUpgrade(this);
            MyUpgradeMenu = new UpgradeMenu(this);
            MyHistory = new History(this);

            Start();

        }

        public void Start()
        {
            MyIntroMenu.Run();

        }
        
        public void NewGame()
        {
            CurrentMeteor = new Meteor(day, MDT);
            MDT = CurrentMeteor.MDT;
            CurrentRocket = new Rocket();
            do
            {
                do
                {
                    MyUpgradeMenu.Run();
                 

                } while (day < 15 && !fin);
                fin = false;

                if (day < 15)
                {
                    CurrentRocket.Launch(CurrentRocket.RocketDestruction(CurrentRocket.Speed, CurrentRocket.Accuracy, CurrentRocket.Combustion, CurrentMeteor.MDT), CurrentMeteor.MDT);

                    Feedback = CurrentRocket.Feedback;
                }

                Clear();




            } while (day < 15 && CurrentMeteor.MDT > 0);

            if (CurrentMeteor.MDT <= 0)
            {
                WriteLine("You Win!");
            }
            else
            {
                WriteLine("The meteor has hit earth...\nYou Lose!");

            }
            File.Delete("History.txt");
            ReadKey();
        }

        private void ContinueGame()
        {
            //im guessing I will put NewGame(), but input stats from a textfile
            //Not sure I'll be able to but I'm going to try to implement this for funnnnn
            NewGame();
            
        }

        
        
    }
}
