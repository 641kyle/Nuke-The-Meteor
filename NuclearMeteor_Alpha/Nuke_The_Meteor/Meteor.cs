using System;
using static System.Console;
using Pastel;
namespace Nuke_The_Meteor
{
    public class Meteor
    {
        public double MDT;

        //double IMDT = 10;

        public Meteor(double day, double CMDT)
        {
            MDT = day * CMDT;

        }

        public double MDTCalc(double day, double CMDT)
        {
            MDT = day * CMDT;

            return MDT;
        }


        public double PMDTCalc(int ChoosenDay, double CurrentDay, double CMDT)
        {
            double IMDT = CMDT;
            int currentDay = Convert.ToInt32(CurrentDay);
            int DayRepeater = ChoosenDay - currentDay;
            
            //currently does good 1 day up
            for (int i = 0; i < DayRepeater; i++)
            {
                
                MDT = (currentDay + i + 1) * IMDT;

                IMDT = MDT;
                
            }



            return IMDT;

        }
    }
}

