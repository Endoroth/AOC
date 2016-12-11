using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using System.Text.RegularExpressions;

namespace DagFan6
{
    internal static class Day
    {
        private static void Main()
        {
            var input = Utilities.GetInput(6);
            List<string> inputList = new List<string>();
            string password = "";
            inputList = input.Split(new[]
                                          {
                                              "\r\n"
                                          }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] msg0 = new string[inputList.Count()];
            string[] msg1 = new string[inputList.Count()];
            string[] msg2 = new string[inputList.Count()];
            string[] msg3 = new string[inputList.Count()];
            string[] msg4 = new string[inputList.Count()];
            string[] msg5 = new string[inputList.Count()];
            string[] msg6 = new string[inputList.Count()];
            string[] msg7 = new string[inputList.Count()];

            for (var i = 0; i < inputList.Count; i++)
            {
                msg0[i] = inputList.ElementAt(i).Substring(0, 1);
                msg1[i] = inputList.ElementAt(i).Substring(1, 1);
                msg2[i] = inputList.ElementAt(i).Substring(2, 1);
                msg3[i] = inputList.ElementAt(i).Substring(3, 1);
                msg4[i] = inputList.ElementAt(i).Substring(4, 1);
                msg5[i] = inputList.ElementAt(i).Substring(5, 1);
                msg6[i] = inputList.ElementAt(i).Substring(6, 1);
                msg7[i] = inputList.ElementAt(i).Substring(7, 1);
            }
                        
            password = pw(msg0) + pw(msg1) + pw(msg2) +pw(msg3) +pw(msg4) +pw(msg5) + pw(msg6) + pw(msg7);
                    
            Console.WriteLine(password);

            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\!priv\AOC\Advent\Output\DagFan1.txt"))
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Github\AOC\Advent\Output\DagFan6.txt"))
            {
                file.WriteLine(password);
            }
            //Knuub
            Console.ReadKey();
        }

        static string pw(string[] input)
        {
            Dictionary<string, int> counts = input.GroupBy(x => x)
                                            .ToDictionary(g => g.Key,
                                             g => g.Count());
                                                            //.Min = max part 1
            var max = from x in counts where x.Value == counts.Min(v => v.Value) select x.Key;
            var l = "";
            foreach (var x in max)
            {
                l = x;
            }

            return l;
        }
    }
    
}
