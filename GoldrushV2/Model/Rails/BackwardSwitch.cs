using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldrushV2.Model.Rails
{
    public class BackwardSwitch : Switch
    {
        public override void Shift()
        {
            if (Movable == null)
            {
                ChangeIcon();
                Tile temp;
                temp = Previous;
                Previous = Spare;
                Spare = temp;

            }
        }
    }
}
