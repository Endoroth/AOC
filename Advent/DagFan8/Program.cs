using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagFan8
{
    internal static class Day
    {
        private static void Main()
        {
            var input = Utilities.GetInput(8);

            List<string> inputList = new List<string>();

            inputList = input.Split(new[]
                                          {
                                              "\r\n"
                                          }, StringSplitOptions.None).ToList();
                                          
            string[][] rows = new string[6][];
            rows[0] = new string[50];
            rows[1] = new string[50];
            rows[2] = new string[50];
            rows[3] = new string[50];
            rows[4] = new string[50];
            rows[5] = new string[50];
            for (var i = 0; i < 6; i++)
            {
                for (var q = 0; q < 50; q++)
                {
                    rows[i][q] = ".";
                }
            }
            foreach (var turn in inputList)
            {
                List<string> row_old = new List<string>();
                //inset new DATA
                if (turn.StartsWith("rect"))
                {
                    var index = turn.IndexOf("x");
                    var col = int.Parse(turn.Substring(5, index - 5));
                    var row = int.Parse(turn.Substring(index+1));
                    for (var i = 0; i < row; i++)
                    {
                        for (var q = 0; q < col; q++)
                        {
                            rows[i][q] = "#";
                        }
                    }
                }
                //rotate
                if (turn.StartsWith("rotate"))
                {
                    if (turn.Contains("row"))
                    {
                        var index = turn.IndexOf("by");
                        var row = int.Parse(turn.Substring(13, index - 14));
                        var moves = int.Parse(turn.Substring(index + 3));
                        var q = 0;
                        row_old = rows[row].ToList();
                        for (var i = 0; i < 50; i++)
                        {
                            q = i + moves;
                            while (q > 49)
                            { 
                                if (q > 49)
                                {
                                    q -= 50;
                                }
                            }
                            rows[row][q] = row_old.ElementAt(i);
                        }
                    }
                    if (turn.Contains("column"))
                    {
                        var index = turn.IndexOf("by");
                        var col = int.Parse(turn.Substring(16, index - 17));
                        var moves = int.Parse(turn.Substring(index + 3));
                        var q = 0;
                        for (var i = 0; i < 6; i++)
                        {
                            row_old.Add(rows[i][col]);
                        }
                        for (var i = 0; i < 6; i++)
                        {
                            q = i + moves;
                            while (q > 5)
                            {
                                if (q > 5)
                                {
                                    q -= 6;
                                }
                            }
                            rows[q][col] = row_old.ElementAt(i);

                        }
                    }
                }

                Console.WriteLine();
                for (var i = 0; i < 6; i++)
                {
                    Console.WriteLine(string.Join("", rows[i]));
                }
            }
            
            //Knuub
            Console.ReadKey();

        }
    }
}
