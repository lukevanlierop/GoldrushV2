using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model.Movables
{
    public class Ship : Movable
    {
        public override Tile CurrentTile { get; set; }

        public override string Icon { get; } = "0";

        public override bool IsFull { get; set; } = false;

        public override void Move()
        {
            if (CurrentTile.Next == null)
            {
                CurrentTile.Movable = null;
            }

        }
    }
}
