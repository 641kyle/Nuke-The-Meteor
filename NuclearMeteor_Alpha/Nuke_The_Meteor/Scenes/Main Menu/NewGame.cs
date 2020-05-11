using System;
using Nuke_The_Meteor.Scenes;
namespace Nuke_The_Meteor.Scenes.MainMenu
{
    public class NewGame : Scene
    {
        public Rocket CurrentRocket;
        public Meteor CurrentMeteor;
        public int day = 1;
        public double MDT;

        public NewGame(Game game) : base(game)
        {
        }

        public override void Run()
        {
            

            do
            {
                do
                {

                    CurrentRocket.Combustion = CurrentCombustion;
                    CurrentRocket.Accuracy = CurrentAccuracy;
                    CurrentRocket.Speed = CurrentSpeed;


                    



                    //MDT will not be displayed in final version
                    WriteLine(MDT);

                } while (day < 15 && !fin);
                fin = false;

                if (day < 15)
                {
                    CurrentRocket.Launch(CurrentRocket.RocketDestruction(CurrentRocket.Speed, CurrentRocket.Accuracy, CurrentRocket.Combustion, MDT), MDT);


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
            ReadKey();
        }


        public void NewRocket()
        {
            CurrentRocket = new Rocket();

        }

        public void NewMeteor()
        {
            CurrentMeteor = new Meteor(day, MDT);
        }

        public void NextDay(double newday, double newcash)
        {
            day = newday + 1;
            cash = newcash + 100;
        }
    }
}
