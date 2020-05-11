using System;
using static System.Console;
using System.IO;
namespace Nuke_The_Meteor.Scenes
{
    public class Invest : Scene
    {
        public double MoneyInvested;
        double cash;
        string history;
        string numHistory;
        string investHistory;

        public Invest(Game game) : base(game)
        {
            cash = MyGame.cash;
        }

        public override void Run()
        {
            string[] InvestOptions = { "Withdrawl", "Deposit", "Leave" };
            string[] YN = { "Yes", "No" };
            WriteLine($"You have: ${cash}\nYou have ${MoneyInvested} currently invested\nCurrent Investment Percentage increace {(MyGame.day)}0%");
            numHistory = $"You had ${MoneyInvested} at |{(MyGame.day)}0%|";
            Menu investMenu = new Menu("\n What would you like to do?", InvestOptions);
            int selectedIndex = investMenu.MenuRun();

            switch (selectedIndex)
            {
                case 0:

                    WriteLine($"Current Investment: ${MoneyInvested} \nHow much would you like to Withdrawl?");

                    double moneyWithdrawn = Convert.ToDouble(ReadLine());
                    WriteLine($"You are withdrawling {moneyWithdrawn}");
                    MoneyInvested = MoneyInvested - moneyWithdrawn;
                    cash = cash + moneyWithdrawn;
                    history = $"You withdrew: ${moneyWithdrawn}";
                    break;
                case 1:
                    WriteLine($"Current Balance: ${cash} \nHow much would you like to Deposit?");
                    double moneytoInvest = Convert.ToDouble(ReadLine());
                    WriteLine($"You are depositing {moneytoInvest}");
                    MoneyInvested = MoneyInvested + moneytoInvest;
                    MyGame.cash = cash - moneytoInvest;
                    history = $"You despoited: ${moneytoInvest}";
                    break;

            }
            investHistory = (numHistory + "\n" + history);
            File.AppendAllText("History.txt", "\n" + investHistory);
            //input money, over days money grows
        }

        public void InvestmentCalc(double currentInvested)
        {
            MoneyInvested = currentInvested + (currentInvested * ((MyGame.day - 1) / 10));
        }
    }
    
}