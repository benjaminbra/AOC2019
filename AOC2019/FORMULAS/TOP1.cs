using System;
using System.Collections.Generic;

namespace AOC2019.FORMULAS
{
    public class TOP1
    {
        public static int GetTotalFuel(List<string> masses)
        {
            int totalFuel = 0;

            foreach (var mass in masses)
            {
                totalFuel += GetFuel(Convert.ToInt32(mass));
            }
            
            return totalFuel;
        }
        
        public static int GetFuel(int mass)
        {
            int totalFuel = GetSimpleFuel(mass);
            int actualMass = totalFuel;
            //String listOfFuel = totalFuel.ToString();
            while (actualMass > 0)
            {
                int tmpFuel = GetSimpleFuel(actualMass);
                actualMass = tmpFuel;
                if (actualMass > 0)
                {
                    //listOfFuel += " + " + tmpFuel;
                    totalFuel += tmpFuel;   
                }
            }

            //Console.Write(listOfFuel + " = ");
            
            return totalFuel;
        }

        public static int GetSimpleFuel(int mass)
        {
            return (int) (Math.Floor((decimal) mass / 3) - 2);
        }
    }
}