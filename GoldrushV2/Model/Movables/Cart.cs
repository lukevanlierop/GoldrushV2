﻿using System;
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
        public override int Points { get; } = 1;

        public override string Icon
        {
            get
            {
                if (IsFull) return "ü";
                else return "u";
            }
        }

        public Cart(Tile tile)
        {
            CurrentTile = tile;
        }

        public override void Move()
        {
            //cart moves off map
            if (CurrentTile.Next == null)
            {
                CurrentTile.Movable = null;
            }

            else
            {
                if (CurrentTile.Next.CanMove(CurrentTile))
                {
                    //check for crash
                    if (CurrentTile.Next.Movable != null)
                    { 
                        HasCrashed = true;
                    }
                    
                    //move cart
                    else
                    {
                        CurrentTile.Movable = null;
                        CurrentTile = CurrentTile.Next;
                        CurrentTile.Movable = this;
                    }
                }
            }
        }
    }
}
