using GoldrushV2.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2
{
    class Program
    {
        static void Main(string[] args)
        {
            new MainController().Initialize();

            Console.Read();
        }
    }
}
