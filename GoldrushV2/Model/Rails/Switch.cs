using GoldrushV2.Model.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model.Rails
{
    public abstract class Switch : Rail
    {
        public Tile Previous { get; set; }
        public Tile Spare { get; set; }
        public override string Icon { get; set; } = "/";

        public void ChangeIcon()
        {
            if (Icon == "/")
            {
                Icon = "\\";
            }

            else
            {
                Icon = "/";
            }
        }

        public override bool CanMove(Tile tile)
        {
            if(Previous == tile)
            {
                return true;
            }

            return false;
        }

        public abstract void Shift();
    }
}
