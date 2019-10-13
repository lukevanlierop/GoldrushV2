using GoldrushV2.Model.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model.Rails
{
    class Final : Rail
    {
        public override bool IsFinal { get; set; } = true;
    }
}
