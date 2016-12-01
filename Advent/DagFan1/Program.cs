#region
using System;
using Helper;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace DagFan1
{
    internal static class Day
    {
        private static void Main()
        {
            var input = Utilities.GetInput(1);

            List<string> inputList = new List<string>();

            inputList = input.Split(new[]
                                          {
                                              ", "
                                          }, StringSplitOptions.None).ToList();

            int _posX = 0;
            int _posY = 0;
            int _direction = 0;
            int _posY_Old = 0;
            int _posX_Old = 0;
            // 0 = up
            // 1 = höger
            // 2 = ner
            // 3 = vänster
            
            List<string> position = new List<string>();

            foreach (var turn in inputList)
            {
                var temp = turn.ToString();
                //Set direction
                if (temp.StartsWith("L")) { _direction = _direction - 1; }
                if (temp.StartsWith("R")) { _direction = _direction + 1; }
                if (_direction == -1) { _direction = 3; }
                if (_direction == 4) { _direction = 0; }
                //Calc position
                int tempNR = Int32.Parse(temp.Substring(1));                
                switch (_direction)
                {
                    case 0: _posY = _posY + tempNR;
                        break;
                    case 1:
                        _posX = _posX + tempNR;
                        break;
                    case 2:
                        _posY = _posY - tempNR;
                        break;
                    case 3:
                        _posX = _posX - tempNR;
                        break;
                }
                while(_posX_Old != _posX || _posY != _posY_Old)
                {
                    if(_posX < _posX_Old) { _posX_Old = _posX_Old - 1; }
                    if (_posX > _posX_Old) { _posX_Old = _posX_Old + 1; }
                    if (_posY < _posY_Old) { _posY_Old = _posY_Old - 1; }
                    if (_posY > _posY_Old) { _posY_Old = _posY_Old + 1; }
                    position.Add(_posY_Old.ToString() + ":" + _posX_Old.ToString());
                }
                                               
                Console.WriteLine(temp + " " +_posY + ":" + _posX);
            }
            
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\!priv\AOC\Advent\Output\DagFan1.txt"))
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