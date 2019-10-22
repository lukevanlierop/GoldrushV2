using GoldrushV2.Model.Movables;
using GoldrushV2.Model.Rails;
using GoldrushV2.Model.Tiles;
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
        private List<Warehouse> _warehouses;
        private Map _map;
        private Ship _ship;
        private Dock _dock;

        public int GameSpeed { get; set; }
        public int Score { get; set; }
        public bool Running { get; set; } = true;

        public Game(Map map)
        {
            _carts = new List<Cart>();
            _map = map;
            Score = 0;
            GameSpeed = 666;
            _dock = (Dock)_map.Find(22);
            _warehouses = new List<Warehouse>();
            _warehouses.Add((Warehouse)_map.Find(37));
            _warehouses.Add((Warehouse)_map.Find(61));
            _warehouses.Add((Warehouse)_map.Find(85));
        }

        public void SpawnCart()
        {
            // Ask warehouse to generate the cart
            Cart cart = _warehouses[new Random().Next(0, 3)].GenerateCart();

            // Register the new cart in the list
            _carts.Add(cart);
        }

        public void IncreaseGameSpeed()
        {
            if(GameSpeed > 100)
            {
                GameSpeed -= Score * 3;
            }
        }

        public void SpawnShip()
        {
            if(_ship != null)
            {
                if (_ship.IsOffMap)
                {
                    _ship = null;
                }
            }
           
            if(_ship == null)
            {
                _ship = new Ship();
                _ship.CurrentTile = _map.First;
                _map.First.Movable = _ship;
                _dock.Ship = _ship;
            }
        }

        public void Move()
        {
            if(_ship != null)
            {
                _ship.Move();
                if(_ship.CanGivePoints)
                {
                    Score += 10;
                    _ship.CanGivePoints = false;
                    IncreaseGameSpeed();
                }
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
                    Running = false;
                }
            } 
        }
    }
}
