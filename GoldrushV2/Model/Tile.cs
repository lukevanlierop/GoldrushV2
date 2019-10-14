using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model
{
    public abstract class Tile
    {
        public abstract string Icon { get; set; }
        public abstract Movable Movable { get; set; }
        public abstract bool CanMove(Tile tile);
        public Tile Right { get; set; }
        public Tile Next { get; set; }
        public int Id { get; set; }
    }
}
