using System;
using static System.Console;
using Pastel;
namespace Nuke_The_Meteor
{
    public class Rocket
    {
        public double Speed = 1;
        public double Accuracy = 1;
        public double Combustion = 1;
        double RD;
        public string Feedback;
        public double MDT;
        public Rocket()
        {

            

        }

        public double RocketDestruction(double speed, double accuracy, double combustion, double mdt)
        {
            MDT = mdt;
            Speed = speed;
            Accuracy = accuracy;
            Combustion = combustion;
            double RD = Math.Pow(speed * accuracy, combustion);
            return RD;
            
            
        }

        public double Launch(double RD, double mdt)
        {
            Feedback =  "Rockets launching (not really yet, but it will.. weeeeeeee";
            
            MDT = mdt;
            if (RD >= MDT)
            {
                MDT = 0;
            }
            else if (MDT > RD)
            {
                MDT = MDT - RD + 1;
                
                Speed = 1;
                Accuracy = 1;
                Combustion = 1;
            }
            return MDT;
            //this part will compare the Rocket destruction to the meteors MDT
            //if MDT>RD Rocket is destroyed, new rocket, everything is level 1, however MDT is lowerd by however much RD the rocket had, MDT = MDT - RD;
            //if RD>MDT = Win!
        }
    }
}
