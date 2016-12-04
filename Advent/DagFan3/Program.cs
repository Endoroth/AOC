using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;

namespace DagFan3
{
    internal static class Day
    {
        private static void Main()
        {
            var input = Utilities.GetInput(3);

            List<string> inputList = new List<string>();

            inputList = input.Split(new[]
                                          {
                                              "\r\n"
                                          }, StringSplitOptions.RemoveEmptyEntries).ToList();



            int countCompleted = 0;
            int triangleturn = 0;
            int[] triangle1 = new int[3];
            int[] triangle2 = new int[3];
            int[] triangle3 = new int[3];
            foreach (var turn in inputList)
            {
                List<string> trianglelist = new List<string>();
                trianglelist = turn.Split(new[]
                                            {
                                                " "
                                            }, StringSplitOptions.RemoveEmptyEntries).ToList();
                //reset count
                if (triangleturn > 2) { triangleturn = 0; }


                                int nr = 0;

                foreach (var side in trianglelist)
                {
                    if (nr == 0) { triangle1[triangleturn] = Int32.Parse(side.ToString()); }
                    if (nr == 1) { triangle2[triangleturn] = Int32.Parse(side.ToString()); }
                    if (nr == 2) { triangle3[triangleturn] = Int32.Parse(side.ToString()); }
                    nr++;
                }

                if (triangleturn == 2)
                {
                    if (triangle1[0] + triangle1[1] > triangle1[2] && triangle1[0] + triangle1[2] > triangle1[1] && triangle1[1] + triangle1[2] > triangle1[0])
                    {
                        countCompleted++;
                    }
                    if (triangle2[0] + triangle2[1] > triangle2[2] && triangle2[0] + triangle2[2] > triangle2[1] && triangle2[1] + triangle2[2] > triangle2[0])
                    {
                        countCompleted++;
                    }
                    if (triangle3[0] + triangle3[1] > triangle3[2] && triangle3[0] + triangle3[2] > triangle3[1] && triangle3[1] + triangle3[2] > triangle3[0])
                    {
                        countCompleted++;
                    }
                }
                triangleturn++;

            }

            Console.WriteLine(countCompleted);
            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\!priv\AOC\Advent\Output\DagFan1.txt"))
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Github\AOC\Advent\Output\DagFan3.txt"))
            {
                file.WriteLine(countCompleted.ToString());

            }

            //Knuub
            Console.ReadKey();
        }
    }
}
