using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model.Tiles
{
    public class Dock : Rail
    {
        public override string Icon { get; set; } = "D";

        public override bool CanMove(Tile tile)
        {

            return true;
        }
    }
}
