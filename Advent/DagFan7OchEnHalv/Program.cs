#region
using System;
using Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

#endregion

namespace DagFan7OchEnHalv
{
    internal static class Day
    {
        private static void Main()
        {
            var input = Utilities.GetInput(7);
            
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
                List<string> ssllist = new List<string>();
                List<string> ssllistBrack = new List<string>();
                countrow++;
                var turn2 = turn.Replace("[", "[_");
                var split = turn2.Split(sp);
                var isok = false;
                foreach(var spl in split)
                {
                    isok = false;
                    var l1 = "";
                    var l2 = "";
                    var l3 = "";
                    for(var i = 0; i < spl.Count(); i++)
                    {
                        l1 = spl.Substring(i, 1);

                        if (l1 == l3 && !( l1 == l2) && spl.StartsWith("_"))
                        {
                            ssllistBrack.Add(l1 + l2 + l3);
                        }

                        if (l1 == l3 && !(l1 == l2) && !spl.StartsWith("_"))
                        {
                            ssllist.Add(l1 + l2 + l3);
                        }
                        l3 = l2;
                        l2 = l1;
                    }

                    foreach (var aba in ssllist)
                    {
                        var search = aba.Substring(1, 1) + aba.Substring(0, 1) + aba.Substring(1, 1);
                        foreach(var bab in ssllistBrack)
                        {
                            if (bab == search)
                            {
                                isok = true;
                            }
                        }
                    }
                }
                if (isok)
                { 
                    totalCount++;
                }
                
                //write in console only if changed
                if (totalCount != totalCount_old)
                {
                    Console.WriteLine(countrow + "  " + totalCount);
                    ssllist.Add(countrow.ToString() + "  " + totalCount.ToString());

                }
                totalCount_old = totalCount;
            }
            //Knuub
            Console.ReadKey();
        }
    }
}