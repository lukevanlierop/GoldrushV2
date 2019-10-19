﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model.Movables
{
    public class Ship : Movable
    {
        public override Tile CurrentTile { get; set; }

        public override string Icon
        {
            get
            {
                return GetIcon();
            }
        }

        public override bool IsFull { get; set; } = false;

        public int Load { get; set; } = 0;

        public override void Move()
        {
            if (CurrentTile.Next == null)
                // Go off the map
                CurrentTile.Movable = null;

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

        public bool IsDocked() 
        {
            
            return false;
        }

        public string GetIcon()
        {
            switch (Load)
            {
                case 1:
                    return "-";
                case 2:
                    return "=";
                case 3:
                    return "≡";
                default:
                    return "X";
            }
        }
    }
}
