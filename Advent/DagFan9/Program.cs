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
            string output = "";
            var lenght = 1;
            var timesm = 2;
            var compressed = 0;
            //for ( var i = 0; i < input.Length; i++)
            while (input.Length > 0 )
            {
                var checkletter = input.Substring(0, 1);
                var checkL = new Regex(@"[A-Z]+").IsMatch(checkletter);
                var subEnd = 0;
                //Check ( and count multiply
                if (checkletter == "(" )
                {
                    var subX = input.IndexOf("x", 0);
                    subEnd = input.IndexOf(")", 0);
                    lenght = int.Parse(input.Substring(0 + 1, (subX - 0) - 1));
                    timesm = int.Parse(input.Substring(subX + 1, (subEnd - subX) - 1 ));
                    
                }
                checkletter = input.Substring(0, 1);
                checkL = new Regex(@"[A-Z]+").IsMatch(checkletter);
                
               // addsub1 = input.Substring(subEnd + 1, lenght + count + 1);
                var addstring = "";
                for (var q = 1; q < timesm; q++)
                {
                    if (checkL)
                    {
                        output = output + input.Substring(0, lenght);
                        compressed++;
                    }
                    else if (checkletter == "(")
                    {
                        var addsub1 = input.Substring(subEnd + 1, lenght);
                        addstring = addstring + addsub1;
                    }
                }
                if (checkL)
                {
                    input = input.Substring(lenght);
                }
                else
                {
                    input = input.Substring(subEnd+1);
                }
                for (var i = 0; i < addstring.Length; i++)
                {
                    checkletter = input.Substring(0, 1);
                    checkL = new Regex(@"[A-Z]+").IsMatch(checkletter);
                    if (checkL)
                    {
                        output = output + input.Substring(0, lenght);
                        compressed++;
                    }
                }

                timesm = 2;
                lenght = 1;

                Console.WriteLine(input.Length);
            }
            Console.WriteLine(output.Length + "     " + compressed);
            //Knuub
            Console.ReadKey();
            
        }
    }
}