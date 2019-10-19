using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model
{
    public class Map
    {
        public Tile First { get; set; }

        public Tile Find(int id)
        {
            Tile current = First;
 
            while(current != null)
            {
                if(current.Id == id)
                {
                    return current;
                }

                current = current.Right;
            }

            return null;
        }

        public bool HasShip()
        {
            // TODO: Potential cleaner way to look up Ships?
            // foreach(int id in Routes.water)
            // {
            //     if (Find(id).Movable != null)
            //         return true;
            //     return false;
            // }

            Tile current = First;
            while (current.Id <= 12)
            {
                if (current.Movable != null)
                {
                    return true;
                }
                current = current.Right;
            }
            return false;
        }
    }
}
