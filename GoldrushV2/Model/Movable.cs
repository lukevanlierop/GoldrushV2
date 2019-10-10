using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model
{
    public abstract class Movable
    {
        public abstract Tile Tile { get; set; }
        public abstract void Move();
        public abstract string Icon { get; }
    }
}
