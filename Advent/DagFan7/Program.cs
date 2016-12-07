#region
using System;
using Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

#endregion

namespace DagFan7
{
    internal static class Day
    {
        private static void Main()
        {
            var input = Utilities.GetInput(7);
            List<string> skriv = new List<string>();
            List<string> inputList = new List<string>();
            
            inputList = input.Split(new[]
                                          {
                                              "\r\n"
                                          }, StringSplitOptions.None).ToList();
            
            char[] sp = new char[2];
            sp[0] = '[';
            sp[1] = ']';
            int totalCount = 0;
            var totalCount_old = totalCount;
            var countrow = 0;

            foreach (var turn in inputList)
            {
                countrow++;             
                var split = turn.Split(sp);
                var check = turn.StartsWith("[");
                bool valok = false;
                bool fukka = false;
                for (var i = 0; i < split.Count(); i++)
                {
                    valok = false;

                    if (!check)
                    {
                        //var valx = new Regex(@"(.)(?!\1)(.)\2\1").Match(testval).Groups[0].Value;
                        valok = new Regex(@"(.)(?!\1)(.)\2\1").IsMatch(split[i]);
                    }
                    else //om inte check 
                    {
                        valok = new Regex(@"(.)(?!\1)(.)\2\1").IsMatch(split[i]);
                        
                        if (valok)
                        {
                            valok =false;
                            fukka = true;
                        }
                    }
                    check = !check;

                    if (valok && !fukka)
                    {
                        totalCount++;
                        break;
                    }
                    
                }
                var valx = new Regex(@"(.)(?!\1)(.)\2\1").Match(turn).Groups[0].Value;
                
                if (totalCount != totalCount_old)
                {
                    Console.WriteLine(countrow + "  " + valx + "  " + totalCount);
                    skriv.Add(countrow.ToString() + "  " + valx.ToString() + "  " + totalCount.ToString());
                    
                }
                totalCount_old = totalCount;
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\!priv\AOC\Advent\Output\DagFan7.txt"))
            {
                foreach (var line in skriv)
                {
                    file.WriteLine(line);
                }
            }
            //Knuub
            Console.ReadKey();
        }
    }
}