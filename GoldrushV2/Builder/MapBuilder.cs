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
            ConnectSwitches();
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
                if(i == 8)
                {
                    ((Water)_newTile).HasDock = true;
                }
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

            _newTile = new BackwardSwitch();
            InitTile();
        


            _newTile = new Rail();
            InitTile();

            _newTile = new ForwardSwitch();
            InitTile();
           


            for (int i = 0; i < 3; i++)
            {
                _newTile = new Empty();
                InitTile();
            }

            _newTile = new BackwardSwitch();
            InitTile();
         

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

            _newTile = new BackwardSwitch();
            InitTile();
       
            _newTile = new Rail();
            InitTile();
            _newTile = new ForwardSwitch();
            InitTile();
      

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

            CreateRoute(Routes.water, previousTile, currentTile);
            previousTile = null;

            CreateRoute(Routes.routeOne, previousTile, currentTile);
            previousTile = null;

            CreateRoute(Routes.routeTwo, previousTile, currentTile);
            previousTile = null;

            CreateRoute(Routes.routeThree, previousTile, currentTile);
            previousTile = null;

            CreateRoute(Routes.routeFour, previousTile, currentTile);

        }

        public void ConnectSwitches()
        {
            Switch currentSwitch;

            //first
            currentSwitch = (Switch)_map.Find(52);
            currentSwitch.Previous = _map.Find(40);
            currentSwitch.Next = _map.Find(53);
            currentSwitch.Spare = _map.Find(64);
            currentSwitch.Icon = "\\";

            //second
            currentSwitch = (Switch)_map.Find(54);
            currentSwitch.Previous = _map.Find(53);
            currentSwitch.Next = _map.Find(42);
            currentSwitch.Spare = _map.Find(66);
            currentSwitch.Icon = "/";

            //third
            currentSwitch = (Switch)_map.Find(58);
            currentSwitch.Previous = _map.Find(46);
            currentSwitch.Next = _map.Find(59);
            currentSwitch.Spare = _map.Find(70);
            currentSwitch.Icon = "\\";

            //fourth
            currentSwitch = (Switch)_map.Find(79);
            currentSwitch.Previous = _map.Find(67);
            currentSwitch.Next = _map.Find(80);
            currentSwitch.Spare = _map.Find(91);
            currentSwitch.Icon = "\\";

            //fifth
            currentSwitch = (Switch)_map.Find(81);
            currentSwitch.Previous = _map.Find(80);
            currentSwitch.Next = _map.Find(93);
            currentSwitch.Spare = _map.Find(69);
            currentSwitch.Icon = "\\";

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
