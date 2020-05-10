using System;
using static System.Console;
using Pastel;
namespace Nuke_The_Meteor
{
    public class Upgrade
    {
        public double Price;
        double UpgradeNum;
        string UpgradedItem;
        public double FinalTotal;
        public double FinalUpNum;
        public string Feedback;
        bool upgrade;
        double num;


        //add so they can choose what level they want to upgrade to inorder for them to skip levels and save money
        public Upgrade(string upgradeItem, double upgradeNum, double startPrice, double ammountHave)
        {
            UpgradeMenu(upgradeItem, upgradeNum, startPrice, ammountHave);

        }


        //add so they can choose what level they want to upgrade to inorder for them to skip levels and save money
        //public void Update(string upgradeItem, double power, double startPrice, double ammountHave)
        //{
        //    bool done = false;
        //    UpgradedItem = upgradeItem;

           
        //    bool fin = false;
            
        //       // Price = Math.Pow(startPrice, (numresponce));

            

        //    double potentialLeft = ammountHave - Price;

        //    if (fin)
        //    {
        //        Clear();
        //        ForegroundColor = ConsoleColor.Red;
        //        Write("                           ");
        //        WriteLine("Not a valid responce");
        //        ResetColor();
        //        FinalTotal = ammountHave;
        //    }
        //    else if (potentialLeft >= 0)
        //    {
        //        do
        //        {
        //            //change to menu
        //            do
        //            {
        //                WriteLine($"That will be: ${Price} \nYou will have ${potentialLeft} left today... \nAre you sure you want to upgrade {upgradeItem}? (Y/N)");
        //                string response = ReadLine().ToString().ToLower();
        //                if (response.StartsWith("y"))
        //                {
        //                    done = true;
        //                    fin = true;
        //                    //FinalUpNum = UpgradeNum + numresponce;
        //                    FinalTotal = potentialLeft;
        //                    Feedback = $"Your {upgradeItem} is now level: {FinalUpNum}";
        //                    Clear();
        //                }
        //                else if (response.StartsWith("n"))
        //                {
        //                    done = true;
        //                    fin = true;
        //                    FinalTotal = ammountHave;
        //                    Clear();
        //                }
        //                else
        //                {

        //                }

        //            } while (!fin);



        //        } while (!done);

            //}
            //else
            //{
            //    FinalUpNum = power;
            //    ForegroundColor = ConsoleColor.Red;
            //    Feedback = $"Sorry, you cannot afford an {UpgradedItem} Upgrade at this Time";
            //    FinalTotal = ammountHave;
            //}



       // }


        public void UpgradeMenu(string upgradeItem, double power, double startPrice, double ammountHave)
        {
            //int LNum = 2;
            string[] levelNums = { $"Level 2", $"Level 3", "Level 4", "Level 5", "Level 6", "Level 7", "Level 8", "Level 9", "Level 10", "None"};
            //string[] levelNums = { $"Level {LNum} {Price}" * 10
            upgrade = false;
            do
            {
                Menu upgradeMenu = new Menu($"What level would you like to updgrade your Rocket's {upgradeItem}?", levelNums);
                int selectedIndex = upgradeMenu.MenuRun();
                upgrade = true;
                FinalUpNum = power;
                switch (selectedIndex)
                {
                    case 0:
                        num = 2;
                        break;
                    case 1:
                        num = 3;
                        break;
                    case 2:
                        num = 4;
                        break;
                    case 3:
                        num = 5;
                        break;
                    case 4:
                        num = 6;
                        break;
                    case 5:
                        num = 7;
                        break;
                    case 6:
                        num = 8;
                        break;
                    case 7:
                        num = 9;
                        break;
                    case 8:
                        num = 10;
                        break;
                    case 9:
                        num = power;
                        FinalTotal = ammountHave;
                        upgrade = false;
                        break;

                }
                Price = startPrice * num;
                double potentialLeft = ammountHave - Price;

                if (upgrade == true && num > power && Price <= ammountHave)
                {
                    string[] YN = { "Yes", "No" };
                    Menu yesUpgrade = new Menu($"Upgrade Cost: ${Price} \nPlayer Balance: ${ammountHave} \nNew Balance: ${potentialLeft} \n{upgradeItem} Level: {num} \n\nConfirm?\n", YN);
                    int selectedIndex2 = yesUpgrade.MenuRun();

                    switch (selectedIndex2)
                    {
                        case 0:
                            FinalTotal = ammountHave - Price;
                            FinalUpNum = num;
                            Feedback = $"Your {upgradeItem} is now level: {FinalUpNum}";
                            break;
                        case 1:
                            Feedback = "Your Upgrade was terminated";
                            
                            break;
                    }
                    upgrade = true;

                    Clear();
                }
                else if (num == power)
                {
                    FinalUpNum = power;
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"{upgradeItem} is currently Level {num}");
                    FinalTotal = ammountHave;
                }
                else if (num < power)
                {
                    FinalUpNum = power;
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"{upgradeItem} is higher then Level {num}");
                    FinalTotal = ammountHave;
                }
                else if(Price > ammountHave)
                {
                    FinalUpNum = power;
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"{upgradeItem} is too Expensive");
                    FinalTotal = ammountHave;
                }
                else
                {
                    FinalUpNum = power;
                    ForegroundColor = ConsoleColor.Red;
                    upgrade = true;
                    FinalTotal = ammountHave;

                }
              

            } while (!upgrade);

        }


    }
}