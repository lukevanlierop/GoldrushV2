﻿using GoldrushV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.View
{
    class MainView
    {
        public void PrintMap(Map map)
        {
            Console.Clear();

            Tile current = map.First;
            int count = 1;
            while (current != null)
            {
                if (count < 12)
                {
                    if (current.Movable != null)
                    {
                        Console.Write(current.Movable.Icon);
                    }

                    else
                    {
                        Console.Write(current.Icon);
                    }
                    // Console.Write(current.Id + " ");
                }

                else
                {
                    if (current.Movable != null)
                    {
                        Console.WriteLine(current.Movable.Icon);
                    }

                    else
                    {
                        Console.WriteLine(current.Icon);
                    }
                    //Console.WriteLine(current.Id + " ");
                    count = 0;
                }

                current = current.Right;
                count++;
            }
        }

        public void PrintHud(int score, int speed)
        {
            Console.WriteLine("Your Score: " + score);
            Console.WriteLine("Game Speed: " + speed);
        }

        public void ShowGameOver()
        {
            Console.Clear();
            Console.WriteLine("The game is over. See you!\nPress ENTER to close this window.");
        }
    }
}
