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
        public int Score { get; set; }
        public bool Running { get; set; } = true;

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

            // Debug: Hardcode index on 1
            int index = 0;

            // Production: Random integer
            //int index = rnd.Next(0, 3);

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
                // As long as Dock is unoccupied, keep moving
                if(_map.Find(10).Movable == null)
                    _ship.Move();

                // if Ship is full, keep moving
                if (_ship.IsFull)
                    _ship.Move();

                // Ask map if it has Ship. If not, null it
                if (!_map.HasShip())
                    _ship = null;
            }

            foreach(Cart cart in _carts)
            {
                cart.Move();

                if(cart.CanGivePoints)
                {
                    Score++;
                    cart.CanGivePoints = false;
                }

                if (cart.HasCrashed())
                {
                    // The cart has crashed and the
                    // game stops running.
                    Running = false;
                }
            }
        }
    }
}
