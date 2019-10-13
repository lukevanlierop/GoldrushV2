using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Util
{
    class InputReader
    {
        public string GetInput()
        {
            var input = Console.ReadKey();

            //return switch id
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    return "52";
                case ConsoleKey.D2:
                    return "54";
                case ConsoleKey.D3:
                    return "58";
                case ConsoleKey.D4:
                    return "79";
                case ConsoleKey.D5:
                    return "81";
                case ConsoleKey.S:
                    return "s";
            }

            return "";
        }
    }
}
