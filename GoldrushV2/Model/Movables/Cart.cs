using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model.Movables
{
    public class Cart : Movable
    {
        public override Tile CurrentTile { get; set; }
        public override bool IsFull { get; set; } = true;

        public override string Icon
        {
            get
            {
                if (IsFull) return "ü";
                else return "u";
            }
        }

        private bool IsCrashed;

        public Cart(Tile tile)
        {
            CurrentTile = tile;
        }

        public override void Move()
        {
            if (CurrentTile.Next == null)
            {
                CurrentTile.Movable = null;
            }

            else
            {
                if (CurrentTile.Next.CanMove(CurrentTile))
                {
                    if (CurrentTile.Next.Movable != null)
                        // Following tile contains a movable, so
                        // this carts crash.
                        this.IsCrashed = true;
                    else
                    {
                        CurrentTile.Movable = null;
                        CurrentTile = CurrentTile.Next;
                        CurrentTile.Movable = this;
                    }
                }
            }
        }

        public bool HasCrashed()
        {
            return IsCrashed;
        }

        public bool IsAtDock()
        {
            if (CurrentTile.Icon == "D")
                return true;
            return false;
        }
    }
}
