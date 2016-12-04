#region
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;

#endregion

namespace DagFan2
{

    internal static class Day
    {
        private static void Main()
        {
            var input = Utilities.GetInput(2);

            List<string> inputList = new List<string>();

            inputList = input.Split(new[]
                                          {
                                              "\n"
                                          }, StringSplitOptions.None).ToList();

            
                        
            List<string> position = new List<string>();

            foreach (var turn in inputList)
            {
                int _pos = 5;
                int nr = 0;

                while (nr < turn.Length)
                { 
                    string temp = turn.Substring(nr, 1);

                    if (temp == "U" && _pos != 1 && _pos !=2 && _pos != 3)
                    {
                        _pos = _pos - 3;
                    }
                    if (temp == "D" && _pos != 7 && _pos != 8 && _pos != 9)
                    {
                        _pos = _pos + 3;
                    }
                    if (temp == "R" && _pos != 3 && _pos != 6 && _pos != 9)
                    {
                        _pos = _pos + 1;
                    }
                    if (temp == "L" && _pos != 1 && _pos != 4 && _pos != 7)
                    {
                        _pos = _pos - 1;
                    }

                    nr++;
                }                          
                Console.WriteLine(_pos);
                position.Add(_pos.ToString());
            }

            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\!priv\AOC\Advent\Output\DagFan1.txt"))
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Github\AOC\Advent\Output\DagFan2.txt"))
            {
                foreach (var line in position)
                {
                    file.WriteLine(line);
                }
            }
            
                //Knuub
                Console.ReadKey();
        }
    }
}
