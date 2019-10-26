using GoldrushV2.Model.Tiles;
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
        public bool IsDocked { get; set; } = false;
        public bool IsOffMap { get; set; } = false;

        public override string Icon
        {
            get
            {
                return GetIcon();
            }
        }

        public override bool IsFull
        {
            get
            {
                if (Load == 8)
                {
                    IsDocked = false;
                    CanGivePoints = true;
                    return true;
                }

                else
                {
                    return false;
                }
            }
            set { }
        }

        public int Load { get; set; } = 0;

        public override int Points { get; } = 10;

        public override void Move()
        {
            // if Ship is docked
            if(((Water)CurrentTile).HasDock && IsFull == false)
            {
                IsDocked = true;
            }

            else if (CurrentTile.Next == null)
            {
                // Go off the map
                CurrentTile.Movable = null;
                IsOffMap = true;
            }

            else
            {
                if (CurrentTile.Next.CanMove(CurrentTile))
                {
                    CurrentTile.Movable = null;
                    CurrentTile = CurrentTile.Next;
                    CurrentTile.Movable = this;
                }
            }
        }

        public string GetIcon()
        {
            switch (Load)
            {
                case 1:
                    return "-";
                case 2:
                    return "-";
                case 3:
                    return "-";
                case 4:
                    return "-";
                case 5:
                    return "=";
                case 6:
                    return "=";
                case 7:
                    return "≡";
                case 8:
                    return "≡";
                default:
                    return ">";
            }
        }
    }
}
