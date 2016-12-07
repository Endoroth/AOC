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
                var turn2 = turn.Replace("[", "[_");            
                var split = turn2.Split(sp);
                bool valok = false;
                bool throwout = false;
                var lineok = 0;
                for (var i = 0; i < split.Count(); i++)
                {
                    valok = false;

                    //var valx = new Regex(@"(.)(?!\1)(.)\2\1").Match(testval).Groups[0].Value;
                    valok = new Regex(@"(.)(?!\1)(.)\2\1").IsMatch(split[i]);
                    throwout = new Regex(@"([\w])\1+\1+\1+").IsMatch(split[i]);

                    if ( throwout || (valok && split[i].Contains("_")))
                    {
                        lineok = 0;                     
                        break;
                    }
                    if (valok && !throwout && !split[i].Contains("_"))
                    {
                        lineok = 1;
                    }
                    
                }

                totalCount +=lineok;
                var valx = "";
                

                //write debug info
                for (var i = 0; i < split.Count(); i++)
                {
                    valx = valx + new Regex(@"(.)(?!\1)(.)\2\1").Match(split[i]).Groups[0].Value;
                }
                //write in console only if changed
                if (totalCount != totalCount_old)
                {
                    Console.WriteLine(countrow + "  " + valx + "  " + totalCount);
                    skriv.Add(countrow.ToString() + "  " + valx.ToString() + "  " + totalCount.ToString());
                    
                }
                totalCount_old = totalCount;
            }
            //write file
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Github\AOC\Advent\Output\DagFan7.txt"))
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