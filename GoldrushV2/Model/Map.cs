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
    }
}
