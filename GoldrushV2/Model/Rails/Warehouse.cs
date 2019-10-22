using GoldrushV2.Model.Movables;
using GoldrushV2.Model.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model.Rails
{
    class Warehouse : Rail
    {
        public override string Icon { get; set; } = "W";

        public Cart GenerateCart()
        {
            // Take the adjacent tile of this Warehouse
            Tile SpawnTile = Next;

            // Generate new cart, and give it the tile
            Cart cart = new Cart(SpawnTile);
            SpawnTile.Movable = cart;

            // Return the newly created cart
            return cart;
        }
    }
}
