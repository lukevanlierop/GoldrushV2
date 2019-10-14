using GoldrushV2.Model.Movables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model
{
    class Game
    {
        private List<Cart> _carts;
        private Map _map;
        private Ship _ship;

        public int GameSpeed { get; }
        public int Score { get; }

        public Game(Map map)
        {
            _carts = new List<Cart>();
            _map = map;
            Score = 0;
            GameSpeed = 200;
        }

        public void SpawnCart()
        {
            int[] warehouses = new int[] { 37, 61, 85 };
            Random rnd = new Random();
            int index = rnd.Next(0, 3);

            Tile SpawnTile = _map.Find(warehouses[index]);

            Cart cart = new Cart(SpawnTile);
            SpawnTile.Movable = cart;
            _carts.Add(cart);
        }

        public void SpawnShip()
        {
            if(_ship == null)
            {
                _ship = new Ship();
                _ship.CurrentTile = _map.First;
                _map.First.Movable = _ship;
            }
           
        }

        public void Move()
        {
            if(_ship != null)
            {
                _ship.Move();
            }
            

            foreach(Cart cart in _carts)
            {
                cart.Move();
            }
        }
    }
}
