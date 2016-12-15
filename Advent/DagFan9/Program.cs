#region
using System;
using Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

#endregion

namespace DagFan9
{
    internal static class Day
    {
        private static void Main()
        {
            var input = Utilities.GetInput(9);
            var lenght = 1;
            var timesm = 1;
            long count = 0;
            long countcheck = 0;
            //for ( var i = 0; i < input.Length; i++)
            while (input.Length > 0 )
            {
                var checkletter = input.Substring(0, 1);
                var subEnd = 0;
                //Check ( and count multiply
                if (checkletter == "(" )
                {
                    var subX = input.IndexOf("x", 0);
                    subEnd = input.IndexOf(")", 0);
                    lenght = int.Parse(input.Substring(0 + 1, (subX - 0) - 1));
                    timesm = int.Parse(input.Substring(subX + 1, (subEnd - subX) - 1 ));
                    
                }
                else
                {
                    lenght = input.IndexOf("(", 0);
                    if (lenght == -1 )
                    {
                        lenght = input.Length;
                    }
                }
                                
                if (subEnd > 0 )
                { subEnd += 1; }
                var addstr = "";
                for (var q = 0; q < timesm; q++)
                {
                    addstr = addstr + input.Substring(subEnd, lenght);

                }

                count += addstr.Length;

                if (checkletter == "(")
                {
                    input = addstr + input.Substring(subEnd + lenght);
                }
                else
                {
                    input = input.Substring(subEnd + lenght);
                }
                timesm = 1;
                lenght = 1;

                if (count > countcheck)
                {
                    Console.WriteLine(input.Length + "    " + count);
                    countcheck += 1000000;
                }
            }

            Console.WriteLine(input.Length + "    " + count);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Github\AOC\Advent\Output\DagFan9.txt"))
            {
                    file.WriteLine(count);
                
            }
            //Knuub
            Console.ReadKey();
            
        }
    }
}