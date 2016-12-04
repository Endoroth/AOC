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
                    int fault;

                    if (temp == "U" && _pos != 5 && _pos !=2 && _pos != 1 && _pos != 4 && _pos != 9)
                    {
                        if (_pos > 5 && _pos < 13) { _pos = _pos - 4; }
                        else if (_pos == 3 || _pos == 13) { _pos = _pos - 2; }
                    }
                    if (temp == "D" && _pos != 5 && _pos != 10 && _pos != 12 && _pos != 9 && _pos != 13)
                    {
                        if (_pos == 1 || _pos == 11) { _pos = _pos + 2; }
                        else { _pos = _pos + 4; }
                    }
                    if (temp == "R" && _pos != 1 && _pos != 4 && _pos != 9 && _pos != 12 && _pos != 13)
                    {
                        _pos = _pos + 1;
                    }
                    if (temp == "L" && _pos != 1 && _pos != 2 && _pos != 5 && _pos != 10 && _pos != 13)
                    {
                        _pos = _pos - 1;
                    }
                    if (_pos > 13)
                    {
                        fault = 1;
                    }
                    nr++;
                }
                string _posT = _pos.ToString();
                if (_pos > 9)
                {
                    if (_pos == 10 )
                    {
                        _posT = "A";
                    }
                    if (_pos == 11)
                    {
                        _posT = "B";
                    }
                    if (_pos == 12)
                    {
                        _posT = "C";
                    }
                    if (_pos == 13)
                    {
                        _posT = "D";
                    }
                }
                  
                Console.WriteLine(_posT);
                position.Add(_posT);
            }

            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\!priv\AOC\Advent\Output\DagFan1.txt"))
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Github\AOC\Advent\Output\DagFan2_2.txt"))
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
