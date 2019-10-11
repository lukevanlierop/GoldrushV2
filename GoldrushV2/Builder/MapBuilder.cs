using GoldrushV2.Model;
using GoldrushV2.Model.Rails;
using GoldrushV2.Model.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Builder
{
    class MapBuilder
    {
        private Map _map;
        private int _count;
        private Tile _newTile;
        private Tile _current;

        public MapBuilder()
        {
            _map = new Map();
            CreateMap();
            CreateRoutes();
        }

        public void CreateMap()
        {
            //first row
            _count = 1;
            _map.First = new Water();
            _map.First.Id = _count;
            _count++;
            _current = _map.First;

            for (int i=0; i<11; i++)
            {
                _newTile = new Water();
                InitTile();
            }

            //second row
            for (int i = 0; i < 9; i++)
            {
                _newTile = new Rail();
                InitTile();
            }

            _newTile = new Dock();
            InitTile();

            for (int i = 0; i < 2; i++)
            {
                _newTile = new Rail();
                InitTile();
            }

            //third row
            for (int i = 0; i < 11; i++)
            {
                _newTile = new Empty();
                InitTile();
            }

            _newTile = new Rail();
            InitTile();


            //fourth row
            _newTile = new Warehouse();
            InitTile();

            for (int i = 0; i < 3; i++)
            {
                _newTile = new Rail();
                InitTile();
            }

            _newTile = new Empty();
            InitTile();

            for (int i = 0; i < 5; i++)
            {
                _newTile = new Rail();
                InitTile();
            }

            _newTile = new Empty();
            InitTile();

            _newTile = new Rail();
            InitTile();

            //fifth row
            for (int i = 0; i < 3; i++)
            {
                _newTile = new Empty();
                InitTile();
            }

            _newTile = new Switch();
            InitTile();
            Console.WriteLine(_newTile.Id);


            _newTile = new Rail();
            InitTile();

            _newTile = new Switch();
            InitTile();
            Console.WriteLine(_newTile.Id);


            for (int i = 0; i < 3; i++)
            {
                _newTile = new Empty();
                InitTile();
            }

            _newTile = new Switch();
            InitTile();
            Console.WriteLine(_newTile.Id);

            for (int i = 0; i < 2; i++)
            {
                _newTile = new Rail();
                InitTile();
            }


            //sixth row
            _newTile = new Warehouse();
            InitTile();

            for (int i = 0; i < 3; i++)
            {
                _newTile = new Rail();
                InitTile();
            }

            _newTile = new Empty();
            InitTile();

            for (int i = 0; i < 2; i++)
            {
                _newTile = new Rail();
                InitTile();
            }

            _newTile = new Empty();
            InitTile();

            for (int i = 0; i < 2; i++)
            {
                _newTile = new Rail();
                InitTile();
            }

            for (int i = 0; i < 2; i++)
            {
                _newTile = new Empty();
                InitTile();
            }

            //seventh row
            for (int i = 0; i < 6; i++)
            {
                _newTile = new Empty();
                InitTile();
            }

            _newTile = new Switch();
            InitTile();
            Console.WriteLine(_newTile.Id);
            _newTile = new Rail();
            InitTile();
            _newTile = new Switch();
            InitTile();
            Console.WriteLine(_newTile.Id);

            for (int i = 0; i < 3; i++)
            {
                _newTile = new Empty();
                InitTile();
            }

            //eight row
            _newTile = new Warehouse();
            InitTile();

            for (int i = 0; i < 6; i++)
            {
                _newTile = new Rail();
                InitTile();
            }

            _newTile = new Empty();
            InitTile();

            for (int i = 0; i < 4; i++)
            {
                _newTile = new Rail();
                InitTile();
            }

            //ninth row
            _newTile = new Empty();
            InitTile();

            for (int i = 0; i < 8; i++)
            {
                _newTile = new Yard();
                InitTile();
            }

            for (int i = 0; i < 3; i++)
            {
                _newTile = new Rail();
                InitTile();
            }

        }

        public void CreateRoute(int[] route, Tile previousTile, Tile currentTile)
        {
            foreach (int id in route)
            {
                currentTile = _map.Find(id);

                if (previousTile != null)
                {
                    previousTile.Next = currentTile;
                    //previousTile.Icon = "*";
                }

                previousTile = currentTile;

            }

            //previousTile.Icon = "*";
        }

        public void CreateRoutes()
        {
            Tile previousTile = null;
            Tile currentTile = null;

            CreateRoute(Routes.routeOne, previousTile, currentTile);
            previousTile = null;

            CreateRoute(Routes.routeTwo, previousTile, currentTile);
            previousTile = null;

            CreateRoute(Routes.routeThree, previousTile, currentTile);
            previousTile = null;

            CreateRoute(Routes.routeFour, previousTile, currentTile);

        }

        private void InitTile()
        {
            _newTile.Id = _count;
            _count++;
            _current.Right = _newTile;
            _current = _newTile;
        }

        public Map Build()
        {
            return _map;
        }
    }
}
