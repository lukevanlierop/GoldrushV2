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
        private List<Movable> _movables;
        private List<Warehouse> _warehouses;
        private Map _map;
        private Ship _ship;
        private Dock _dock;

        public int GameSpeed { get; set; }
        public int Score { get; set; }
        public bool Running { get; set; } = true;

        public Game(Map map)
        {
            _movables = new List<Movable>();
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
            _movables.Add(cart);
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
                _movables.Add(_ship);
            }
        }

        public void Move()
        {
            foreach(Movable movable in _movables)
            {
                movable.Move();
                if(movable.CanGivePoints)
                {
                    Score += movable.Points;
                    movable.CanGivePoints = false;
                    IncreaseGameSpeed();
                }

                if (movable.HasCrashed)
                {
                    Running = false;
                }
            }
        }
    }
}
