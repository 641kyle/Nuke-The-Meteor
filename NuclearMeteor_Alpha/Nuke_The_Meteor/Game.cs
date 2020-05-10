using System;
using static System.Console;
using Pastel;
using System.IO;
namespace Nuke_The_Meteor
{
    public class Game
    {
        //Im going to add the descriptions and such to a text file
        
        string description = "\nHello, and welcome to Nuke the Meteor. \nThe game where you must upgrade your rocket enough to destroy the incoming meteor!\n(Use Arrow Keys or WS keys to scroll. Press ENTER to make a Selection)";
  
        public double cash = 100;
        public double day = 1;
        //int upNum = 1;

        double CurrentAccuracy = 1;
        double CurrentSpeed = 1;
        double CurrentCombustion = 1;
        string Feedback;
        double MDT = 10;
        bool fin = false;
        string GameVersion = "Alpha: 0.1.0";
        double MoneyInvested;
        Meteor CurrentMeteor;
        Rocket CurrentRocket;

        public Game()
        {
            Title = "Nuke the Meteor";
            DisplayTitleArt();
            RunMainMenu();

        }

        private void RunMainMenu()
        {
            string[] welcomeOptions = { "New Game", "Continue", "About", "Help", "Exit" };
            Menu mainMenu = new Menu(description + "\n", welcomeOptions);
            int selectedIndex = mainMenu.MenuRun();

            switch (selectedIndex)
            {
                case 0:
                    NewGame();
                    break;
                case 1:
                    ContinueGame();
                    break;
                case 2:
                    AboutGame();
                    break;
                case 3:
                    Clear();
                    WriteLine(File.ReadAllText("Rules.txt"));
                    ReadKey();
                    Clear();
                    RunMainMenu();
                    break;
                case 4:
                    ExitGame();
                    break;
            }

        }

        private void UpgradeMenu()
        {
            string UpgradePrompt = $"What would you like to do?";
            string[] UpgradeOptions = { "Next Day", "Upgrade Rocket", "Invest", "Consult Scientist", "Launch Rocket" };
            ForegroundColor = ConsoleColor.Green;
            Menu upgradeMenu = new Menu(UpgradePrompt, UpgradeOptions);
            int selectedIndex = upgradeMenu.MenuRun(day, cash, CurrentSpeed, CurrentAccuracy, CurrentCombustion, Feedback);
            
                switch (selectedIndex)
                {
                    case 0:
                        NextDay(day, cash);
                        CurrentMeteor.MDTCalc(day, MDT);
                         MDT = CurrentMeteor.MDT;
                    InvestmentCalc(MoneyInvested);
                         break;
                    case 1:
                    ThreeUpgrade();
                        break;
                    case 2:
                     Invest();
                    break;
                    case 3:
                    ConsultScientist();
                        break;
                    case 4:
                    fin = true;
                    break;


                }

            //Feedback; ;

        }

        
        private void NewGame()
        {
            CurrentRocket = new Rocket();
            CurrentMeteor = new Meteor(day, MDT);

            do
            {
                do
                {

                    CurrentRocket.Combustion = CurrentCombustion;
                    CurrentRocket.Accuracy = CurrentAccuracy;
                    CurrentRocket.Speed = CurrentSpeed;


                    UpgradeMenu();



                    //MDT will not be displayed in final version
                    WriteLine(MDT);

                } while (day < 15 && !fin);
                fin = false;

                if (day < 15)
                {
                CurrentRocket.Launch(CurrentRocket.RocketDestruction(CurrentSpeed, CurrentAccuracy, CurrentCombustion, MDT), MDT);
                    CurrentSpeed = 1;
                    CurrentCombustion = 1;
                    CurrentAccuracy = 1;

                MDT = CurrentRocket.MDT;
                Feedback = CurrentRocket.Feedback;
                }
               
                Clear();

                


            } while (day < 15 && MDT > 0);

            if (MDT <= 0)
            {
                WriteLine("You Win!");
            }
            else
            {
                WriteLine("The meteor has hit earth...\nYou Lose!");

            }
        
        }

        private void ContinueGame()
        {
            //im guessing I will put NewGame(), but input stats from a textfile
            //Not sure I'll be able to but I'm going to try to implement this for funnnnn
            NewGame();
            
        }

        private void AboutGame()
        {
            WriteLine($"Hello! \nThere's not much about this game other than that it's for my Intro to Programming class! \nI'm not even a programming major! \nBut it's fun haha! \nOh me is Kyle Hansen! \nHave Fun!\n\nVersion: {GameVersion}");
            ReadKey(true);
            Clear();
            RunMainMenu();
        }

        private void ExitGame()
        {
            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }

        public void NextDay(double newday, double newcash)
        {
            day = newday + 1;
            cash = newcash + 100;
        }

        private void ThreeUpgrade()
        {
            string[] ASC = { "Accuracy", "Speed", "Combustion" };
            string prompt = "Which would you like to upgrade?";
            Menu ASCUpgrade = new Menu(prompt, ASC);
            int selectedIndex = ASCUpgrade.MenuRun(day, cash, CurrentSpeed, CurrentAccuracy, CurrentCombustion, Feedback);
            switch (selectedIndex)
            {
                case 0:
                    UpgradeAccuracy(CurrentAccuracy);

                    break;
                case 1:
                    UpgradeSpeed(CurrentSpeed);

                    break;
                case 2:
                    UpgradeCombustion(CurrentCombustion);
                    break;
            }

        }

        public void UpgradeSpeed(double speed)
        {

            Upgrade speedUp = new Upgrade("Speed", speed, 10, cash);
            cash = speedUp.FinalTotal;
            CurrentSpeed = speedUp.FinalUpNum;
            Write("                       ");
            ForegroundColor = ConsoleColor.Cyan;
            Feedback = speedUp.Feedback;
        }

        public void UpgradeAccuracy(double accuracy)
        {
            Upgrade accuracyUp = new Upgrade("Accuracy", accuracy, 20, cash);
            cash = accuracyUp.FinalTotal;
            CurrentAccuracy = accuracyUp.FinalUpNum;
            Write("                       ");
            ForegroundColor = ConsoleColor.DarkMagenta;
            Feedback = accuracyUp.Feedback;
        }

        private void UpgradeCombustion(double combustion)
        {
            Upgrade combustionUp = new Upgrade("Combustion", combustion, 50, cash);
            cash = combustionUp.FinalTotal;
            CurrentCombustion = combustionUp.FinalUpNum;
            ForegroundColor = ConsoleColor.Blue;
            Feedback = combustionUp.Feedback;
        }

        private void Invest()
        {
            string[] InvestOptions = { "Withdrawl", "Deposit", "Leave" };
            string[] YN = { "Yes", "No" };
            WriteLine($"You have: ${cash}\nYou have ${MoneyInvested} currently invested\nCurrent Investment Percentage increace {(day)}0%");
            Menu investMenu = new Menu("\n What would you like to do?", InvestOptions);
            int selectedIndex = investMenu.MenuRun();
            //bool end = false;
            //do
            //{
            switch (selectedIndex)
            {
                case 0:

                    WriteLine($"Current Investment: ${MoneyInvested} \nHow much would you like to Withdrawl?");

                    double moneyWithdrawn = Convert.ToDouble(ReadLine());
                    WriteLine($"You are withdrawling {moneyWithdrawn}");
                    MoneyInvested = MoneyInvested - moneyWithdrawn;
                    cash = cash + moneyWithdrawn;
                    break;
                case 1:
                    WriteLine($"Current Balance: ${cash} \nHow much would you like to Deposit?");
                    double moneytoInvest = Convert.ToDouble(ReadLine());
                    WriteLine($"You are depositing {moneytoInvest}");
                    MoneyInvested = MoneyInvested + moneytoInvest;
                    cash = cash - moneytoInvest;
                    break;
                case 2:
                    break;

            }
            //input money, over days money grows
        }

        private void InvestmentCalc(double currentInvested)
        {
            double InvestmentTotal = currentInvested + (currentInvested * ((day - 1)/ 10));
            MoneyInvested = InvestmentTotal;
        }

        private void DisplayTitleArt()
        {
            TitleScreen titleScreen = new TitleScreen();
        }

        private void ConsultScientist()
        {
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
                        WriteLine($"A Rocket with these satistics: \nSpeed: {Stest} \nAccuracy: {Atest}\nCombustion {Ctest} \n\nRocket Destruction: |{CurrentRocket.RocketDestruction(Stest, Atest, Ctest, MDT)}|");
                        
                    }
                    else if (selectedIndex == 1)
                    {
                        WriteLine($"Current Meteor Destruction: {MDT}");

                    }
                    else if (selectedIndex == 2)
                    {
                        WriteLine($"Tomorrow's Meteor Destruction: {CurrentMeteor.MDTCalc(day + 1, MDT)}");
                    }
                    else if (selectedIndex == 3)
                    {
                        Write("What day? \nDay:");
                        int DTest = Convert.ToByte(ReadLine());
                        Clear();
                        WriteLine($"Day {DTest} Meteor Destruction: {CurrentMeteor.PMDTCalc(DTest, day,  MDT)}");
                    }

                }
                fin = false;

            } while (!fin && !done);

        }

        private void CantAfford(double price, string prompt)
        {
            if (price > cash)
            {
            WriteLine("Sorry you can't afford this\n");

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
                    cash = cash - price;
                    break;
                case 1:
                    Clear();
                    fin = true;
                    break;
            }
        }

        
    }
}
