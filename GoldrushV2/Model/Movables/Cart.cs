using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model.Movables
{
    public class Cart : Movable
    {
        public override Tile Tile { get; set; }
        public bool Full { get; set; } = true;

        public override string Icon
        {
            get
            {
                if (Full) return "ü";
                else return "u";
            }
        }

        public Cart(Tile tile)
        {
            Tile = tile;
        }

        public override void Move()
        {
            Tile = Tile.Next;
        }
    }
}
