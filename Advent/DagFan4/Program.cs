using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using System.Text.RegularExpressions;

namespace DagFan4
{
    public class countletters
    {
        public string letterX { get; set; }
        public int countX { get; set; }
    }

    internal static class Day
    {
        private static void Main()
        {
           var input = Utilities.GetInput(4);

            List<string> test = new List<string>();
            List<string> inputList = new List<string>();

            inputList = input.Split(new[]
                                          {
                                              "\r\n"
                                          }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var totalID = 0;
            string alfhab = "abcdefghijklmnopqrstuvwxyza";

            foreach (var turn in inputList)
            {
                List<string> checkletters = new List<string>();
                List<string> turnlist = new List<string>();


                var ID = Int32.Parse(Regex.Match(turn, @"\d+").Value);
                var len = turn.Length;
                var startChecksum = turn.IndexOf("[") + 1;
                var checksum = turn.Substring(startChecksum, len - startChecksum -1);
                
                for (var i = 0; i < checksum.Length; i++)
                {
                    checkletters.Add(checksum.Substring(i, 1));
                }
                List<string> tomtelista = new List<string>();
                
                for (var l = 0; l < turn.Length; l++)
                {
                    var tempval = turn.Substring(l, 1);
                    char pluschar = tempval[0];
                    if (Regex.IsMatch(tempval, @"^[a-zA-Z]+$"))
                    {
                        turnlist.Add(tempval);

                        int index = char.ToUpper(pluschar) - 65; //0 till 1bas?
                        for (var idx = 0; idx < ID; idx++)
                        {
                            index++;
                            if (index == 27) { index = 1; }
                        }                         
                        
                        tomtelista.Add(alfhab.Substring(index, 1));

                    }
                    
                }
                turnlist.Sort();
                List<countletters> answ = new List<countletters>();
                var turnlist_old = turnlist.ElementAt(0);
                var countl = 0;
                for (var q = 0; q < turnlist.Count(); q++)
                {
                    if (turnlist.ElementAt(q) == turnlist_old)
                    {
                        countl++;
                    }
                    else
                    {
                        answ.Add(new countletters { countX = countl, letterX = turnlist_old });
                        countl = 1;
                    }
                    turnlist_old = turnlist.ElementAt(q);
                    //get last
                    if (q == turnlist.Count() - 1)
                    {
                        answ.Add(new countletters { countX = countl, letterX = turnlist_old });
                    }

                }
                checkletters.Sort();
                string[] top5 = new string[5];
                int[] top5i = new int[5];
                List<int> countcode = new List<int>();
                for (var w = 0; w < checkletters.Count(); w++)
                {
                    foreach(var labb in answ)
                    {
                        if (checkletters.ElementAt(w).ToString() == labb.letterX.ToString())
                        {
                            top5i[w] = labb.countX;
                            top5[w] = labb.letterX;
                        }                        
                    }
                }
                foreach (var labb in answ)
                {
                    countcode.Add(labb.countX);
                }
                    List<int> top5list = new List<int>();

                top5list = top5i.ToList();
                top5list.Sort();
                var codeCheck = "";
                var codeSum = "";
                countcode.Sort();
                countcode.Reverse();
                top5list.Reverse();
                foreach (var skriv in top5list)
                {
                    codeCheck = codeCheck + skriv.ToString();
                }
                for (var i = 0; i < 5; i++)
                {
                    codeSum = codeSum + countcode.ElementAt(i).ToString();
                }

                if(codeCheck == codeSum)
                {
                    totalID = totalID + ID;
                }


                //leta efter nordpolen
                var northp = "";
                foreach (var nord in tomtelista)
                {
                    northp = northp + nord;
                }

                if (northp.Contains("north"))
                {
                    Console.WriteLine("nordpolen" + ID);

                }
                test.Add(northp + " " + ID.ToString());
                                
            }

            Console.WriteLine(totalID);
            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\!priv\AOC\Advent\Output\DagFan1.txt"))
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Github\AOC\Advent\Output\DagFan4.txt"))
            {
                foreach (var np in test)
                { 
                file.WriteLine(np);
                }
            }

            //Knuub
            Console.ReadKey();
        }
    }
}
