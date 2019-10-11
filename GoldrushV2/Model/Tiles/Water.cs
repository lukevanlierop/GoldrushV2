using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model.Tiles
{
    public class Water : Tile
    {
        public override string Icon { get; set;} = "~";
        public override Movable Movable { get; set; }

        public override bool CanMove()
        {
            throw new NotImplementedException();
        }
    }
}
