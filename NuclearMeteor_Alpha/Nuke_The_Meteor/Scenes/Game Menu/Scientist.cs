using System;
using static System.Console;
using System.IO;
namespace Nuke_The_Meteor.Scenes
{
    public class Scientist : Scene
    {
        double Price;
        bool done = false;
        bool fin;
        double cash;
        string history;

        public Scientist(Game game) : base(game)
        {
        }

        public override void Run()
        {
            cash = MyGame.cash;
            //they decide if it's a good idea to launch or not
            double Price;

            fin = true;
            bool done = false;
            string[] scientistOptions = { "Test Rocket Destruction: $250", "Current Meteor Destrucion: $500", "Meteor Destruction Tomorrow: $750", "Meteor Destrution Select Day: $1000", "Return to Home" };
            do
            {
                int selectedIndex;
                do
                {
                    Menu theScientist = new Menu("Scientist: 'Hello, what would you like me to do?'", scientistOptions);
                    int selectedIndex2 = theScientist.MenuRun();
                    switch (selectedIndex2)
                    {
                        case 0:
                            Price = 250;
                            CantAfford(Price, $"Cost: {Price}\nPlayer Balance: ${cash} \nNew Balance: ${cash - Price}\nWould you like to test Potential Rocket Statistics to see if they could destroy the meteor currently?");

                            break;
                        case 1:
                            Price = 500;
                            CantAfford(Price, $"Cost: {Price}\nPlayer Balance: ${cash} \nNew Balance: ${cash - Price}\nWould you like to know how much Rocket Destruction you need to destroy the meteor today?");
                            break;
                        case 2:
                            Price = 750;
                            CantAfford(Price, $"Cost: {Price}\nPlayer Balance: ${cash} \nNew Balance: ${cash - Price}\nWould you like to know how much Rocket Destruction you need to destroy the meteor tomorrow?");
                            break;
                        case 3:
                            Price = 1000;
                            CantAfford(Price, $"Cost: {Price}\nPlayer Balance: ${cash} \nNew Balance: ${cash - Price}\n\nWould you like to know how much Rocket Destruction you need to destroy the meteor on a certain day?");
                            break;
                        case 4:
                            done = true;
                            fin = false;
                            break;
                    }
                    selectedIndex = selectedIndex2;
                } while (fin);

                if (fin == false)
                {

                    int selectedIndex2 = selectedIndex;
                    if (selectedIndex2 == 0)
                    {
                        WriteLine("Type in potential satistics and find out the Rocket's Destruction..\n");
                        //Stats tester!!!
                        Write("Speed: ");
                        double Stest = Convert.ToByte(ReadLine());
                        Write("Accuracy: ");
                        double Atest = Convert.ToByte(ReadLine());
                        Write("Combustion: ");
                        double Ctest = Convert.ToByte(ReadLine());
                        WriteLine($"A Rocket with these satistics: \nSpeed: {Stest} \nAccuracy: {Atest}\nCombustion {Ctest} \n\nRocket Destruction: |{MyGame.CurrentRocket.RocketCalc(Stest, Atest, Ctest)}|");
                        history = $"\nTest Rocket Destruction Results: - Speed: {Stest} - Accuracy: {Atest} - Combustion {Ctest} - Rocket Destruction: |{MyGame.CurrentRocket.RocketCalc(Stest, Atest, Ctest)}|";

                    }
                    else if (selectedIndex == 1)
                    {
                        WriteLine($"Current Meteor Destruction: {MyGame.CurrentMeteor.MDT}");
                        history = $"\nToday's Meteor Destruction: {MyGame.CurrentMeteor.MDT}";
                    }
                    else if (selectedIndex == 2)
                    {
                        WriteLine($"Tomorrow's Meteor Destruction: {MyGame.CurrentMeteor.MDTCalc(MyGame.day + 1, MyGame.CurrentMeteor.MDT)}");
                        history = $"\nTomorrow's Meteor Destruction: {MyGame.CurrentMeteor.MDTCalc(MyGame.day + 1, MyGame.CurrentMeteor.MDT)}";
                    }
                    else if (selectedIndex == 3)
                    {
                        Write("What day? \nDay:");
                        int DTest = Convert.ToByte(ReadLine());
                        Clear();
                        WriteLine($"Day {DTest} Meteor Destruction: {MyGame.CurrentMeteor.PMDTCalc(DTest, MyGame.day, MyGame.CurrentMeteor.MDT)}");
                        history = $"\nMDT Day {DTest}: ";
                    }

                }
                fin = false;


                File.AppendAllText("History.txt", "\n" + history);
                history = null;

            } while (!fin && !done);

        }



        

            private void CantAfford(double price, string prompt)
            {
                if (price > cash)
                {
                    WriteLine("Sorry you can't afford this\n");
                    fin = true;

            }
                else
                {
                    YesNoMenu(prompt, price);
                }

            }

            private void YesNoMenu(string prompt, double price)
            {
                string[] YN = { "Yes", "No" };
                Menu yesUpgrade = new Menu(prompt, YN);
                int selectedIndex = yesUpgrade.MenuRun();
                switch (selectedIndex)
                {
                    case 0:
                        Clear();
                        fin = false;
                        MyGame.cash = cash - price;
                        break;
                    case 1:
                        Clear();
                        fin = true;
                        break;
                }
            }

        
    }
}