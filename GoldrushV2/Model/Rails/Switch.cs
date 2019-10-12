using GoldrushV2.Model.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model.Rails
{
    class Switch : Rail
    {
        public Tile Previous { get; set; }
        public override string Icon { get; set; } = "x";

        public override bool CanMove()
        {
            if (Next != null)
            {
                if (Next.Movable == null)
                {
                    return true;
                }
                return false;
            }

            return false;
        }
    }
}
