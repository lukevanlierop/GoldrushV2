using GoldrushV2.Builder;
using GoldrushV2.Model;
using GoldrushV2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GoldrushV2.Controller
{
    class MainController
    {
        private MainView _mv;
        private Map _map;
        private Game _game;
        private int seconds;

        public MainController()
        {
            _mv = new MainView();
        }

        public void Initialize()
        {
            BuildMap();
            _mv.PrintMap(_map);
            _game = new Game(_map);
            seconds = 0;
           // RunGame();

        }

        private void BuildMap()
        {
            MapBuilder builder = new MapBuilder();
            _map = builder.Build();
        }

        private void RunGame()
        {
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 100;
            timer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            _game.Move(); 
            seconds++;

            if (seconds == 5)
            {
                _game.SpawnCart();
                seconds = 0;
            }

            _mv.PrintMap(_map);
        }


    }
}
