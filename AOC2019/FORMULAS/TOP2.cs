using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;

namespace AOC2019.FORMULAS
{
    public class TOP2
    {
        public static string RunComputer(List<string> codes)
        {
            int actionPos = 0;
            while (codes[actionPos] != "99")
            {
                string state = codes[actionPos];
                int param1Pos = actionPos + 1;
                int param2Pos = actionPos + 2;
                int resultPos = actionPos + 3;
                int val1 = Convert.ToInt32(codes[Int32.Parse(codes[param1Pos])]);
                int val2 = Convert.ToInt32(codes[Int32.Parse(codes[param2Pos])]);
                int realResultPos = Int32.Parse(codes[resultPos]);
                
                if (state == "1")
                {
                    codes[realResultPos] = (val1 + val2).ToString();
                } else if (state == "2")
                {
                    codes[realResultPos] = (val1 * val2).ToString();
                }

                actionPos += 4;
            }
            
            //Console.Write(string.Join(",", codes.ToArray()));
            return codes[0];
        }

        public static void ReworkComputer(List<string> codes, string excpectedValue)
        {
            int maxValues = codes.Count - 1;
            int step = 0;
            int x = 0;
            int y = 0;

            string result = "";
            string state = "";
            Boolean keep = true;
            
            while (keep)
            {
                step++;
                List<string> tmpCodes = new List<string>(codes);
                tmpCodes[1] = x.ToString();
                tmpCodes[2] = y.ToString();
                try
                {
                    result = RunComputer(tmpCodes);
                    if (result == excpectedValue)
                    {
                        state = "FOUND !";
                        keep = false;
                    }
                    else
                    {
                        state = "NOT FOUND";
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    result = "/";
                    state = "FAILED";
                }
                
                Console.WriteLine("Step " + step + " : noun="+x+" verb="+y+" - "+result+" - " + state);

                if (keep)
                {
                    if (x < maxValues)
                    {
                        x++;
                    }
                    else if (x >= maxValues && y < maxValues)
                    {
                        x = 0;
                        y++;
                    }
                    else
                    {
                        keep = false;
                    }                    
                }

                
            }
            
            Console.Write("End of program : " + state);
            if (state == "FOUND !")
            {
                Console.Write(" - Final Result = " + (100 * x + y));
            }
        }
        
    }
}