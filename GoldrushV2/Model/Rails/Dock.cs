﻿using GoldrushV2.Model.Movables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model.Tiles
{
    public class Dock : Rail
    {
        private Movable _movable;
        public override string Icon { get; set; } = "D";
        public Ship Ship { get; set; }

        public override Movable Movable
        {
            get { return _movable; }
            set
            {
                _movable = value;

                if (Movable != null && Ship != null)
                {
                    if(Ship.IsDocked)
                    {
                        Movable.IsFull = false;
                        Movable.CanGivePoints = true;
                        Ship.Load++;
                    } 
                }             
            }
        }

        public override bool CanMove(Tile tile)
        {
            return true;
        }
    }
}
