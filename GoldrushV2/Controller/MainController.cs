using GoldrushV2.Builder;
using GoldrushV2.Model;
using GoldrushV2.Model.Rails;
using GoldrushV2.Util;
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
        private InputReader _inputReader;
        private int seconds;
        private bool _play;

        public MainController()
        {
            _mv = new MainView();
        }

        public void Initialize()
        {
            BuildMap();
            _mv.PrintMap(_map);
            _game = new Game(_map);
            _mv.PrintHud(_game.Score, _game.GameSpeed);
            _inputReader = new InputReader();
            seconds = 0;
            PlayGame();
        }

        private void BuildMap()
        {
            MapBuilder builder = new MapBuilder();
            _map = builder.Build();
        }

        private void PlayGame()
        {
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = _game.GameSpeed;
            timer.Enabled = true;
            _play = true;

            while(_play)
            {
                string key = _inputReader.GetInput();

                if (key == "s")
                    QuitGame();

                else if (key != "")
                    ShiftSwitch(key);
            }

            timer.Enabled = false;
        }

        private void QuitGame()
        {
            _play = false;
            _mv.ShowGameOver();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (_game.Running)
            {
                _game.Move();
                seconds++;

                if (seconds == 5)
                {
                    _game.SpawnCart();
                    if(!_map.HasShip())
                        _game.SpawnShip();
                    seconds = 0;
                }

                _mv.PrintMap(_map);
                _mv.PrintHud(_game.Score, _game.GameSpeed);
            }
            else
                QuitGame();
        }

        private void ShiftSwitch(string id)
        {
            Switch sw = (Switch)_map.Find(Convert.ToInt32(id));
            sw.Shift();
        }
    }
}
